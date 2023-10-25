using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {
        EditorApplication.isPlaying = false;
    }

    public void MainMenuButtton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
