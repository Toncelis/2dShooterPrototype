using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] GameObject WinPanel;
    [SerializeField] TMPro.TMP_Text scoreText;

    [SerializeField] GameObject LosePanel;

    public void Win ()
    {
        int score;
        score = ScoreNBulletManager.GetInstance().Score;
        WinPanel.SetActive(true);
        scoreText.text = "Score : " + score;
    }
        
    public void Lose ()
    {
        LosePanel.SetActive(true);
    }

    public void Restart ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
    }
    public void Exit ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
