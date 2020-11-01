using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    
    void Awake()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += LoadNextScene;
    }
    
    void LoadNextScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(0);
    }
    
}