using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class comboManager : MonoBehaviour
{
    public static comboManager CM_Instance;

    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] comboTier startingTier;
    float currentComboPoints = 0;
    comboTier currentTier;
    public float currentMultiplier;
    [SerializeField] GameObject comboUI;
    [SerializeField] Slider comboMeter;
    [SerializeField] TMP_Text tierText;
    [SerializeField] TMP_Text multiplierText;
    [SerializeField] Image comboMeterBackground;
    [SerializeField] private float comboDecayPercentagePerSecond;

    private void Awake()
    {
        if (CM_Instance != null && CM_Instance != this)
        {
            Destroy(this);
        }
        else
        {
            CM_Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTier = startingTier;
        currentMultiplier = currentTier.pointMultiplier;
        UpdateUIText();
    }

    // Update is called once per frame
    void Update()
    {
        //If you have no combo going on
        if(currentTier.prevTier == null && currentComboPoints <= 0)
        {
            currentComboPoints = 0;
            comboUI.SetActive(false);
            return;
        }


        comboUI.SetActive(true);
        //If we can make it to the next tier, upgrade

        if (currentComboPoints >= currentTier.pointsRequiredToNext && currentTier.nextTier != null)
        {
            currentComboPoints -= currentTier.pointsRequiredToNext;
            currentTier = currentTier.nextTier;
            currentMultiplier = currentTier.pointMultiplier;
            UpdateUIText();

        }

        //Otherwise, if we have to downgrade, downgrade.
        else if(currentComboPoints <= 0 && currentTier.prevTier != null)
        {
            currentTier = currentTier.prevTier;
            currentMultiplier = currentTier.pointMultiplier;
            currentComboPoints += currentTier.pointsRequiredToNext;
            UpdateUIText();
        }



        //Decay the combo meter and update it
        currentComboPoints -= comboDecayPercentagePerSecond * currentTier.pointsRequiredToNext * Time.deltaTime;
        comboMeter.value = Mathf.Clamp(currentComboPoints / currentTier.pointsRequiredToNext,0,1);
    }

    public void GainComboPoints(float points)
    {
        currentComboPoints += points;
    }

    private void UpdateUIText()
    {
        multiplierText.text = "Multiplier - " + currentTier.pointMultiplier.ToString() + "x";
        tierText.text = currentTier.letterGradeText;
        comboMeterBackground.color = currentTier.comboMeterColor;
        multiplierText.color = currentTier.comboMeterColor;
        tierText.color = currentTier.comboMeterColor;
    }
}
