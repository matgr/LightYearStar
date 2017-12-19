using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public GameObject bullet;

    private Rigidbody2D rb;
    public float enemySpeed = 1f;

    public float enemyShotStart = 0.75f;
    public float enemyRateOfFire = 1f;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -enemySpeed);
        InvokeRepeating("basicShot", enemyShotStart, enemyRateOfFire);
    }
	
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void basicShot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 0.8f), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("HeroShot"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
