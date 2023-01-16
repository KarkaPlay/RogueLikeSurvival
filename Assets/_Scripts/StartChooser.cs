using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartChooser : MonoBehaviour
{
    public GameObject CanvasStart;

    public Button Equipment1;
    public Button Equipment2;
    public Button Equipment3;

    public GameObject Sword;
    public GameObject Scythe;
    public GameObject Spear;

    public GameObject Bow;
    public GameObject Crossbow;
    public GameObject Axe;

    public GameObject Holy;
    public GameObject Defender;
    public GameObject DefHat;
    public GameObject Meteorit;

    // Start is called before the first frame update
    private void Awake()
    {
        CanvasStart.SetActive(true);
        Time.timeScale = 0;
        Sword.SetActive(false);
        Scythe.SetActive(false);
        Spear.SetActive(false);
        Bow.SetActive(false);
        Crossbow.SetActive(false);
        Axe.SetActive(false);
        Holy.SetActive(false);
        Defender.SetActive(false);
        DefHat.SetActive(false);
        Meteorit.SetActive(false);

        Equipment1.onClick.AddListener(ActivateFirst);
        Equipment2.onClick.AddListener(ActivateSecond);
        Equipment3.onClick.AddListener(ActivateThird);
    }

    // Update is called once per frame
    private void ActivateFirst()
    {
        Sword.SetActive(true);
        Bow.SetActive(true);
        Holy.SetActive(true);
        Time.timeScale = 1;
        CanvasStart.SetActive(false);
    }

    private void ActivateSecond()
    {
        Spear.SetActive(true);
        Crossbow.SetActive(true);
        Meteorit.SetActive(true);
        Time.timeScale = 1;
        CanvasStart.SetActive(false);
    }

    private void ActivateThird()
    {
        Scythe.SetActive(true);
        Axe.SetActive(true);
        Defender.SetActive(true);
        DefHat.SetActive(true);
        Time.timeScale = 1;
        CanvasStart.SetActive(false);
    }
}