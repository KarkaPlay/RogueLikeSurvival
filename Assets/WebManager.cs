using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class UserData
{
    public Player playerData;
    public Error error;
}

[System.Serializable]
public class Error
{
    public string errorText;
    public bool isError;
}

[System.Serializable]
public class Player
{
    public int id;
    public string nickname;
    public string colorMain;
    public string colorSecond;

    public Player(string nickname, string colorMain, string colorSecond)
    {
        this.nickname = nickname;
        this.colorMain = colorMain;
        this.colorSecond = colorSecond;
    }

    public void SetMainColor(string color) => colorMain = color;
    public void SetSecondColor(string color) => colorSecond = color;
    public void SetNickname(string name) => nickname = name;
}

[System.Serializable]
public class WebManager : MonoBehaviour
{
    public static UserData userData = new UserData();
    [SerializeField] private string targetURL;
    
    [SerializeField] private UnityEvent OnLoginSuccess, OnRegisterSuccess;
    
    public enum RequestType
    {
        logging, register, save
    }

    public string GetUserData(UserData data)
    {
        return JsonUtility.ToJson(data);
    }
    
    public UserData SetUserData(string data)
    {
        return JsonUtility.FromJson<UserData>(data);
    }

    private void Start()
    {
        userData.error = new Error() {errorText = "text", isError = true};
        userData.playerData = new Player ("Player1", "", "");
        print(GetUserData(userData));
    }

    public void Login(string login, string password)
    {
        StopAllCoroutines();
        Logging(login, password);
    }
    
    public void Registration(string login, string password1, string password2, string nickname)
    {
        StopAllCoroutines();
        Registering(login, password1, password2, nickname);
    }

    public void SaveData(int id, string nickname, string colorMain, string colorSecond)
    {
        StopAllCoroutines();
        Saving(id, nickname, colorMain, colorSecond);
    }

    public void Logging(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.logging.ToString());
        form.AddField("login", login);
        form.AddField("password", password);
        StartCoroutine(SendData(form, RequestType.logging));
    }
    
    public void Registering(string login, string password1, string password2, string nickname)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.register.ToString());
        form.AddField("login", login);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        form.AddField("nickname", nickname);
        StartCoroutine(SendData(form, RequestType.register));
    }
    
    public void Saving(int id, string nickname, string colorMain, string colorSecond)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.save.ToString());
        form.AddField("id", id);
        form.AddField("nickname", nickname);
        form.AddField("colorMain", colorMain);
        form.AddField("colorSecond", colorSecond);
        StartCoroutine(SendData(form, RequestType.save));
    }

    IEnumerator SendData(WWWForm form, RequestType type)
    {
        using UnityWebRequest www = UnityWebRequest.Post(targetURL, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var data = SetUserData(www.downloadHandler.text);
            if (!data.error.isError)
            {
                if (type != RequestType.save)
                {
                    userData = data;
                    switch (type)
                    {
                        case RequestType.logging:
                            OnLoginSuccess.Invoke();
                            break;
                        case RequestType.register:
                            OnRegisterSuccess.Invoke();
                            break;
                    }
                }
            }
            else
            {
                userData = data;
            }
        }
    }
}
