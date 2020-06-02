using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utilitaires : ScriptableObject
{
    public string itemName;

    public Sprite icon;


    public virtual GameObject Use()
    {
        return null;
    }
}
