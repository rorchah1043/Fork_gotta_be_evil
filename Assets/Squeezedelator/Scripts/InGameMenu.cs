using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private bool _isPaused = false;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_isPaused) 
        {
            _isPaused = true;
            _pauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_pauseMenu);
            Cursor.lockState = CursorLockMode.None;
            PlayerController._canMove = false;
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _isPaused)
        {
            ReturnToGame();
        }
    }

    public void ReturnToGame()
    {
        PlayerController._canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        _isPaused = false;
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
