using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class JeepEnemy : Enemy
{
    void Awake()
    {
        moveSpeed = 20;
        scoreValue = 10;
    }

    void Update() 
    {
        Move();
    }
}
