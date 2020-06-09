using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{   
    public Spell datSpell;
    [SerializeField]
    GameObject player;
    IAclassique enemy;
    float timer;
    float currentTime = 6f;    
   
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.SetParent(player.transform);
        SoundManager.Instance.Play("Givre");
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > currentTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.GetComponent<Health>().SetDamages((int)datSpell.damages);
            other.gameObject.GetComponent<IAclassique>().isStun = true;           
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Mummy"))
        {         
            other.gameObject.GetComponent<SetDamages>().AffichagesDegats(datSpell.damages);
            other.gameObject.GetComponent<SetDamages>().PlayAnim();
            other.gameObject.GetComponent<SetDamages>().isStun = true;
        }
    }
}
