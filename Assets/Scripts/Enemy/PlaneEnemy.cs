using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemy : Enemy
{
    public GameObject paratrooper;

    void Awake()
    {
        health = 200;
        damage = 25;
        moveSpeed = 25;
    }

    void Start() {
        int i = 1;
        while (i < 4)
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
