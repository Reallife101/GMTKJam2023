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

    private void OnEnable()
    {
        slain.text = "Slain: " + pm.totalSlain;
        points.text = "Points: " + pm.totalPoints;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
