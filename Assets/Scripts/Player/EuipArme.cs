using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuipArme : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Pivot;

   public void GetPicked()
   {
        transform.parent = m_Pivot.transform.parent;
        transform.position = m_Pivot.transform.position;
        transform.rotation = m_Pivot.transform.rotation;
   }
}
