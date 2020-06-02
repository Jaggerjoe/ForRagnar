using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuToManager : MonoBehaviour
{
    public GameObject weapon, axe;
    public GameObject arme2;
    public GameObject arme1;
    public GameObject arme;
    public Transform emplacement1, emplacment2;

    // Start is called before the first frame update
    private void Awake()
    {
        weapon = Instantiate(arme1, emplacement1.position, Quaternion.identity);
        axe = Instantiate(arme2, emplacment2.position, Quaternion.identity);      
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon == null)
        {
            weapon = Instantiate(arme1, emplacement1.position, Quaternion.identity);
        }

        if (axe == null)
        {
            axe = Instantiate(arme2, emplacment2.position, Quaternion.identity);
        }
    }
}
