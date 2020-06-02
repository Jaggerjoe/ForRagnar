using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    int damages = 3;
    public GameObject projectiles;
    public GameObject explosion;
    public ShakeCamera shakecam;

    void Start()
    {
        shakecam = FindObjectOfType<ShakeCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public virtual void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        collision.gameObject.GetComponent<Health>().SetDamages(damages);
    //    }       
    //}
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {           
            other.gameObject.GetComponent<Health>().SetDamages(damages);
            StartCoroutine(shakecam.Shake(1f, 0.2f));
            StartCoroutine(Explosion(other.gameObject.transform.position));
            Destroy(gameObject);
        }
    }

    private IEnumerator Explosion(Vector3 pos)
    {
        GameObject explode = Instantiate(explosion, pos, Quaternion.identity);
        yield return new WaitForSeconds(2f);                  
    }
}
