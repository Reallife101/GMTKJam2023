using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bloodSplatter : MonoBehaviour
{
    [SerializeField] private float bloodFadeTime;
    float fadeTimeLeft = 0;
    [SerializeField] private Image splatter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeTimeLeft -= Time.deltaTime;
        //fadeTimeLeft = Mathf.Clamp(fadeTimeLeft, 0, bloodFadeTime);
        float newAlpha = Mathf.Lerp(0, 0.8f, fadeTimeLeft / bloodFadeTime);
        splatter.color = new Color(255, 255, 255, newAlpha);
    }

    public void RefreshSplatter()
    {
        fadeTimeLeft = bloodFadeTime;
    }
}
