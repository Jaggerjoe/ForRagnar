using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    GlobalManager manag;
    
    // Start is called before the first frame update
    void Start()
    {
        manag = FindObjectOfType<GlobalManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            manag.Victory();           
        }
    }
}
