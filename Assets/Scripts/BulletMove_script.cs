using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove_script : MonoBehaviour
{
    public float bulletSpeed = 16f;
    void Update()
    {
        //get current pos
        Vector3 bulletPos = transform.position;
        if (bulletPos.x > 12f)//destroy bullet if offscreen
        {
            Destroy(gameObject);
        }

        //change the vector pos
        bulletPos.x += bulletSpeed * Time.deltaTime;//Time.deltaTime is the interval in frames

        transform.position = bulletPos; //move the bullet to new pos

    }
  
}
