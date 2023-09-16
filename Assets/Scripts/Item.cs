using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item")]
public class Item : ScriptableObject
{
    public string Itemname;
    public int durability;
    public ItemSlot itemSlot;
    public enum ItemSlot
    {
        slot1,
        slot2
    }
}
