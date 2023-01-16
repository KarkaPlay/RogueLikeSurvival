using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerData : MonoBehaviour
{
    public static CurrentPlayerData instance = null;
    
    public static string nickname;
    public static Color colorMain;
    public static Color colorSecond;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetData()
    {
        nickname = WebManager.userData.playerData.nickname;
        colorMain = JsonUtility.FromJson<Color>(WebManager.userData.playerData.colorMain);
        colorSecond = JsonUtility.FromJson<Color>(WebManager.userData.playerData.colorSecond);
    }
}
