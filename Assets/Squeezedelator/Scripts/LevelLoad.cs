using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoad : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void OnPlayClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
