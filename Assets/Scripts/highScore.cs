using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScore : MonoBehaviour
{
    public static highScore Instance { get; private set; }
    public int maxScore { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            maxScore = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        if (score > maxScore)
        {
            maxScore = score;
        }
    }
}
