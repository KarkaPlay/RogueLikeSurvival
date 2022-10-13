using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;

    public TMP_Text Header;

    private List<Button> buttons = new List<Button>();

    // Start is called before the first frame update
    private void Start()
    {
        buttons.Add(startButton);
        buttons.Add(settingsButton);
        buttons.Add(exitButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        
    }

    public void ShowSettings()
    {
        Header.text = "Settings";
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}