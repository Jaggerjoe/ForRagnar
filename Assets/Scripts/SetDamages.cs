using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDamages : MonoBehaviour
{
    public Text afficheDegats;
    Animator anim;
    bool animDone = false;
    // Start is called before the first frame update
    void Start()
    {      
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("FireBall"))
        {
            anim.SetBool("Yes", true);
        }
    }
    public void AffichagesDegats(int damages)
    {
        afficheDegats.text = damages.ToString();
    }
    public void StopAnim()
    {
        anim.SetBool("Yes", false);
    }
}
