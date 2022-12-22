using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private WebManager webManager;
    
    public void LoadData()
    {
        nicknameInput.text = WebManager.userData.playerData.nickname;
        playerNameText.text = WebManager.userData.playerData.nickname;
    }
    
    public void SaveData()
    {
        var player = WebManager.userData.playerData;
        webManager.SaveData(player.id, player.nickname, player.colorMain, player.colorSecond);
    }
}
