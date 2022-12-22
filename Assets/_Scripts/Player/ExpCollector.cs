using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Если в триггер попадает объект с тегом "Exp", то он притягивается к центру триггера
public class ExpCollector : MonoBehaviour
{
    public float radius = 3f;
    public float force = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(radius, radius, radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeRadius(float newRadius)
    {
        radius = newRadius;
        transform.localScale = new Vector3(radius, radius, radius);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            // Объект с тегом "Exp" плавно притягивается к центру триггера
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, transform.position, force * Time.deltaTime);
        }
    }
}
