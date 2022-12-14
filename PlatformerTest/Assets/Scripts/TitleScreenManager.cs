using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class TitleScreenManager : MonoBehaviour
{
    public HighScoreManager highScoreManager;
    public TMP_Text titleScreen;
    public TMP_Text highScoreScreen;

    public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Level1.unity");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Highscores()
    {
        titleScreen.gameObject.SetActive(false);

        int textIterator = 0;
        foreach (TMP_Text textComponent in highScoreScreen.GetComponentsInChildren<TMP_Text>())
        {
            if (textComponent.name != "Highscore")
            {
                textComponent.text = highScoreManager.scores[textIterator].ToString() + "s";
                textIterator++;
                if (textIterator == 3)
                {
                    break;
                }
            }
        }
        highScoreScreen.gameObject.SetActive(true);
    }

    public void TitleScreen()
    {
        titleScreen.gameObject.SetActive(true);
        highScoreScreen.gameObject.SetActive(false);
    }
}
