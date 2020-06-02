using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potion : MonoBehaviour
{
    [Range(0,100)]
    public int amountHealth;


    public Spell dataSpell;
    [SerializeField]
    GameObject player;
    IAclassique enemy;
    float timer;
    float currentTime = 3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.SetParent(player.transform);
    }

    private void Update()
    {
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.SetDamages(-dataSpell.damages);
        if (playerHealth.health > playerHealth.hpMax)
        {
            playerHealth.health = 50;
        }
        timer += Time.deltaTime;
        if (timer > currentTime)
        {
            Destroy(gameObject);
        }        
    }
}
