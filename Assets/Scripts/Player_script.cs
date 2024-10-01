using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    public float playerSpeed = 4f; //define and init player speed

    private void Update()
    {
        //get current pos
        Vector3 playerPos = transform.position;
        ////change the vector pos
        if (playerPos.y < 5)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                playerPos.y += playerSpeed * Time.deltaTime;
            }
        }
        if (playerPos.y > -5)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                playerPos.y -= playerSpeed * Time.deltaTime;
            }
        }
        transform.position = playerPos; //move the bomber to new pos
    }
    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Enemy"))
        {
            Blaster_script.instance.UpdateHp();
            Destroy(collision.gameObject);
        }
    }
}
