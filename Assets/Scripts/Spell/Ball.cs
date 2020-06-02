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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Destroy(gameObject);
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Health>().SetDamages((int)dataRef.damages);
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);            
        }        
    }       
}
