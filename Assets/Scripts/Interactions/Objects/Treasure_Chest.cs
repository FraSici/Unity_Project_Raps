using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Treasure_Chest : Interactables
{

    public Item content;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;
    public SignalSO raiseItem;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialText;
    private Animator anim;

    private void Start()
    {
        isOpen = storedOpen.RuntimeValue;
        anim = GetComponent<Animator>();
        if (isOpen)
        {
            anim.SetBool("open", true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else 
            {
                ChestUnavailable();
            }
 
        }

    }

    public void OpenChest()
    {
        //dial box on
        dialogueBox.SetActive(true);
        //dial text = contents text
        dialText.text = content.itemDescription;
        //add to inventory
        playerInventory.AddItem(content);
        playerInventory.currentItem = content;
        //raise signal to animate player
        raiseItem.Raise();
        //raise context to turn off
        context.Raise();
        // set chest to opened
        isOpen = true;
        anim.SetBool("open", true);
        storedOpen.RuntimeValue = isOpen;
    }

    public void ChestUnavailable()
    {
        //dial off
        dialogueBox.SetActive(false);
        //raise signal to stop animation player
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = false;
            context.Raise();
        }
    }


}
