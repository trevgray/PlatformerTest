using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer = 0.0f;
    public bool timerOn = true;

    public TMP_Text HUDTimerUI;
    public TMP_Text levelCompleteUI;
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



    public void StopTimer()
    {
        timerOn = false;
        EndLevelScreen();
    }

    public void EndLevelScreen()
    {
        HUDTimerUI.gameObject.SetActive(false);

        TMP_Text YourTime = null;
        foreach (TMP_Text textComponent in levelCompleteUI.GetComponentsInChildren<TMP_Text>())
        {
            if (textComponent.name == "YourTime")
            {
                YourTime = textComponent;
                break;
            }
        }

        YourTime.text = "Your Time: " + Mathf.Round(timer * 100f) / 100f;

        levelCompleteUI.gameObject.SetActive(true);
    }
}
