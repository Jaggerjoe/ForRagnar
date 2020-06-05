using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuToManager : MonoBehaviour
{
    public GameObject weapon, axe;
    public GameObject arme2;
    public GameObject arme1;  
    [SerializeField]
    GameObject fireBall, Givre, Heal;
    [SerializeField]
    GameObject prefFireB, prefGivre, prefHeal;
    public Transform emplacement1, emplacment2, fireEmplacement,GivreEmplacement,healEmplacement;

    // Start is called before the first frame update
    private void Awake()
    {
        weapon = Instantiate(arme1, emplacement1.position, Quaternion.identity);
        axe = Instantiate(arme2, emplacment2.position, Quaternion.identity);
        prefFireB = Instantiate(fireBall, fireEmplacement.position, Quaternion.identity);
        prefGivre = Instantiate(Givre, GivreEmplacement.position, Quaternion.identity);
        prefHeal = Instantiate(Heal, healEmplacement.position, Quaternion.identity);
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

        if (prefFireB == null)
        {          
            prefFireB = Instantiate(fireBall, fireEmplacement.position, Quaternion.identity);
        }        

        if (prefGivre == null)
        {    
            prefGivre = Instantiate(Givre, GivreEmplacement.position, Quaternion.identity);
        }

        if (prefHeal == null)
        {
            prefHeal = Instantiate(Heal, healEmplacement.position, Quaternion.identity);
        }
    }
}
