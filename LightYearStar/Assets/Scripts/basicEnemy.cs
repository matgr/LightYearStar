using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public GameObject bullet;

    private Rigidbody2D rb;

    private SpriteRenderer sp;
    public float enemySpeed = 1f;
    public int enemyType = 0;

    public float enemyShotStart = 0.75f;
    public float enemyRateOfFire = 1f;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyType = Random.Range(1, 4);
        if (enemyType==1) //enemy in vertical
        {
            rb.velocity = new Vector2(0, -enemySpeed);
        }
        if (enemyType == 2) //enemy comes from right
        {
            sp = GetComponent<SpriteRenderer>();
            sp.transform.Rotate(0,0,45);
            rb.velocity = new Vector2(2 * enemySpeed * Mathf.Cos(45), - 2* enemySpeed * Mathf.Sin(45));
        }
        if (enemyType == 3) //enemy comes from left
        {
            sp = GetComponent<SpriteRenderer>();
            sp.transform.Rotate(0, 0, -45);
            rb.velocity = new Vector2(-2 * enemySpeed * Mathf.Cos(45), - 2 * enemySpeed * Mathf.Sin(45));
        }

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
