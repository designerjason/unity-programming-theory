using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepEnemy : Enemy
{
    void Awake()
    {
        health = 400;
        moveSpeed = 20;
    }

    void Update() 
    {
        Move();
    }
}
