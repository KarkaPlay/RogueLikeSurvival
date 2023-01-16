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

    
    [System.Serializable]
    public class MenuLogin
    {
        public TMP_Text login, password;
    }
    
    [System.Serializable]
    public class MenuRegistration
    {
        public TMP_Text login, password, password2, nickname;
    }
    
    public MenuLogin menuLogin;
    public MenuRegistration menuRegistration;
    
    [SerializeField] private WebManager webManager;
    
    public void Login()
    {
        webManager.Login(menuLogin.login.text, menuLogin.password.text);
    }
    
    public void Registration()
    {
        webManager.Registration(menuRegistration.login.text, menuRegistration.password.text, menuRegistration.password2.text, menuRegistration.nickname.text);
    }

    // Start is called before the first frame update
    private void Start()
    {
        buttons.Add(startButton);
        buttons.Add(settingsButton);
        buttons.Add(exitButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
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