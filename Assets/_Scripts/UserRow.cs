using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserRow : MonoBehaviour
{
    [SerializeField] private TMP_Text id;
    [SerializeField] private TMP_Text nickname;
    [SerializeField] private GameObject colorMain;
    [SerializeField] private GameObject colorSecond;

    public void SetPlayer(Player player)
    {
        id.text = player.id.ToString();
        nickname.text = player.nickname;
        Debug.Log(player.colorMain);
        
        // Если colorMain == "Null", то присваиваем черный цвет
        if (player.colorMain == "Null")
            colorMain.GetComponent<Image>().color = Color.black;
        else
            colorMain.GetComponent<Image>().color = JsonUtility.FromJson<Color>(player.colorMain);

        // То же самое с colorSecond
        if (player.colorSecond == "Null")
            colorSecond.GetComponent<Image>().color = Color.black;
        else
            colorSecond.GetComponent<Image>().color = JsonUtility.FromJson<Color>(player.colorSecond);
    }
}
