using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;


    public void playGame()
    {
        Debug.Log("Scene loading");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Options()
    {
        Debug.Log("Options ");
        optionsMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void Back()
    {
        Debug.Log("Back to pause menu ");
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void PlayOrPauseMusic()
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

    public void PlayOrPauseSFX()
    {
        AudioSource SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        if (SFX.isPlaying)
        {
            Debug.Log("Pausing SFX...");
            SFX.Pause();
        }
        else
        {
            Debug.Log("Playing music...");
            SFX.Play();
        }
    }
}