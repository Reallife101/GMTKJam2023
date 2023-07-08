using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointManager : MonoBehaviour
{
    [SerializeField] int totalPoints;
    [SerializeField] TMP_Text score;
    [SerializeField] CinemachineShake cs;

    private void Start()
    {
        totalPoints = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If it has pointValues, kill it and gain points
        pointValue pv = collision.gameObject.GetComponent<pointValue>();

        if (pv)
        {
            totalPoints += pv.points;
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
