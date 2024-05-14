using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [SerializeField]
    private Transform[] SpawnPoint;

    private bool startSpawn = false;
    private bool startRanageSpawn = false;

    float zeroTime = 0f;
    float currentTime;
    float spawnTime;


    float ranageCurrentTime;
    float ranageSpawnTime;
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
    }

    private void Update()
    {
        SpawnAnyTimeSystem();
        SpawnRanageTimeSyatem();

    }

    void SpawnAnyTimeSystem()
    {
        if (startSpawn && spawnTime < currentTime)
        {
            currentTime = zeroTime;
            spawnTime = Random.Range(0, 2f);
            EnemySpawn("Slime");
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    void SpawnRanageTimeSyatem()
    {
        if (startRanageSpawn && ranageSpawnTime < ranageCurrentTime)
        {
            ranageCurrentTime = zeroTime;
            ranageSpawnTime = Random.Range(1, 2.5f);
            RangeSpqwn("Ranage");
        }
        else
        {
            ranageCurrentTime += Time.deltaTime;
        }
    }


    public void EnemySpawn(string type)
    {
        GameObject enemy = ObjectManager.instance.MakeObj(type);
        enemy.transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].position;
    }

    public void RangeSpqwn(string type)
    {
        GameObject enemy = ObjectManager.instance.MakeObj(type);
        //enemy.transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].position;

        int x;
        int y;

        int xminer = Random.Range(0, 2);
        int yminer = Random.Range(0, 2);

        if (xminer == 0)
            x = 1;
        else
            x = -1;

        if(yminer == 0)
            y = 1;
        else
            y = -1;

        enemy.transform.position = new Vector2(GameManager.instance.playerPos.position.x + Random.Range(2f, 4f) * x, GameManager.instance.playerPos.position.y + Random.Range(2f, 4f) * y);
    }

    public void StartSigh()
    {
        startSpawn = true;
        spawnTime = 3f;
    }

    public void StartRanageSpawn()
    {
        startRanageSpawn = true;
    }

    public void SpawnBoss()
    {
        GameObject enemy = ObjectManager.instance.MakeObj("Boss");
        enemy.transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].position;
    }
}
