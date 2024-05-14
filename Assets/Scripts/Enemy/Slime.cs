using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public Slime()
    {
        type = "Slime";
        hp = 10;
        damage = 4;
        moveSpeed = 200f;
        maxHitTime = 0.2f;
        expPoint = 1;
    }
}
