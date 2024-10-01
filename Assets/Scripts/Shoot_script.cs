using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_script : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float cdTime = 0.5f;
    void Update()
    {
        cdTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cdTime < 0)//shoot on 1s cd
            {
                Shoot();
                cdTime = 0.5f;
            }            
        }
    }
    void Shoot()
    {
        //generate a new bullet from the prefab
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0);
    }
}
