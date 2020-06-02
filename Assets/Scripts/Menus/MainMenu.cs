using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonQuit;
    
    
    private void Start()
    {
        buttonPlay.GetComponent<Button>().onClick.AddListener(PlayGame);
        buttonQuit.GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Tutotial");
        Time.timeScale = 1;
    }
   
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}


