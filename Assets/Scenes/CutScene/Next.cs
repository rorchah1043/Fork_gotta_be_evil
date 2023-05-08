using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    [SerializeField] int numScene;
    [SerializeField] private VideoPlayer videoPlayer;
    private void OnEnable()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    private void OnDisable()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }

    void OnVideoEnd(UnityEngine.Video.VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene(numScene);
    }
}
