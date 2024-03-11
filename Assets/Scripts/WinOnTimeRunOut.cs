using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOnTimeRunOut : MonoBehaviour
{
    public float timeRemaining = 120;
    public TMP_Text timerText;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        } else
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = "Win Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
