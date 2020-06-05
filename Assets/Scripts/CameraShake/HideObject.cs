using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideObject : MonoBehaviour
{
    public GameObject pilier;
    public Material[] maty;
    int size;
    Renderer rend;
    Color newColor;
    float alpha = 0.2f;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {         
            if (hit.collider.tag == "Wall")
            {      
                pilier = hit.transform.gameObject;
                rend = hit.transform.GetComponentInChildren<Renderer>();
                maty = rend.materials;
                foreach (Material m in maty)
                {
                    newColor = m.color;
                    m.shader = Shader.Find("Transparent/Diffuse");
                    newColor.a = alpha;
                    m.color = newColor;

                    //newColor = rend.material.color;
                    //rend.material.shader = Shader.Find("Transparent/Diffuse");
                    //newColor.a = alpha;
                    //rend.material.color = newColor;
                }
            }

            if(hit.collider.tag != "Wall")
            {
                Debug.Log(hit.collider.tag);
                if(pilier != null)
                {
                    foreach (Material m in maty)
                    {
                        newColor = m.color;
                        m.shader = Shader.Find("Standard");
                        newColor.a = 1;
                        m.color = newColor;
                    }
                    pilier = null;
                    maty = null;
                }
            }
        }

        //else if (pilier == null)
        //{
            
        //    //rend = pilier.GetComponent<Renderer>();
        //    //newColor = rend.material.color;
        //    //rend.material.shader = Shader.Find("Standard");
        //    //newColor.a = 1;
        //    //rend.material.color = newColor;
           
        //}
    }
}
