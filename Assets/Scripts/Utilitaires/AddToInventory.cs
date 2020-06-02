using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : InventorySlotUI
{
    Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(inventory.list.Count < 1)
            {
                inventory.Add(contentloot);
                Destroy(gameObject);
            }  
            else if(inventory.list.Count == 1)
            {
                return;
            }
        }
    }
}
