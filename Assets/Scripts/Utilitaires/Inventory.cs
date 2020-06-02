using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Utilitaires> list = new List<Utilitaires>();
    public GameObject player;
    public GameObject inventoryPanel;
    public static Inventory instance;

    void UpdateSlot()
    {
        int index = 0;
        foreach (Transform child in inventoryPanel.transform)
        {
            InventorySlotUI slot = child.GetComponent<InventorySlotUI>();
            if(index < list.Count)
            {
                slot.contentloot = list[index];
            }
            else
            {
                slot.contentloot = null;
            }
            slot.UpdateInfos();
            index++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
        UpdateSlot();
        instance = this;
    }

   public void Add(Utilitaires item)
    {
        if(list.Count < 1 )
        {
            list.Add(item);
        }
        UpdateSlot();
    }

    public void ARemove(Utilitaires item)
    {
        list.Remove(item);
        UpdateSlot();
    }
}
