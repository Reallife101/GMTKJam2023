using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField] Slider slide;
    [SerializeField] int maxTime;

    bool startGame;

    private void Start()
    {
        slide.maxValue = maxTime;
        slide.value = maxTime;
        startSequence();

    }

    private void Update()
    {
        if (startGame)
        {
            slide.value = slide.value - Time.deltaTime;
        }

        if (slide.value <= 0)
        {
            endGame();
        }
    }

    private void startSequence()
    {
        startGame = true;
    }

    private void endGame()
    {

    }


}
