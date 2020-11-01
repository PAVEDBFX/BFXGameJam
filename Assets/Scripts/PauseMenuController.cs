using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Debug.Log("We've paused the game ");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        Debug.Log("We're playing the game");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void Music()
    {
        AudioSource music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        if (music.isPlaying)
        {
            Debug.Log("Pausing music...");
            music.Pause();
        }
        else
        {
            Debug.Log("Playing music...");
            music.Play();
        }
    }

    public void SFX()
    {
        AudioSource SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        if (SFX.isPlaying)
        {
            Debug.Log("Pausing SFX...");
            SFX.Pause();
        }
        else
        {
            Debug.Log("Playing SFX...");
            SFX.Play();
        }
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
