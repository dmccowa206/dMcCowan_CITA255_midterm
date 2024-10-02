using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    public float enemySpeed;
    private Vector3 enemyPos;
    void Start()
    {
        enemySpeed = UnityEngine.Random.Range(1.5f, 5f);//randomize initial speed
    }

    void Update()
    {
        enemySpeed += UnityEngine.Random.Range(-0.02f, 0.02f);//speed changes a small random amount every frame
        enemyPos = transform.position;
        if (enemyPos.x < -12f)
        {//if enemy goes off the left side of the screen, it jumps back to the right
            enemyPos.x = 12f;
            enemySpeed += 0.5f;//and speeds up
            transform.position = enemyPos;
        }
        enemyPos.x -= enemySpeed * Time.deltaTime;//moves left at speed
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
