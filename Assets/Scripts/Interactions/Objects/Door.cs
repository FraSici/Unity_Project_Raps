using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactables
{

    [Header ("Door Variables")]
    public DoorType thisDoorType;
    public bool doorOpen = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsColl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if (playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    OpenDoor();
                }
            }
        }
    }

    public void OpenDoor()
    {
        doorSprite.enabled = false;
        doorOpen = true;
        physicsColl.enabled = false;
    }

    public void CloseDoor()
    {
        doorSprite.enabled = true;
        doorOpen = false;
        physicsColl.enabled = true;
    }

}
