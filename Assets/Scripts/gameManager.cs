using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField] Slider slide;
    [SerializeField] int maxTime;

    [Header("Countdown")]
    [SerializeField] Image main;
    [SerializeField] Sprite three;
    [SerializeField] Sprite two;
    [SerializeField] Sprite one;
    [SerializeField] GameObject slay;

    [SerializeField] Animator endUI;

    [SerializeField] GameObject summaryPage;


    bool startGame;

    private void Start()
    {
        slide.maxValue = maxTime;
        slide.value = maxTime;
        startSequence();
        summaryPage.SetActive(false);
        startGame = false;

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
        GameObject.FindGameObjectWithTag("Player").GetComponent<carController>().enabled = false;
        StartCoroutine(count());
    }

    private void endGame()
    {
        endUI.SetBool("end", true);
        StartCoroutine(summary());
    }

    IEnumerator count()
    {
        main.gameObject.SetActive(true);
        main.sprite = three;
        yield return new WaitForSeconds(1f);
        main.sprite = two;
        yield return new WaitForSeconds(1f);
        main.sprite = one;
        yield return new WaitForSeconds(1f);
        main.gameObject.SetActive(false);
        slay.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<carController>().enabled = true;
        startGame = true;
        yield return new WaitForSeconds(1f);
        slay.SetActive(false);
    }

    IEnumerator summary()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<carController>().enabled = false;
        yield return new WaitForSeconds(3f);
        summaryPage.SetActive(true);
    }



}
