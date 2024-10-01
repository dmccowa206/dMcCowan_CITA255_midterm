using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    public float enemySpeed;
    void Start()
    {
        enemySpeed = UnityEngine.Random.Range(1.5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        enemySpeed += UnityEngine.Random.Range(-0.02f, 0.02f);
        Vector3 enemyPos = transform.position;
        if (enemyPos.x < -12f)
        {
            enemyPos.x = 12f;
            enemySpeed += 0.25f;
            transform.position = enemyPos;
        }
        enemyPos.x -= enemySpeed * Time.deltaTime;
        transform.position = enemyPos;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))// if collision is between bullet and enemy
        {
            Blaster_script.instance.UpdateScore();
            Debug.Log("Score: " + Blaster_script.instance.score);
            Destroy(gameObject);//destroy enemy first
            Destroy(collision.gameObject);//destroy the bullet
        }
    }
}
