using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionValueManager : MonoBehaviour
{

    public static CorrectionValueManager instance;

    public int atk = 0;
    public float speed = 0f;
    public float bulletSpeed = 0f;
    public float rateTime = 0f;
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


        atk = SaveDataFile.instance.atkSave;
        speed = SaveDataFile.instance.speedSave;
        bulletSpeed = SaveDataFile.instance.bulletSpeedSave;
        rateTime = SaveDataFile.instance.rateTimeSave;


        Debug.Log("공격력" + atk);
        Debug.Log("스피드" + speed);
        Debug.Log("탄속" + bulletSpeed);
        Debug.Log("레이트타임" + rateTime);
    }

    
    
}
