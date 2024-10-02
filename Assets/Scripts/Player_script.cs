using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    public float playerSpeed = 4.5f; //define and init player speed

    private void Update()
    {
        //get current pos
        Vector3 playerPos = transform.position;
        if (playerPos.y < 5)//only move if within the screen bounds
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                playerPos.y += playerSpeed * Time.deltaTime;//change the vector pos
            }
        }
        if (playerPos.y > -5)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                playerPos.y -= playerSpeed * Time.deltaTime;
            }
        }
        transform.position = playerPos; //move the player to new pos
    }
    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Enemy"))//If enemy collides with player
        {
            Blaster_script.instance.UpdateHp();//reduce hp
            Destroy(collision.gameObject);//destroy enemy
        }
    }
}
