using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // при столкновении с врагом damage оружия уменьшается на здоровье врага
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damage -= collision.gameObject.GetComponent<EnemyController>().HP;
            if (damage <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
