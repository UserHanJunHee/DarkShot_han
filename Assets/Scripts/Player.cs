using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    //체력 체력바 계산 상시 형변환 안할려고 float
    float maxhp = 100;
    float hp;
    bool isHit = false;
    bool isdead = false;

    //마나

    //int mana = 30;

    string[] bulletType = { "PlayerBulletA", "PlayerBulletB", "BoomBullet"};
    int playerBulletType = 0;
    
    //이동속도
    float speed = 3f;

    //총알 발사 딜레이
    bool youcanfire = false;
    float fireTime = 0f;
    float maxfireTime = 0.8f;


    //경험치
    int playerLV = 1;
    float playerEXP = 0;
    float playerMaxEXP = 5;

    //경계선
    bool topBoundary;
    bool bottomBoundary;
    bool leftBoundary;
    bool rightBoundary;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hp = maxhp;
    }
    void Update()
    {
        if(!isdead)
        {
            FireRate();
            Move();
            Attack();
        }
    }

    void FireRate()
    {
        if(!youcanfire)
        {
            fireTime += Time.deltaTime;
            if(fireTime > maxfireTime - (maxfireTime * CorrectionValueManager.instance.rateTime))
            {
                youcanfire = true;
            }
        }
    }

    void Move()
    {
        //키보드 이동
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if ((h == 1 && rightBoundary) || (h == -1 && leftBoundary))
            h = 0;

        if ((v == 1 && topBoundary) || (v == -1 && bottomBoundary))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * (speed + (CorrectionValueManager.instance.speed *speed)) * Time.deltaTime;


        transform.position = curPos + nextPos;


        if (h != 0)
        {
            if(h == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            //transform.localScale = new Vector3(h, transform.localScale.y, transform.localScale.z);
            //UIManager.instance.PlayerHpGageRotate(h);
            animator.SetBool("Move", true);
        }
        else if(v != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void Attack()
    {
        if(youcanfire && !UIManager.instance.lvUpPannel.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                fireTime = 0f;
                youcanfire = false;
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                if (mousePos != null)
                {
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);//마우스 누른 지점

                    GameObject playerBullet = ObjectManager.instance.MakeObj(bulletType[playerBulletType]);
                    playerBullet.GetComponent<Bullet>().Attack(mousePos);
                }
            }
        }
    }

    
    public void PlayerOnDamage(int damage)
    {
        if(!isHit)
        {
            isHit = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.7f);
            hp -= damage;
            animator.SetTrigger("Hit");
            UIManager.instance.PlayerHpGage(hp, maxhp);
            if (hp < 0)
            {
                isdead = true;
                animator.SetBool("IsDead", isdead);
                UIManager.instance.RetryPannelOn();
                return;
            }
            Invoke("ReturnOnHit", 2f);
        }
    }

    private void ReturnOnHit()//바로 위에서 인보크로 쓰이는중
    {
        isHit = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void GetEXPItem(int exp)
    {
        playerEXP += exp;
        if (playerEXP >= playerMaxEXP)
        {
            playerLV++;
            playerEXP = playerEXP - playerMaxEXP;
            playerMaxEXP = playerLV * 5;
            UIManager.instance.LevelUpPanelOn();
            UIManager.instance.LvUp(playerLV);
        }
        UIManager.instance.ExpUp(playerEXP, playerMaxEXP);
    }

    public void RecoveryHp(int i)
    {
        hp += i;
        if(hp > maxhp)
        {
            hp = maxhp;
        }
        UIManager.instance.PlayerHpGage(hp, maxhp);
    }


    public void ChangeBulletType(int typenum, float rateTime)
    {
        playerBulletType = typenum;
        maxfireTime = rateTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && !isdead && collision.gameObject.tag == "Enemy")
        {
            PlayerOnDamage(collision.gameObject.GetComponent<Enemy>().Damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null && !isdead && collision.gameObject.tag == "Enemy")
        {
            PlayerOnDamage(collision.gameObject.GetComponent<Enemy>().Damage);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "RedLineTop":
                    topBoundary = true;
                    break;
                case "RedLineBottom":
                    bottomBoundary = true;
                    break;
                case "RedLineRight":
                    rightBoundary = true;
                    break;
                case "RedLineLeft":
                    leftBoundary = true;
                    break;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "RedLineTop":
                    topBoundary = false;
                    break;
                case "RedLineBottom":
                    bottomBoundary = false;
                    break;
                case "RedLineRight":
                    rightBoundary = false;
                    break;
                case "RedLineLeft":
                    leftBoundary = false;
                    break;
            }
        }
    }
}
