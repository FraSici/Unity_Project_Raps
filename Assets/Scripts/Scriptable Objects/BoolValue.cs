using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BoolValue : ScriptableObject 
{
    public bool initialValue;
    [HideInInspector]
    public bool RuntimeValue;
    /*  If you want the following to work, delete system.serializable
     *  and add after scriptable object also ISerializationCallbackReceiver
  
    *  public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }*/
}
