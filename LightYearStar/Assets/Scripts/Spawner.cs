using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public bool stage0 = true;
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;
    public bool stage4 = false;

    public float distance = 0f;

    public float spawnTime = 3f;
    public GameObject enemy;
    public GameObject coin;

    private float sizeX, sizeY;
    private float screenRatio = (float)Screen.width / (float)Screen.height;
    // Use this for initialization
    void Start ()
    {
        sizeX = Camera.main.orthographicSize * screenRatio;
        sizeY = Camera.main.orthographicSize;

        StartCoroutine(SpawnRot());
        StartCoroutine(spawnCoin());
    }

    IEnumerator spawnCoin()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3,15)); //The coins will show up between 3 and 15 seconds
            float posX = Random.Range(sizeX - 0.5f, -sizeX + 0.5f);
            float posY = sizeY + 0.6f;

            float choice = Random.Range(1, 10);
            Debug.Log(choice);
            if (choice<5)
                coinNine(posX, posY);
            else
                coinTwelve(posX, posY);
            
        }
        
    }

    void coinNine(float posX, float posY)
    {
        Instantiate(coin, new Vector2(posX, posY), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY), Quaternion.identity);
        Instantiate(coin, new Vector2(posX - 0.8f, posY), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 0.8f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 0.8f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX - 0.8f, posY - 0.8f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 1.6f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 1.6f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX - 0.8f, posY - 1.6f), Quaternion.identity);
    }
    
    void coinTwelve(float posX, float posY)
    {
        Instantiate(coin, new Vector2(posX, posY), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 0.8f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 0.8f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 1.6f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 1.6f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 2.4f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 2.4f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 3.2f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 3.2f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX, posY - 4f), Quaternion.identity);
        Instantiate(coin, new Vector2(posX + 0.8f, posY - 4f), Quaternion.identity);
    }

    IEnumerator SpawnRot()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            AddBasicEnemy();
        }
    }
    
    void AddBasicEnemy()
    {
        Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
        /*
        if((stage0)||(stage1))
        { 
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);

        }
        
        if(stage2)
        {
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
        }
        if(stage3)
        {
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
        }
        if(stage4)
        {
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
            Instantiate(enemy, new Vector2(Random.Range(sizeX - 0.5f, -sizeX + 0.5f), sizeY + 0.6f), Quaternion.identity);
        */

    }      

    // Update is called once per frame
    void Update ()
    {
        distance = Time.deltaTime + distance;
        if ((distance > 20)&&(stage1==false))
        {
            spawnTime = spawnTime - 0.1f;
            stage1 = true;
        }
        else
            if ((distance > 50) && (stage2 == false))
        {
            spawnTime = spawnTime - 0.1f;
            stage2 = true;
        }
        else
            if ((distance > 70) && (stage3 == false))
        {
            spawnTime = spawnTime - 0.1f;
            stage3 = true;
        }
        else
            if ((distance > 100) && (stage4 == false))
        {
            spawnTime = spawnTime - 0.1f;
            stage4 = true;
        }
    }
}
