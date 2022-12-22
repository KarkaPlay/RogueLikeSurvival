using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public bool needToMove = false;
    public int value = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if (needToMove)
        {
            Move();
        }
    }*/
    
    // Объект движется к игроку
    void Move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, 5f * Time.deltaTime);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LvlUps>().CollectExp(this.gameObject);
        }
    }*/
}
