using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWeapon : MonoBehaviour
{
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(0.3f, 0.33f, 0.33f);
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
