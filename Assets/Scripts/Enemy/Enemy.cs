using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected int moveSpeed;
    [SerializeField] public int scoreValue;

    public virtual void Shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position, bullet.transform.rotation);
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void TakeDamage()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
