using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{

    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        HealthSystemForDummies healthSystem = GameObject.FindGameObjectWithTag("Ground").gameObject.GetComponent<HealthSystemForDummies>();
        if (healthSystem.CurrentHealth >= 100){
        
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }    
    }

    void Shoot()
    {
         Vector3 myVector = new 
        Vector3(0.0f, 0.0f, 0.0f);
        GameObject egg =
        Instantiate<GameObject>(bulletPrefab);
         egg.transform.position = 
        transform.position + myVector;
       

        HealthSystemForDummies healthSystem = GameObject.FindGameObjectWithTag("Ground").gameObject.GetComponent<HealthSystemForDummies>();

        healthSystem.AddToCurrentHealth(-100);
        
       
 

        

    }
}

