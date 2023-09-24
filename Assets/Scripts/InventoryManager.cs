using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;
//using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject Inventory;
    public ItemPickup ChechPU;
    public bool InventoryFull = false;

    void Update()
    {
        
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void CheckCount()
    {
        /*if (Items.Count > 1)
        {
            Remove(Items[0]);
        }*/

        if(Items.Count == 2)
        {
            InventoryFull = true;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void ListItems()
    {
        if (!InventoryFull)
        {
            foreach (Transform item in ItemContent)
            {
                Destroy(item.gameObject);
            }

            foreach (var item in Items)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
            }
        }
    }
}
