using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText, PanelText;
    private int score;
    [SerializeField]
    private GameObject pausePanel;
    private GameObject player;
    public Button pause;
    public int health = 3;
    public GameObject[] heartContainers;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreText.text = ""+score;
    }

    void Update()
    {
        if (!player.activeInHierarchy)
        {
            WaitTillRespawn();
        }
    }

    public void AddScore(int add)
    {
        score += add;
        scoreText.text = ""+score;
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
