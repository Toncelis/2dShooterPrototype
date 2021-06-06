using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartLevel ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

