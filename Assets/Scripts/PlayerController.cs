using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int speed = 30;
    private float horizontalInput;
    [SerializeField]
    protected GameObject bullet;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if(transform.position.x > GameManager.hBounds) {
            transform.position = new Vector3(GameManager.hBounds, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -GameManager.hBounds) {
            transform.position = new Vector3(-GameManager.hBounds, transform.position.y, transform.position.z);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch projectile from player
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletEnemy") || other.gameObject.CompareTag("Enemy"))
        {
            gameManager.PlayerDamage(25);
        }
    }
}
