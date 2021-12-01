using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryEnemy : Enemy
{
    Vector3 direction;
    public GameObject bullet;

    void Awake()
    {
        //health = 100;
        damage = 10;
        moveSpeed = 5;
        scoreValue = 5;
        // invoke randomdirection change every 0.5f
        InvokeRepeating("RandomDirection", 0.5f, 0.5f);
        Shoot(bullet);
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        // infantry has randomized direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    // spit our a random vector direction
    public Vector3 RandomDirection()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                direction = Vector3.left;
                break;
            case 2:
                direction = Vector3.right;
                break;
            case 3:
            case 4:
                direction = Vector3.forward;
                break;
            default:
                direction = Vector3.forward;
                break;
        }
        return direction;
    }
}
