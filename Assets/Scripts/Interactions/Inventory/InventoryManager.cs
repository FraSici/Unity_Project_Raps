using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public Player_Inventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public Inventory_Item currentItem;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0 ||
                    playerInventory.myInventory[i].itemName == "EmptyObject")//In the original zelda instead of destroying the object e.g. a potion they replaced the potion with an empty bottle, i.e. gameobject with no effect
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    Inventory_Slot newSlot = temp.GetComponent<Inventory_Slot>();
                    temp.transform.SetParent(inventoryPanel.transform);
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    public void SetupDescriptionNButton(string descriptionString, bool isButtonUsable, Inventory_Item newItem)
    {
        currentItem = newItem;
        descriptionText.text = descriptionString;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)//go.transform.childCount tells you the number of children of gameObject go
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            //clear inventory slots:
            ClearInventorySlots();
            //refill slots with new numbers:
            MakeInventorySlots();
            if (currentItem.numberHeld <= 0)
            {
                SetTextAndButton("", false);
            }
        }
    }
  
}
