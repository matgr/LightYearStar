using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    //Bullet features
    public GameObject bullet;
    private float shootStart = 0.75f;
    public float shootTime = 0.5f;


    //Spaceship features
    private float speed = 12f;
    private int durability = 3; //number of "lifes"

    //Spaceship size to ajust to the edges of the screen
    private float shipBoundaryY = 0.5f;
    private float shipBoundaryX = 0.5f;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("BasicShoot", shootStart, shootTime); //Calls the BasicShoot function that instatiate the bullets each instant
    }

	void FixedUpdate ()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX * speed, moveY * speed);
    }

    void Update()
    {
        //Screen boundaries
        Vector3 pos = transform.position;
        if (pos.y + shipBoundaryY > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryY;
        }

        if (pos.y - shipBoundaryY < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryY;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaryX > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryX;
        }

        if (pos.x - shipBoundaryX < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryX;
        }
        transform.position = pos;
    }

    void BasicShoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.6f), Quaternion.identity);
    }

}
