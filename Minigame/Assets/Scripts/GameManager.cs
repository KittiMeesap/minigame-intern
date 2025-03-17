using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public float currentTime;
    public float timeLimit = 120f;
    private float timeRemaining;

    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0f;
        timeRemaining = timeLimit;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                PlayerLose(false);

            }
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    public void ResetTime(float checkPointTime)
    {
        timeRemaining = checkPointTime;
        currentTime = checkPointTime;
    }

    public float GetRemainTime()
    {
        return timeRemaining;
    }

    public void PlayerWin()
    {
        if (!gameEnd)
        {
            gameEnd = true;
            winPanel.SetActive(true);
        }
    }

    public void PlayerLose(bool win)
    {
        if (!gameEnd)
        {
            gameEnd = true;
            losePanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
