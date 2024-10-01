using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_script : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRng;
    public float spawnInterval;
    private float spawnTime = 10f;
    public float spawnCounter = 0;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, 2.5f);
    }
    void Update()
    {
        spawnCounter += Time.deltaTime;
        spawnRng = UnityEngine.Random.Range(0.85f, 1.15f);
        spawnInterval = Mathf.Pow(0.90f, Time.timeSinceLevelLoad / 10f);
        if (spawnRng * spawnInterval < 0.05f)
        {
            spawnInterval = 0.05f;
        }
        else
        {
            spawnInterval *= spawnRng;
        }
        if(spawnCounter > spawnTime * spawnInterval)
        {
            SpawnEnemy();
            spawnCounter = 0;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))//Manually spawn enemy for debug
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        //generate a new enemy from the prefab
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = new Vector3(10f, UnityEngine.Random.Range(-5f, 5f), 0);
    }
}
