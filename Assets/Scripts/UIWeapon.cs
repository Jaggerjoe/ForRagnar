using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    [SerializeField]
    Canvas image;

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        image.gameObject.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        image.gameObject.SetActive(false);
    }
}
