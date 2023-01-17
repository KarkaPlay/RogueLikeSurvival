using UnityEngine;

public class CharachterLoader : MonoBehaviour
{
    public Renderer rend;
    public Renderer backpackRend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = CurrentPlayerData.colorMain;
        backpackRend.material.color = CurrentPlayerData.colorSecond;
    }
}
