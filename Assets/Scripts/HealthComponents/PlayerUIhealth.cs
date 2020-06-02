using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerUIhealth : MonoBehaviour
{
    public Slider healthBarP;
    public Image m_FillColor;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    Health uiPlayerHealth;

    private void Awake()
    {
        uiPlayerHealth = GetComponent<Health>();
    }
    
    private void OnEnable()
    {
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        healthBarP.value = uiPlayerHealth.health;

        m_FillColor.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, uiPlayerHealth.health / uiPlayerHealth.hpMax);
    }

    private void Update()
    {
        SetHealthUI();
    }
}

  
