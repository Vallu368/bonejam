using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item")]
public class ItemClass : ScriptableObject
{
    public string Itemname;
    public int maxDurability;
    public ItemSlot itemSlot;
    public Sprite itemSprite;
    public enum ItemSlot
    {
        slot1,
        slot2
    }
}
