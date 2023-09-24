using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public bool IsPickup = false;
    public GameObject ItemGo;
    public GameObject ListAdding;
    public GameObject Full;

    void PickUp()
    {
        IsPickup = true;
        InventoryManager.Instance.CheckCount();

        if(ListAdding.GetComponent<InventoryManager>().InventoryFull == false)
        {
            InventoryManager.Instance.Add(Item);
            InventoryManager.Instance.ListItems();
            ItemGo.SetActive(false);
        } else
        {
            Full.SetActive(true);
        }
    }

    private void OnTriggerEnter2D()
    {
        PickUp();
    }

    private void OnTriggerExit2D()
    {
            Full.SetActive(false);
    }
}
