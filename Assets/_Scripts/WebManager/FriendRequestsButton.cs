using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendRequestsButton : MonoBehaviour
{
    public Button requestsButton;
    public string checkfriendrequestsURL;

    private void Start()
    {
        CheckForFriendshipRequests();
    }
    
    public void CheckFriendshipRequests()
    {
        gameObject.SetActive(true);
        StartCoroutine(CheckForFriendshipRequests());
    }

    private IEnumerator CheckForFriendshipRequests()
    {
        string userId = WebManager.userData.playerData.id.ToString();
        
        WWWForm form = new WWWForm();
        form.AddField("user_id", userId);
        
        UnityWebRequest www = UnityWebRequest.Post(checkfriendrequestsURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.downloadHandler.text == "true")
            {
                requestsButton.gameObject.SetActive(true);
            }
            else
            {
                requestsButton.gameObject.SetActive(false);
            }
        }
    }
}