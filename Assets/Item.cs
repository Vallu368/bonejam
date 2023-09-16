using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int currentDurability;
    public int maxDurability = 100;
    public ItemSlot itemSlot;
    public Inventory inv;
    public enum ItemSlot
    {
        slot1,
        slot2
    }

    private void Awake()
    {
        inv = FindAnyObjectByType<Canvas>().GetComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddItem();
        }
    }
    public void AddItem()
    {
        inv.AddItemToInventory(this.gameObject);
    }


}
