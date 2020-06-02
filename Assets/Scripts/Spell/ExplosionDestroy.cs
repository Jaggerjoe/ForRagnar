using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    [SerializeField][Range(0,10)]
    int damages = 0;
    [SerializeField]
    GameObject explosion;
    float timeBeforeDestroy;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        explosion = GameObject.FindGameObjectWithTag("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        if(explosion)
        {
            timeBeforeDestroy += Time.deltaTime;
        }

        if(timeBeforeDestroy >= 2)
        {
            Destroy(explosion);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.GetComponent<Health>().SetDamages(damages);
        }
    }
}
