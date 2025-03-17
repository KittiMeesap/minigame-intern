using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeLimit = 120f;
    private float timeRemaining;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeRemaining = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
