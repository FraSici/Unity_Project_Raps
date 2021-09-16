using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object_Message : Interactables
{

    public string dialogue;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //TRIAL Input.GetKeyDown(KeyCode.Space) -- Input.GetButtonDown("Interact")
        if (Input.GetButtonDown("Interact_Alt_A") && playerInRange)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                dialText.text = dialogue;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
            other.GetComponent<Player_Base>().objectInRange = false;
            context.Raise();
            dialogueBox.SetActive(false);
        }
    }
}
