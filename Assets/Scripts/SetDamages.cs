using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDamages : MonoBehaviour
{
    public Text afficheDegats;
    Animator anim;
    bool animDone = false;
    public GameObject particles;
    public bool isStun = false;
    float timeBeforeMove;
    // Start is called before the first frame update
    void Start()
    {      
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StunEnemy();
    }

    public void PlayAnim()
    {
        anim.SetBool("Yes", true);
    }

    public void AffichagesDegats(int damages)
    {       
        afficheDegats.text = damages.ToString();
    }

    public void StopAnim()
    {
        anim.SetBool("Yes", false);
    }

    public  void StunEnemy()
    {
        if (isStun)
        {           
            timeBeforeMove += Time.deltaTime;
            particles.SetActive(true);
        }

        if (timeBeforeMove >= 5)
        {
            particles.gameObject.SetActive(false);          
            timeBeforeMove = 0;
            isStun = false;           
        }
    }
}
