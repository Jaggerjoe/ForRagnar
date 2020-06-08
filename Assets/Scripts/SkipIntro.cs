using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    Animator anim;
    bool isActive = false;
    TuToManager manag;
    public Camera cam,cam2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        manag = FindObjectOfType<TuToManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            anim.SetBool("Done", true);
            isActive = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Done",false);
            SoundManager.Instance.Stop("Intro");
            manag.timer = 65f;
            Destroy(cam);
        }
    }
}
