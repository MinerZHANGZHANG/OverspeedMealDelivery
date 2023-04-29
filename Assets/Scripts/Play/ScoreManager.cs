using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int CurrentScore = 0;
    public enum ScoreSource
    {
        DeliveryFood,

    }

    public static void AddScore(ScoreSource source,int value)
    {
        CurrentScore += value;
        Debug.Log($"Current Score:{CurrentScore}");
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
