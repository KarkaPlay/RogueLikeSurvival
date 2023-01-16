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
    [SerializeField] private string getUsersURL;
    [SerializeField] private string sendFriendRequestURL;
    [SerializeField] private string acceptFriendRequestURL;
    [SerializeField] private string declineFriendRequestURL;

    [SerializeField] private UnityEvent OnLoginSuccess, OnRegisterSuccess;
    public GenerateUsersTable generateUsersTable; 
    public FriendRequestsButton friendRequestsButton;
    
    public enum RequestType
    {
        logging, register, save, get_all_users, search_user, friend_requests
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
    
    public void GetAllUsers(GenerateUsersTable generateUsersTable)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.get_all_users.ToString());
        StartCoroutine(SendData(form, RequestType.get_all_users, generateUsersTable));
    }

    public void SearchUser(GenerateUsersTable generateUsersTable)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.search_user.ToString());
        form.AddField("nickname", generateUsersTable.searchField.text);
        StartCoroutine(SendData(form, RequestType.search_user, generateUsersTable));
    }
    
    public void GettingFriendRequests()
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.friend_requests.ToString());
        form.AddField("user_id", userData.playerData.id);
        StartCoroutine(GetFriendshipRequests(form, generateUsersTable));
    }
    
    private IEnumerator GetFriendshipRequests(WWWForm form, GenerateUsersTable generateUsersTable)
    {
        UnityWebRequest www = UnityWebRequest.Post(getUsersURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Player[] players = FromJSONToPlayers(www.downloadHandler.text);
            generateUsersTable.GenerateTable(players, false, true);
        }
    }
    
    public void AcceptFriendRequest(int friendID)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", userData.playerData.id);
        form.AddField("friend_id", friendID);
        StartCoroutine(SendData(form, acceptFriendRequestURL));
    }

    public void DeclineFriendRequest(int friendID)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", userData.playerData.id);
        form.AddField("friend_id", friendID);
        StartCoroutine(SendData(form, declineFriendRequestURL));
    }

    private Player[] FromJSONToPlayers(string json)
    {
        json = json.Replace("0.0}", "0.0@");
        json = json.Replace("1.0}", "1.0@");
        Debug.Log(json);

        string[] jsons = json.Split("}");
        Player[] players = new Player[jsons.Length - 1];
        for (int i = 0; i < jsons.Length - 1; i++)
        {
            string jsonPlayer = jsons[i].Substring(1, jsons[i].Length - 1) + "}";
            jsonPlayer = jsonPlayer.Replace("@", "}");
            players[i] = JsonUtility.FromJson<Player>(jsonPlayer);
        }

        return players;
    }
    
    private IEnumerator SendData(WWWForm form, string url)
    {
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
    
    private IEnumerator SendData(WWWForm form, RequestType requestType, GenerateUsersTable generateUsersTable)
    {
        UnityWebRequest www = UnityWebRequest.Post(getUsersURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            switch (requestType)
            {
                case RequestType.get_all_users:
                    generateUsersTable.GenerateTable(FromJSONToPlayers(www.downloadHandler.text));
                    break;
                case RequestType.search_user:
                    generateUsersTable.GenerateTable(FromJSONToPlayers(www.downloadHandler.text), true);
                    break;
            }
            
        }
    }
    

    IEnumerator SendData(WWWForm form, RequestType type)
    {
        using UnityWebRequest www = UnityWebRequest.Post(targetURL, form);

        yield return www.SendWebRequest();
        Debug.Log("SendData");

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Ошибка");
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
                            friendRequestsButton.CheckFriendshipRequests();
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
    
    public IEnumerator SendFriendRequest(int friendID)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", userData.playerData.id);
        form.AddField("friend_id", friendID);
        
        UnityWebRequest www = UnityWebRequest.Post(sendFriendRequestURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Friend request sent!");
        }
    }
}
