using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSphere : MonoBehaviour
{
    private static int a = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            a++;
            Debug.Log(a);
            ScoreManager.Instance.UpExp();
            Destroy(gameObject);
        }
    }
}