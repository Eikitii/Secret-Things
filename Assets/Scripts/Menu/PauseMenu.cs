using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour

{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    //public AudioMixer audioMixer;
    public AudioSource phoneGuy;
    public AudioSource backroomsAmbient;

    void Update()
    {
        if(pauseMenuUI.activeSelf)
        {
            GameIsPaused=true;
        }
        else
        {
            GameIsPaused = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
                
                //audioMixer.SetFloat("volume", default);
                //AudioSource[] audios = FindObjectsOfType<AudioSource>();
                //foreach (AudioSource audio in audios)
                //{
                //    audio.Play();
                //}
            }

            else
            {
                Pause();
                //audioMixer.SetFloat("volume", -80);
                //AudioSource[] audios = FindObjectsOfType<AudioSource>();
                //foreach (AudioSource audio in audios)
                //{
                //    audio.Pause();
                //}
            }
        }
    }

    public void Resume()
    {
        gameUI.SetActive(true);
        if (phoneGuy != null)
        {
            phoneGuy.UnPause();
            backroomsAmbient.UnPause();
        }
        else
        {

        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        gameUI.SetActive(false);
        phoneGuy.Pause();
        backroomsAmbient.Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
