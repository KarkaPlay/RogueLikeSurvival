using UnityEngine;
using UnityEngine.UI;

public class WebButton : MonoBehaviour
{
    public void ButtonClick()
    {
        GetComponent<Button>().onClick.Invoke();
    }
}
