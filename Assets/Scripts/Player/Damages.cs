using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public LayerMask layerM;
    public int damages;
    
    public bool isOnPlayer = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isOnPlayer)
        {
           Deplacement player = GetComponentInParent<Deplacement>();
            
            //if (layerM == other.gameObject.layer)
            if (player.attack)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {              
                     other.gameObject.GetComponent<Health>().SetDamages(damages);
                     other.gameObject.transform.Translate(0f , 0f, -3f);
                }
                if (other.gameObject.layer == LayerMask.NameToLayer("Mummy"))
                {
                    other.gameObject.GetComponent<SetDamages>().AffichagesDegats(damages);
                    other.gameObject.GetComponent<SetDamages>().PlayAnim();               
                }
            }   
        }        
    }
}
