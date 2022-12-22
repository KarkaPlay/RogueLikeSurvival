using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private TMP_Text nicknameText;
    [SerializeField] private TMP_Text playerNameText;
    
    public void ChangeNickname(TMP_Text newNickname)
    {
        nicknameText.text = newNickname.text;
        playerNameText.text = newNickname.text;
        WebManager.userData.playerData.nickname = newNickname.text;
    }
}
