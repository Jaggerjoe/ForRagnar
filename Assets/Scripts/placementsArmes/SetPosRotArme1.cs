using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosRotArme1 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject pivot;
    private Transform posArme;
    // Update is called once per frame
    private void Start()
    {
        pivot = GameObject.FindGameObjectWithTag("posArme");
        posArme = pivot.transform;
    }
    void Update()
    {

        transform.LookAt(posArme);

    }
}
