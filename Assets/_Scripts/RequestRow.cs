using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestRow : MonoBehaviour
{
    [SerializeField] private TMP_Text id;
    [SerializeField] private TMP_Text nickname;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button declineButton;
    
    [SerializeField] private WebManager webManager;
    
    private int friendID;

    private void Start()
    {
        webManager = GameObject.Find("WebManager").GetComponent<WebManager>();
    }

    public void SetPlayer(Player player)
    {
        id.text = player.id.ToString();
        nickname.text = player.nickname;
        friendID = player.id;
        acceptButton.onClick.AddListener(() => AcceptFriendRequest(int.Parse(id.text)));
        declineButton.onClick.AddListener(() => DeclineFriendRequest(int.Parse(id.text)));
    }

    public void AcceptFriendRequest(int friendID)
    {
        webManager.AcceptFriendRequest(friendID);
    }

    public void DeclineFriendRequest(int friendID)
    {
        webManager.DeclineFriendRequest(friendID);
    }
}
