using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer = 0.0f;
    public bool timerOn;

    public TMP_Text HUDTimer;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
            HUDTimer.text = "Timer " + Mathf.Round(timer * 100f) / 100f;
        }
    }
}
