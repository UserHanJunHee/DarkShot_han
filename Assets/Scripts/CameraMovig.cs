using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovig : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(GameManager.instance.playerPos.position.x, GameManager.instance.playerPos.position.y+0.5f, transform.position.z);
    }
}
