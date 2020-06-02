using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[System.Serializable]
public class IAhealth : Health
{
    public Slider m_Slider;                             
    public Image m_FillImage;                           
    public Color m_FullHealthColor = Color.green;       
    public Color m_ZeroHealthColor = Color.red;
   

    
    private void OnEnable()
    {
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        m_Slider.value = health;
       
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, health / hpMax);
    }

    public override void SetDamages(int damages)
    {
        base.SetDamages(damages);
        SetHealthUI();
    }
}

