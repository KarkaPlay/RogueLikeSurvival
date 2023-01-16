using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterLoader : MonoBehaviour
{
    public Renderer rend;
    public Renderer backpackRend;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        
        //Debug.Log("Изначальный цвет: " + rend.material.color);
        
        rend.material.color = CurrentPlayerData.colorMain;
        backpackRend.material.color = CurrentPlayerData.colorSecond;
        
        //rend.material.SetColor("Color", Color.blue);
        
        //Debug.Log("Новый цвет на JSON: " + CurrentPlayerData.colorMain);
        //Debug.Log("Новый цвет: " + rend.material.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
