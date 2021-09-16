using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public bool active;
    public BoolValue storeValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;
    // Start is called before the first frame update
    void Start()
    {
        active = storeValue.RuntimeValue;
        mySprite = GetComponent<SpriteRenderer>();
        if (active)
        {
            ActivateSwitch();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        active = true;
        storeValue.RuntimeValue = active;
        thisDoor.OpenDoor();
        mySprite.sprite = activeSprite;
    }
}
