using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{

    

    public void Test(InputAction.CallbackContext context)//We need this input because in this way the method process whatever input we are getting by the input system
    {
        if (!context.performed) 
        {
            Debug.Log("Try something");
        }
    }
}
