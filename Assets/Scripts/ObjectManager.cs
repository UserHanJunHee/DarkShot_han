using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    //총알
    public GameObject playerBulletAPrefab;
    public GameObject playerBulletBPrefab;
    public GameObject boomBulletPrefab;
    public GameObject explosionPrefab;

    //적군 총알
    public GameObject enemyBulletBPrefab;


    //적군
    public GameObject enemySlimePrefab;
    public GameObject ranagePrefab;
    public GameObject bossPrefab;
    //아이템
    public GameObject blueEXPPrefab;
    public GameObject greenEXPPrefab;
    public GameObject redEXPPrefab;

    Queue<GameObject> playerBulletA;
    Queue<GameObject> playerBulletB;
    Queue<GameObject> boomBullet;
    Queue<GameObject> explosion;
    Queue<GameObject> enemyBullet;
    Queue<GameObject> enemySlime;
    Queue<GameObject> ranage;
    Queue<GameObject> boss;
    Queue<GameObject> blueEXP;
    Queue<GameObject> greenEXP;
    Queue<GameObject> redEXP;




    public List<GameObject> explosionList = new List<GameObject>();
    public List<GameObject> playerBulletBList = new List<GameObject>();
    //Queue<GameObject> targetPool;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        playerBulletA = new Queue<GameObject>();
        playerBulletB = new Queue<GameObject>();
        boomBullet = new Queue<GameObject>();
        explosion = new Queue<GameObject>();
        enemyBullet = new Queue<GameObject>();
        enemySlime = new Queue<GameObject>();
        ranage = new Queue<GameObject>();
        boss = new Queue<GameObject>();
        blueEXP = new Queue<GameObject>();
        greenEXP = new Queue<GameObject>();
        redEXP = new Queue<GameObject>();

        Generate();
        SpawnManager.instance.StartSigh();
    }


    void Generate()
    {
        //플레이어 총알
        for (int index = 0; index < 100; index++)
        {
            GameObject prefabObject = Instantiate(playerBulletAPrefab);
            playerBulletA.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

        for (int index = 0; index < 200; index++)
        {
            GameObject prefabObject = Instantiate(playerBulletBPrefab);
            playerBulletBList.Add(prefabObject);
            playerBulletB.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

        for (int index = 0; index < 100; index++)
        {
            GameObject prefabObject = Instantiate(boomBulletPrefab);
            boomBullet.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

        for (int index = 0; index < 100; index++)
        {
            GameObject prefabObject = Instantiate(explosionPrefab);
            explosionList.Add(prefabObject);
            explosion.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

        for (int index = 0; index < 100; index++)
        {
            GameObject prefabObject = Instantiate(enemyBulletBPrefab);
            enemyBullet.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

        //몬스터
        for (int index = 0; index < 300; index++)
        {
            GameObject prefabObject = Instantiate(enemySlimePrefab);
            enemySlime.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }
        for (int index = 0; index < 300; index++)
        {
            GameObject prefabObject = Instantiate(ranagePrefab);
            ranage.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }
        for (int index = 0; index < 2; index++)
        {
            GameObject prefabObject = Instantiate(bossPrefab);
            boss.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

        //경험치
        for (int index = 0; index < 100; index++)
        {
            GameObject prefabObject = Instantiate(blueEXPPrefab);
            blueEXP.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }
        for (int index = 0; index < 100; index++)
        {
            GameObject prefabObject = Instantiate(greenEXPPrefab);
            greenEXP.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }
        for (int index = 0; index < 10; index++)
        {
            GameObject prefabObject = Instantiate(redEXPPrefab);
            redEXP.Enqueue(prefabObject);
            prefabObject.SetActive(false);
        }

    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "PlayerBulletA":
                if (playerBulletA.Count > 0)
                {
                    GameObject prefabObject = playerBulletA.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "PlayerBulletB":
                if (playerBulletB.Count > 0)
                {
                    GameObject prefabObject = playerBulletB.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "BoomBullet":
                if (boomBullet.Count > 0)
                {
                    GameObject prefabObject = boomBullet.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "Explosion":
                if (boomBullet.Count > 0)
                {
                    GameObject prefabObject = explosion.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "EnemyBullet":
                if (enemyBullet.Count > 0)
                {
                    GameObject prefabObject = enemyBullet.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "Slime":
                if (enemySlime.Count > 0)
                {
                    GameObject prefabObject = enemySlime.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "Ranage":
                if (ranage.Count > 0)
                {
                    GameObject prefabObject = ranage.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "Boss":
                if (boss.Count > 0)
                {
                    GameObject prefabObject = boss.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "BlueEXP":
                if (blueEXP.Count > 0)
                {
                    GameObject prefabObject = blueEXP.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "GreenEXP":
                if (greenEXP.Count > 0)
                {
                    GameObject prefabObject = greenEXP.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
            case "RedEXP":
                if (redEXP.Count > 0)
                {
                    GameObject prefabObject = redEXP.Dequeue();
                    prefabObject.SetActive(true);
                    return prefabObject;
                }
                break;
        }
        return null;
    }

    public void ReturnObject(GameObject obj, string type)
    {
        switch (type)
        {
            case "PlayerBulletA":
                playerBulletA.Enqueue(obj);
                break;
            case "PlayerBulletB":
                playerBulletB.Enqueue(obj);
                break;
            case "BoomBullet":
                boomBullet.Enqueue(obj);
                break;
            case "Explosion":
                explosion.Enqueue(obj);
                break;
            case "EnemyBullet":
                enemyBullet.Enqueue(obj);
                break;
            case "Slime":
                enemySlime.Enqueue(obj);
                break;
            case "Ranage":
                ranage.Enqueue(obj);
                break;
            case "Boss":
                boss.Enqueue(obj);
                break;
            case "BlueEXP":
                blueEXP.Enqueue(obj);
                break;
            case "GreenEXP":
                greenEXP.Enqueue(obj);
                break;
            case "RedEXP":
                redEXP.Enqueue(obj);
                break;
        }
        obj.SetActive(false);
    }
}