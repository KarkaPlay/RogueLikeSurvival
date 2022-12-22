using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUps : MonoBehaviour
{
    public int lvl = 0;
    public int exp = 0;
    public int expToLvlUp = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Exp"))
        {
            CollectExp(other.gameObject);
        }
    }

    public void CollectExp(GameObject expGameObject)
    {
        exp += expGameObject.GetComponent<Exp>().value;
        Destroy(expGameObject);
        
        if (exp >= expToLvlUp)
        {
            lvl++;
            exp -= expToLvlUp;
            expToLvlUp += 100;
        }
    }
}
