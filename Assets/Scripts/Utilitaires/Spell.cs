using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "ForRagnarok/Spell")]
public class Spell : Utilitaires
{
    [Range(0,50)]
    public int damages = 5;

    public float range = 1;

    public float nrUtilisation = 1;

    public GameObject prefSpell;
  
    public override GameObject Use()
    {
        GameObject player = Inventory.instance.player;              
        GameObject spallInstantiated = Instantiate(prefSpell, player.transform.position, player.transform.rotation);        
        Inventory.instance.ARemove(this);
        return spallInstantiated; 
    }  
}
