using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SFX");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

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
            Debug.Log("Playing SFX...");
            SFX.Play();
        }
    }
}