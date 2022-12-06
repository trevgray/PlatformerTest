using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timer = 0.0f;
    public bool timerOn = true;

    public TMP_Text HUDTimerUI;
    public TMP_Text levelCompleteUI;
    public TMP_Text gameOverUI;
    public HighScoreManager highScoreManager;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            timer += Time.deltaTime;
            HUDTimerUI.text = "Timer " + Mathf.Round(timer * 100f) / 100f;
        }
    }

    public void ToggleDeathScreen()
    {
        StopTimer();
        playerController.isAlive = false;
        gameOverUI.gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        timerOn = false;
    }

    public void SwitchToTitleScreen()
    {
        SceneManager.LoadScene("Assets/Scenes/TitleScreen.unity");
    }

    public void EndLevelScreen()
    {
        StopTimer();
        playerController.isAlive = false;
        HUDTimerUI.gameObject.SetActive(false);

        TMP_Text YourTime = null;
        TMP_Text BestTime = null;
        foreach (TMP_Text textComponent in levelCompleteUI.GetComponentsInChildren<TMP_Text>())
        {
            if (textComponent.name == "YourTime")
            {
                YourTime = textComponent;
            }
            if (textComponent.name == "BestTime")
            {
                BestTime = textComponent;
            }
        }
        float roundedTime = Mathf.Round(timer * 100f) / 100f;

        YourTime.text = "Your Time: " + roundedTime.ToString();
        BestTime.text = "Best Time: " + highScoreManager.scores[0].ToString();

        highScoreManager.SubmitNewScore(roundedTime.ToString());
        levelCompleteUI.gameObject.SetActive(true);
    }
}
