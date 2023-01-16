using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStore : MonoBehaviour
{
    public static GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}