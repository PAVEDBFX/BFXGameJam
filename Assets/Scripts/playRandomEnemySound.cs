using UnityEngine;
using UnityEngine.Audio;

public class playRandomEnemySound : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip[] audioClipArray;
    public GameObject targetObject;

    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        myAudioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        AudioSource.PlayClipAtPoint(myAudioSource.clip, targetObject.transform.position);
    }
}
