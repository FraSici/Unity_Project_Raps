using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Elements : MonoBehaviour {

    Collider2D myBase;
    SpriteRenderer myImage;
    public bool needTransparency;
    GameObject player;
    public float inactiveDistance;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myBase = GetComponent<Collider2D>();
        myImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        ChangeOrder();
        float playerDistance = Vector2.SqrMagnitude(myBase.transform.position - player.transform.position);
        if (playerDistance < inactiveDistance)
        {
            CheckTransparency();
        }
    }

    private void ChangeOrder()
    {
        
        float treePos = myBase.bounds.center.y;/*if the y-coordinate of the player is smaller i.e. the player is more on the south, the object will be moved in the layer behind the player and viceversa*/
        if (treePos > Player_Base.playerVertPos)
        {
            myImage.sortingLayerName = "Elements-Back";
        }
        else
        {
            myImage.sortingLayerName = "Elements-Front";
        }
    }

    private void CheckTransparency()
    {
        if (myImage.sortingLayerName == "Elements-Front")
        {
            if (needTransparency)
            {
                myImage.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            }
        }
        else
        {
            myImage.maskInteraction = SpriteMaskInteraction.None;
        }
    }
}
