using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointManager : MonoBehaviour
{
    public int totalPoints;
    [SerializeField] TMP_Text score;
    [SerializeField] CinemachineShake cs;

    public int totalSlain;

    private void Start()
    {
        totalPoints = 0;
        totalSlain = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If it has pointValues, kill it and gain points
        pointValue pv = collision.gameObject.GetComponent<pointValue>();

        if (pv)
        {
            int pointsGained = (int)(pv.points * comboManager.CM_Instance.currentMultiplier);
            totalPoints += pointsGained;
            totalSlain += 1;
            comboManager.CM_Instance.GainComboPoints(pointsGained);
            pv.die();
            updateScoreUI();
            if (cs)
            {
                cs.ShakeCamera();
            }
        }
    }

    private void updateScoreUI()
    {
        score.text = "Points: " + totalPoints;
    }
}
