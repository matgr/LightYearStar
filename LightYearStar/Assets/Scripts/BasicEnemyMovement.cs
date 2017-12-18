using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemySpeed = 1f;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(enemySpeed*Mathf.Sin(45), -enemySpeed*Mathf.Cos(45));
    }
	
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
