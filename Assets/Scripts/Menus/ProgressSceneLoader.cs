using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressSceneLoader : MonoBehaviour
{
    [SerializeField]
    private Text progressText;
    [SerializeField]
    private Slider slider;

    private AsyncOperation operation;
    private Canvas canvas;

    //DataReF
    [SerializeField]
    private int m_SaveLife;
    [SerializeField]
    public GameObject m_SaveWeapon = null;
    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        UpdateProgressUI(0);
        canvas.gameObject.SetActive(true);
               
        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);
        
        while (!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }
        UpdateProgressUI(operation.progress);
        yield return new WaitForSeconds(5f);       
        operation = null;       
    }
   
    private void UpdateProgressUI(float progress)
    {
        slider.value = progress;
        progressText.text = (int)(progress * 100f) + "%";    
    }

    public void DesactiveUI()
    {
        canvas.gameObject.SetActive(false);
    }

    public void SaveData(int life, GameObject weapon)
    {
        //sauvegarder
        m_SaveLife = life;
        m_SaveWeapon = weapon;        
    }

    public int GetData()
    {
        return m_SaveLife;
    }

    public GameObject GetWeapon()
    {
        return m_SaveWeapon;
    }       
}
