using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText, PanelText, levelText, highScoreText;
    private int score = 0;
    [SerializeField]
    private GameObject pausePanel;



    private GameObject player;
    [SerializeField]
    private GameObject enemy1Spawner;
    [SerializeField]
    private GameObject enemy2Spawner;
    public Button pause;
    public int health = 3;
    public GameObject[] heartContainers;
    public float time = 60;

    public float currentLevel = 1;

    public int highScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreText.text = ""+score;
        levelText.text = "LEVEL: 1 (60)";
        enemy1Spawner.SetActive(false);
        enemy2Spawner.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    void Update()
    {
        if (!player.activeInHierarchy)
        {
            WaitTillRespawn();
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
            levelText.text = "LEVEL: "+currentLevel+" ("+(int)time+")";
        }
        else
        {
            currentLevel++;
            if(currentLevel == 2)
            {
                enemy1Spawner.SetActive(true);
            }
            if(currentLevel == 3)
            {
                enemy2Spawner.SetActive(true);
            }
            if(currentLevel == 4)
            {
                pausePanel.gameObject.SetActive(true);
                PanelText.text = "You Win!!!!";
            }
            time = 60;
        }

    }

    public void AddScore(int add)
    {
        score += add;
        scoreText.text = ""+score;
    }

    public int GetScore()
    {
        return score;
    }

    public void Pause()
    {
        PanelText.text = "Pause";
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        if (PanelText.text == "Pause")
            pausePanel.gameObject.SetActive(false);
        else
            SceneManager.LoadScene("Level1");
        
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartGame");
    }

    void WaitTillRespawn()
    {
        pausePanel.gameObject.SetActive(true);
        PanelText.text = "Game Over!!!!";

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    public void ReduceHealth()
    {
        health--;
        if (health >= 0)
        {
            heartContainers[health].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
