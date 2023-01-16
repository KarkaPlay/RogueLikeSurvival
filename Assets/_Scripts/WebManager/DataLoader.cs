using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private WebManager webManager;
    [SerializeField] private Palette colorMain, colorSecond;
    [Space] [SerializeField] private Color startColorMain, startColorSecond;
    
    public void LoadData()
    {
        nicknameInput.text = WebManager.userData.playerData.nickname;
        playerNameText.text = WebManager.userData.playerData.nickname;

        if (WebManager.userData.playerData.colorMain != "Null")
        {
            colorMain.SetImageColor(JsonUtility.FromJson<Color>(WebManager.userData.playerData.colorMain));
        }
        else
        {
            colorMain.SetImageColor(startColorMain);
        }
        
        if (WebManager.userData.playerData.colorSecond != "Null")
        {
            colorSecond.SetImageColor(JsonUtility.FromJson<Color>(WebManager.userData.playerData.colorSecond));
        }
        else
        {
            colorSecond.SetImageColor(startColorSecond);
        }
    }
    
    public void SaveData()
    {
        var player = WebManager.userData.playerData;
        webManager.SaveData(player.id, player.nickname, player.colorMain, player.colorSecond);
    }
}
