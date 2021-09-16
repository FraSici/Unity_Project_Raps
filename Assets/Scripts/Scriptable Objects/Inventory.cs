using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{

    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coins;

    public void AddItem(Item item2Add)
    {
        //is item key?
        if (item2Add.isKey)
        {
            numberOfKeys++;
        }
        else
        {
            if (!items.Contains(item2Add))
            {

            }
        }
    }
}
