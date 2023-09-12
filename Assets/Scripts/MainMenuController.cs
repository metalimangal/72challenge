using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject optionsPanel;
    [SerializeField]
    private Button music;
    [SerializeField]
    private Sprite[] musicIcons;
    void Start()
    {
        
    }

    void Update()
    {
        CheckMusic();
    }

    void CheckMusic()
    {
        if(PlayerPrefs.GetInt("Music") == 0)
        {
            MusicController.instance.PlayMusic(false);
            music.image.sprite = musicIcons[0];
        }
        else
        {
            MusicController.instance.PlayMusic(true);
            music.image.sprite = musicIcons[1];
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void Music()
    {
        int x = PlayerPrefs.GetInt("Music");
        PlayerPrefs.SetInt("Music", 1 - x);
    }
}