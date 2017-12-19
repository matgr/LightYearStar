using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float bulletSpeed = 0.5f;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -bulletSpeed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
