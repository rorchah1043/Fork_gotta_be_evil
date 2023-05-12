using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemBee : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
        PlayerController._canMove = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReturnToGame()
    {
        gameObject.SetActive(false);
        PlayerController._canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
