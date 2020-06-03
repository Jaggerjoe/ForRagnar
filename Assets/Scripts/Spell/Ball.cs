using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{ 
    GameObject target;
    public Spell dataRef;
    [SerializeField]
    GameObject explosion = null;  
    // Update is called once per frame
    void Update()
    {      
        transform.position += transform.forward * Time.deltaTime * 20;         
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 originPos = collision.gameObject.transform.position;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            StartCoroutine(Explosion(originPos));
            Destroy(gameObject);           
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            StartCoroutine(Explosion(originPos));           
            collision.gameObject.GetComponent<Health>().SetDamages((int)dataRef.damages);
            Destroy(gameObject);
        }        
    }   
    
    public IEnumerator Explosion(Vector3 pos)
    {
        Instantiate(explosion, pos, Quaternion.identity);
        yield return null;
    }
}
