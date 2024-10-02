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
        InvokeRepeating(nameof(SpawnEnemy), 0, 2.5f);//consistently spawn 1 enemy every 2.5s
    }
    void Update()
    {
        spawnCounter += Time.deltaTime;//set a spawn timer min(0.05s) which gets ~10% quicker every 10s
        spawnRng = UnityEngine.Random.Range(0.85f, 1.15f);//spawn timer can vary + or - 15%
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


        if (Input.GetKeyDown(KeyCode.LeftArrow))//Manually spawn enemy for debug
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
