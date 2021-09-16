using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//Saves asset to a file
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/ Player Inventory")]
public class Player_Inventory : ScriptableObject
{

    public List<Inventory_Item> myInventory = new List<Inventory_Item>();

}
