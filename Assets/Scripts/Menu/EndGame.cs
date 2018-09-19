using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private void OnMouseDown()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Menu");
    }
}
