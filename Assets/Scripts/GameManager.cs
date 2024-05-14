using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject player;
    public Transform playerPos;
    //public bool gameStop = false;

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
        //FindPlayer();
        SkillManager.instance.StartSkillSetting();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.GetComponent<Player>().GetEXPItem(5);
        }

    }


    public Player PlayerComponent()
    {
        return player.GetComponent<Player>();
    }

    //public void GetMoney(int i)
    //{
    //    SaveDataFile.instance.money += i;
    //}


    public void LoadthisScean()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadStartRoomScean()
    {
        SceneManager.LoadScene(0);
    }
}
