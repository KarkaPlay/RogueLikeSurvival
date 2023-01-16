using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Slider expSlider;
    public TMP_Text timeValue;
    public int levelUpCondition = 5;
    public int currentExp = 0;
    private float survivalTime = 0;

    public SwordMeleeCombat sword;
    public SpearMeleeCombat spear;
    public ScythMeleeCombat scyth;

    public BowRangeCombat bow;
    public CrossbowRangeCombat crossbow;
    public AxeThrower axe;

    public HolyMagic holyMagic;
    public FlyingDefender flyingDefender;
    public MeteoritGenerator meteoritGenerator;

    public GameObject improveCanvas;
    public Button improveMeleeButton;
    public Button improveRangeButton;
    public Button improveMagicButton;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentExp = 0;
        survivalTime = 0;
        expSlider.value = (float)currentExp / levelUpCondition;

        improveCanvas.SetActive(false);
        improveMeleeButton.onClick.AddListener(ImproveMelee);
        improveRangeButton.onClick.AddListener(ImproveRange);
        improveMagicButton.onClick.AddListener(ImproveMagic);
    }

    // Update is called once per frame
    private void Update()
    {
        timeValue.text = Time.timeSinceLevelLoad.ToString();
    }

    public void UpExp()
    {
        currentExp++;

        if (currentExp == levelUpCondition)
        {
            Debug.Log("lvl up");
            levelUpCondition += 5;
            Time.timeScale = 0;
            improveCanvas.SetActive(true);

            currentExp = 0;
        }
        expSlider.value = (float)currentExp / levelUpCondition;
    }

    private void ImproveMelee()
    {
        sword.Improve();
        spear.Improve();
        scyth.Improve();
        Time.timeScale = 1;
        improveCanvas.SetActive(false);
    }

    private void ImproveRange()
    {
        bow.Improve();
        crossbow.Improve();
        axe.Improve();
        Time.timeScale = 1;
        improveCanvas.SetActive(false);
    }

    private void ImproveMagic()
    {
        holyMagic.Improve();
        meteoritGenerator.Improve();
        flyingDefender.Improve();
        Time.timeScale = 1;
        improveCanvas.SetActive(false);
    }
}