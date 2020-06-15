using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnShoot : IAclassique
{
    public float rangeBack;
    public float range = 3f;
    public float bulletImpulse = 20.0f;
    public Animator animeuh;
    private bool onRange = false;
    private bool onRangeBack = false;
    
    public Rigidbody projectile;
   
    GlobalManager gM;
    public NavMeshAgent agennt;
    Vector3 rangeB;

    
    public override void Start()
    {
        base.Start();
        gM = FindObjectOfType<GlobalManager>();

        float rand = Random.Range(3.0f, 5.0f);
        InvokeRepeating("Shoot", 5, rand);



    }          

    void Shoot()
    {       
        if (onRange && !onRangeBack)
        {
            animeuh.Play("Attack");

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
            
        
            Destroy(bullet.gameObject, 2);
        }


    }

    void Update()
    {

        onRange = Vector3.Distance(transform.position, player.position) <= range;
        onRangeBack = Vector3.Distance(transform.position, player.position) < rangeBack;

        if (onRangeBack)
        {
            rangeB = (transform.position - player.position) * (rangeBack + 5) ;
            rangeB.y = 0;
            agennt.SetDestination(rangeB);
        }
        

        
        if (!onRange)
        {
           
            IAFollowingPlayer();
            
        }
        if (onRange)
        {

             
            transform.LookAt(player);
        }
        StunEnemy();
    }

    public override void StunEnemy()
    {
        base.StunEnemy();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(rangeB, 1);

    }

    public override void IAFollowingPlayer()
    {
        base.IAFollowingPlayer();
    }

    public override void Die()
    {
        //FindObjectOfType<SoundManager>().Play("DeathDraugr");
        SoundManager.Instance.Play("DeathDraugr");
        gM.enemyNumber -= 1;
        gM.m_EnemyDead += 1;
        gM.ennemyShoot -= 1;
        Destroy(gameObject);
        DropHealth();
    }
}
