using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public int coinCount;
    public Text coinQuant;

    //Bullet features
    public GameObject bullet;
    private float shootStart = 0.75f;
    public float shootTime = 0.5f;


    //Spaceship features
    public bool isHit = false;
    private float speed = 12f;
    public int durability = 3; //number of "lifes"
    public int invunerabilityTime = 3;


    //Spaceship size to ajust to the edges of the screen
    private float shipBoundaryY = 0.5f;
    private float shipBoundaryX = 0.5f;

    //Variables for the blinking effect after the spaceship taking damage
    private SpriteRenderer mySpriteRenderer;
    public float flashSpeed = 0.2f;
    private PolygonCollider2D collPlayer;


    void Start ()
    {
        coinCount = 0;
        rb = GetComponent<Rigidbody2D>(); //Getting the reference for the rigidbody
        collPlayer = GetComponent<PolygonCollider2D>(); 
        mySpriteRenderer = GetComponent<SpriteRenderer>();

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
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.65f), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHit)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyShot"))
            {
                Destroy(other.gameObject); //The collided object is destroyed 
                durability--; //The spaceship loses one point of durability
                isHit = true;
                StartCoroutine(Flash(flashSpeed, invunerabilityTime)); //Spaceship flashes by a specified speed and duration
            }
        }
        
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount++;
            coinQuant.text = coinCount.ToString();     
        }
    }

    IEnumerator Flash(float flash, int duration)
    {
        int counter = 0;
        //collPlayer.enabled = false;

        while (counter < duration)
        {
            counter++;
            mySpriteRenderer.enabled = false;
            yield return new WaitForSeconds(flash);

            mySpriteRenderer.enabled = true;
            yield return new WaitForSeconds(flash);
        }
        isHit = false;
        //collPlayer.enabled = true;
    }

}
