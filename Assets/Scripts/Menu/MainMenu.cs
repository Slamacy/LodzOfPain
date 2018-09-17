using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Gameplay");
    }

    public void LeaderBoard()
    {

    }

    public void HowToPlay()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
