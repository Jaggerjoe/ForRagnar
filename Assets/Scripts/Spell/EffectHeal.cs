using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHeal : MonoBehaviour
{
    public Utilitaires datSpell;
    [SerializeField]
    GameObject player;
    IAclassique enemy;
    float timer;
    float currentTime = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.SetParent(player.transform);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > currentTime)
        {
            Destroy(gameObject);
        }
        Debug.Log(timer);
    }
}
