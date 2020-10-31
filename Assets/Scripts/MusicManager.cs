using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    public void PlayOrPauseSound()
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
}