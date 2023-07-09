using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class endGameUI : MonoBehaviour
{
    [SerializeField] pointManager pm;
    [SerializeField] TMP_Text slain;
    [SerializeField] TMP_Text points;
    [SerializeField] TMP_Text hs;

    private void OnEnable()
    {
        slain.text = "Slain: " + pm.totalSlain;
        points.text = "Points: " + pm.totalPoints;
        highScore.Instance.SetScore(pm.totalPoints);
        hs.text = "High Score: " + highScore.Instance.maxScore;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void next()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
