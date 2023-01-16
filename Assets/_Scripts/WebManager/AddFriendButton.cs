using UnityEngine;

public class AddFriendButton : MonoBehaviour
{
    public int playerID;
    public WebManager webManager;

    // Start is called before the first frame update
    void Start()
    {
        webManager = GameObject.Find("WebManager").GetComponent<WebManager>();
    }
    
    public void SendFriendRequest()
    {
        playerID = int.Parse(transform.parent.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text);
        StartCoroutine(webManager.SendFriendRequest(playerID));
    }
}
