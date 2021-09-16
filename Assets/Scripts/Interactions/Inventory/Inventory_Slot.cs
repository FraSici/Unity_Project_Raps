using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{

    [Header("UI item info")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;

    [Header("UI item parameters")]
    public Inventory_Item thisItem;
    public InventoryManager thisInvManager;

    public void Setup(Inventory_Item newItem, InventoryManager newIM)
    {
        thisItem = newItem;
        thisInvManager = newIM;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNameText.text = "" + thisItem.numberHeld ; //quick way to cast a number as string text
        }
    }

    public void ClickedOn()
    {
        if (thisItem)
        {
            thisInvManager.SetupDescriptionNButton(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }

}
