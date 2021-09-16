using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]//allows to create as an object with a right click in the unity GUI!
[System.Serializable]//I got rid of ISerializationCallbackReceiver and i don't need the Serialize methods, because i will serialize saving data
public class FloatValue : ScriptableObject
{
    public float initialValue;
    /**************IMPORTANT************************************************************
     Scriptable objects are super cool and allow to have objects be persistent through
     all the scenes, so you do not need to use DontDestroyOnLoad.
     However, if their value is updated, the updated value will PERSIST after!
     if that value is life for instance, and you die, you will start the next game dead!
     in order to reinitialize, we make so that this SO will inherit not only from 
     ScriptableObject, but also from ISerializationCallbackReceiver, that deals with 
     serializing stuff. From it we use the methods OnBeforeSerialize and OnAfterDeserialize
     , we initialize a float which will be used during RUNTIME and when the time is over
     thanks to OnAfterDeserialize we can reinitialize with the original value!
     ***********************************************************************************/
    public float RuntimeValue;
    
}
