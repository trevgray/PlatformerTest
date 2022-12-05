using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class TitleScreenManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Level1.unity");
    }
    
}
