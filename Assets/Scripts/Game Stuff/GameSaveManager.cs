using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
//    public static GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();
    
    public void ResetScriptables()//debugging method
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.dat", i));
            }
        }
    }
    
    /*
    private void Awake()//basic singleton logic: only one exists, always
    {
        if (gameSave == null)
        {
            gameSave = this;
        }
        else
        {
            Destroy(this.gameObject);//since only one exists, I will destroy the redundancy, if there is any 
        }
        DontDestroyOnLoad(this.gameObject);//with this we keep the singleton persisting in all the scenes, and all attached to it will not be reset
    }
    */
    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    public void SaveScriptables()//I create a Json object to store all save data
    {
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));//the last bit means that i (our current argument) is gonna replace the content of the curly bracket
            BinaryFormatter binary = new BinaryFormatter(); // i trasform the data in binary code
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()//on load i take a Json and overwrite the settings
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);//this will deserialize the json file using the binary formatter, convert it into a string and overwrite it onto objects[i]
                file.Close();
            }
        }
    }
}
