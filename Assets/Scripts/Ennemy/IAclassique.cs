using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAclassique : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    GlobalManager gM;
    public ShakeCamera shakecam;
    public int speed = 10;
    int m_DRopRate = 25;
    public float currentTime = 0.0f;
    public GameObject m_HealthGlob, FireBall, Ring, arme2, arme1;
    public int damages = 5;
    int spawningObject;
    public bool isArme1 = true;
    public bool isArme2 = false;
    public GameObject particles;
    public bool isStun = false;

    float timeBeforeMove;
    public virtual void Start()
    {
        gM = FindObjectOfType<GlobalManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        currentTime = 0;
        GetComponent<Health>().OnDie.AddListener(Die);
        shakecam = FindObjectOfType<ShakeCamera>();       
    }

    void Update()
    {
        IAFollowingPlayer();

        if (isArme1 == true)
        {
            isArme2 = false;
        }

        if (isArme2 == true)
        {
            isArme1 = false;
        }
        StunEnemy();
    }

    public virtual void StunEnemy()
    {
        if (isStun)
        {
            agent.isStopped = true;
            timeBeforeMove += Time.deltaTime;
            particles.SetActive(true);
        }

        if (timeBeforeMove >= 5)
        {
            particles.gameObject.SetActive(false);
            IAFollowingPlayer();
            timeBeforeMove = 0;
            isStun = false;
            agent.isStopped = false;
            Debug.Log(agent.isStopped);
        }
    }
    public virtual void IAFollowingPlayer()
    {
        agent.SetDestination(player.position);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Health>().SetDamages(damages);
            StartCoroutine(shakecam.Shake(1f, 0.2f));
        }
    }

    public void DropHealth()
    {
        if (Random.Range(0, 100) <= m_DRopRate)
        {
            spawningObject = Random.Range(1, 4);
            switch (spawningObject)
            {
                case 1:
                    Instantiate(Ring, this.transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(FireBall, this.transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(m_HealthGlob, this.transform.position, Quaternion.identity);
                    break;
            }
        }
    }

    public void DropWeapon1()
    {


        if ((Random.Range(0, 100) >= 50) && (isArme1 == true))
        {
            Instantiate(arme2, this.transform.position, Quaternion.identity);
            isArme2 = true;
        }

    }

    public void DropWeapon2()
    {
        if ((Random.Range(0,100) >= 50) && (isArme2 == true))
        {
            Instantiate(arme1, this.transform.position, Quaternion.identity);
            isArme1 = true;
            
        }
    }
 
    // fonction de mort de l'ennemi
    public virtual void Die ()
    {         
        //FindObjectOfType<SoundManager>().Play("DeathDraugr");
        SoundManager.Instance.Play("DeathDraugr");
        gM.enemyNumber -= 1;
        gM.m_EnemyDead += 1;
        gM.ennemyClassique -= 1;
        Destroy(gameObject);
        DropHealth();
        DropWeapon1();
    }

}
