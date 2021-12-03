using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class TankEnemy : Enemy
{
    public GameObject bullet;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Awake()
    {
        moveSpeed = 3;
        scoreValue = 10;
        coroutine = Shooting();
        StartCoroutine("Shooting");
    }

    void Update() 
    {
        Move();
    }

    IEnumerator Shooting()
    {
        //Shoot(bullet);
        //yield return new WaitForSeconds(0.5f);
        int ammo = 3;
        while(ammo > 0) {
            Shoot(bullet);
            ammo--;
            yield return new WaitForSeconds(0.25f);
            
        }
        if(ammo == 0) {
            ammo = 3;
            StartCoroutine("Reloading");
        }
    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine("Shooting");
    }
}
