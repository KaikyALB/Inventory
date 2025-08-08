using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static InventorySlot;

public class InventoryType : MonoBehaviour
{
    public itemType slotType;  // This slot only accepts specific item type
    public List<InventorySlot> itemsInSlot = new List<InventorySlot>();

    public Vector2 GetOffsetPosition()
    {
        float xOffset = 30f;
        float spaceItem = 20f;
        return new Vector2(xOffset * spaceItem, 0);
    }
    public void addItem(InventorySlot item)
    {
        itemsInSlot.Add(item);
    }
    public void removeItem(InventorySlot item)
    {
        if(itemsInSlot.Contains(item))
        {
            itemsInSlot.Remove(item);
        }
    }
}
