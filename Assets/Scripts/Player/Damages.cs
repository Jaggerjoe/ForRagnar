using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public LayerMask layerM;
    public int damages;   
    public bool isOnPlayer = true;
    [SerializeField]
    Deplacement player;
    IAclassique draugrHit;
    private void Awake()
    {
             
    }
    private void Start()
    {
        player = FindObjectOfType<Deplacement>();     
    }

    private void OnTriggerEnter(Collider other)
    {                           
        //if (player.attack)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (player.attack)
                {
                    other.gameObject.GetComponent<Health>().SetDamages(damages);
                    other.gameObject.transform.Translate(0f, 0f, -3f);
                    other.gameObject.GetComponent<IAclassique>().hitDraugr();
                }                    
            }
                
            if (other.gameObject.layer == LayerMask.NameToLayer("Mummy"))
            {
                if (player.attack)
                {
                    other.gameObject.GetComponent<SetDamages>().AffichagesDegats(damages);
                    other.gameObject.GetComponent<SetDamages>().PlayAnim();
                    Debug.Log(player.attack);
                }                              
            }
        }              
    }
}
