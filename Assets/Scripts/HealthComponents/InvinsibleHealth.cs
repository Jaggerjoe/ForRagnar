using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinsibleHealth : Health
{
    public bool isInvinsible;

    public override void SetDamages(int damages)
    {
        if(!isInvinsible || (isInvinsible && damages < 0))
        {
            base.SetDamages(damages);
        }

    }

}
