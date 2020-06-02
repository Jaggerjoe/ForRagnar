using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementArmes : MonoBehaviour
{
    public GameObject arme2;
    public GameObject arme1;
    public GameObject pivot;
    public bool isTrigger;
   
    private void Awake()
    {
        isTrigger = false;
        
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isTrigger == true)
            {
                arme1.transform.parent = null;
                Destroy(arme1);
                arme2.transform.parent = pivot.transform;
                arme2.transform.position = arme1.transform.position;
                Damages damages = arme2.GetComponent<Damages>();
                damages.isOnPlayer = true;              
            } 
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Weapon2"))
        {
                isTrigger = true;
                arme2 = other.gameObject;

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("weapon"))
        {
            if (isTrigger == true)
            { 
                arme2.transform.parent = null;
                Destroy(arme2);
                other.gameObject.transform.parent = pivot.transform.parent;
                other.gameObject.transform.position = arme2.transform.position;
                arme1 = other.gameObject;
            }
        }
    }
}

    


