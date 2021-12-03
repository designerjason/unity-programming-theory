using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int moveSpeed;
    [SerializeField] protected int scoreValue;

    GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // ABSTRACTION
    public virtual void Shoot(GameObject bulletEnemy)
    {
        Instantiate(bulletEnemy, transform.position, bulletEnemy.transform.rotation);
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            gameManager.AddScore(scoreValue);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
