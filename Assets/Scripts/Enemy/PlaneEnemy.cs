using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PlaneEnemy : Enemy
{
    public GameObject paratrooper;

    void Awake()
    {
        moveSpeed = 25;
        scoreValue = 0;
    }

    void Start() {
        int i = 1;
        while (i < 3)
        {
            Invoke("SpawnParatrooper", i); 
            i++;
        }  
    }

    void Update() 
    {
        Move();
    }

    void SpawnParatrooper()
    {
        Instantiate(paratrooper, transform.position, paratrooper.transform.rotation);
    }

}
