using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalSO : ScriptableObject
{
    public List<Signal_Listener> listeners = new List<Signal_Listener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1 ; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(Signal_Listener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(Signal_Listener listener)
    {
        listeners.Remove(listener);
    }

}
