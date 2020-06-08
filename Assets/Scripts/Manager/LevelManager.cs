using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseMenuUI;
    ProgressSceneLoader loader;
    public bool ispaused = false;
    Deplacement player;
    private void Start()
    {
        loader = FindObjectOfType<ProgressSceneLoader>();
        player = FindObjectOfType<Deplacement>();
    }
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            ispaused = true;
        }
        else if (Time.timeScale == 1)
        {
            ispaused = false;           
        }       
    }

    public void MenuPause()
    {          
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;       
        SoundManager.Instance.Stop("Theme");
        SoundManager.Instance.Play("Menu");
        player.controls.Disable();
    }

    public void Resume()
    {
        SoundManager.Instance.Stop("Menu");
        SoundManager.Instance.Play("Theme");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        player.controls.Enable();
    }

    public void Quit()
    {
        SoundManager.Instance.Stop("Theme");
        SoundManager.Instance.Play("Menu");         
        loader.LoadScene("MainTitle");
        Destroy(loader.gameObject);
        Time.timeScale = 1;
    }    
}
