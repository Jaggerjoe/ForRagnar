using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Victory : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainTitle");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
}