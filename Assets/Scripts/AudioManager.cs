using UnityEngine;
//using System;
//using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public GameObject audioSourcePrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip, GameObject targetObject)
    {
        AudioSource.PlayClipAtPoint(clip, targetObject.transform.position);
    }
}