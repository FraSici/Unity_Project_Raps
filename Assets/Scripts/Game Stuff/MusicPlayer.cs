using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    void Awake()
    {
        //	Debug.Log("Music Player Awake"+ GetInstanceID()); A debug line, now it is not needed
        if (instance != null)
        {
            Destroy(gameObject);
            //			print ("Destroy the Duplicate!");
        }
        else
        {
            instance = this;
            //GameObject.DontDestroyOnLoad(gameObject); /*uncode this if you want the music to play also in other scenes*/
        }
    }

    // Use this for initialization
    void Start()
    {
        //	Debug.Log("Music Player Awake"+ GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
