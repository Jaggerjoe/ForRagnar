using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Utilitaires contentloot;


    private void Start()
    {
        UpdateInfos();
    }

    public void UpdateInfos()
    {
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image displayImage = transform.Find("Image").GetComponent<Image>();
        if (contentloot)
        {
            displayText.text = contentloot.itemName;
            displayImage.sprite = contentloot.icon;
        }
        else
        {
            displayText.text = "";
            displayImage.sprite = null;
        }
    }

    public void Use()
    {
        if (contentloot)
        {
            contentloot.Use();
        }
    }
}
