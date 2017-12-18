using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rb;
    private float speed = 10f;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    void OnBecameInvisible() //Function called when the object is no longer visible on camera
    {
        Destroy(gameObject);
    }
}
