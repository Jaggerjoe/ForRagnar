using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{ 
    //Autres
    public int hpMax = 50;
    public int health = 50;
    public UnityEvent OnDie;
    
    public virtual void SetDamages(int damages)
    {
        health -= damages;

        if(health <= 0)
        {
            Die();
        }    
    }
    
    public void Die()
    {      
        OnDie?.Invoke();             
    }
}
