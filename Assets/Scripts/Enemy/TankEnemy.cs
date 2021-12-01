using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    public GameObject bullet;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Awake()
    {
        health = 500;
        damage = 40;
        moveSpeed = 3;
    }

    void Start() {
        coroutine = Shooting();
        StartCoroutine("Shooting");
    }

    void Update() 
    {
        Move();
    }

    IEnumerator Shooting()
    {
        int ammo = 3;
        while(ammo > 0) {
            Shoot(bullet);
            ammo--;
            yield return new WaitForSeconds(1);
            
        }
        if(ammo == 0) {
            ammo = 3;
            StartCoroutine("Reloading");
        }
    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine("Shooting");
    }
}
