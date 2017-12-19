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

    private float sizeX, sizeY;
    private float screenRatio = (float)Screen.width / (float)Screen.height;
    // Use this for initialization
    void Start ()
    {
        sizeX = Camera.main.orthographicSize * screenRatio;
        sizeY = Camera.main.orthographicSize;

        StartCoroutine(SpawnRot());
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
        }
            
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
