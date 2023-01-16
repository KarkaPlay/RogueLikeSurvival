using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private TMP_Text nicknameText;
    [SerializeField] private TMP_Text playerNameText;
    
    //[SerializeField] private Renderer colorMain, colorSecond;
    
    public void ChangeNickname(TMP_Text newNickname)
    {
        nicknameText.text = newNickname.text;
        playerNameText.text = newNickname.text;
        WebManager.userData.playerData.nickname = newNickname.text;
    }
    
    public void ChangeColorMain(Palette newColor)
    {
        //colorMain.material.color = newColor.GetColor();
        WebManager.userData.playerData.SetMainColor(JsonUtility.ToJson(newColor.GetColor()));
    }
    
    public void ChangeColorSecond(Palette newColor)
    {
        //colorSecond.material.color = newColor.GetColor();
        WebManager.userData.playerData.SetSecondColor(JsonUtility.ToJson(newColor.GetColor()));
    }
}
