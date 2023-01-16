using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateUsersTable : MonoBehaviour
{
    public GameObject userRowPrefab;
    public GameObject requestRowPrefab;
    public TMP_Text searchField;
    public bool isShowing = false;

    public void GenerateTable(Player[] players, bool isSearching=false, bool friends=false)
    {
        if (isShowing && !isSearching)
        {
            CloseTable();
        }
        else
        {
            gameObject.SetActive(true);
            isShowing = true;
            if (isSearching)
            {
                ClearTable();
            }

            if (friends)
            {
                foreach (Player player in players)
                {
                    GameObject requestRow = Instantiate(requestRowPrefab, transform);
                    requestRow.GetComponent<RequestRow>().SetPlayer(player);
                }
            }
            else
            {
                foreach (Player player in players)
                {
                    GameObject userRow = Instantiate(userRowPrefab, transform);
                    userRow.GetComponent<UserRow>().SetPlayer(player);
                }
            }
            
        }
    }

    public void CloseTable()
    {
        gameObject.SetActive(false);
        isShowing = false;
        ClearTable();
    }
    
    public void ClearTable()
    {
        for (int i = 2; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
