using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class Inventory_SaveManager : MonoBehaviour
{

    [SerializeField] private Player_Inventory myInventory;

    private void OnEnable()
    {
        myInventory.myInventory.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    public void ResetScriptables()//debugging method
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            i++;
        }
    }

    public void SaveScriptables()//I create a Json object to store all save data
    {
        ResetScriptables();
        for (int i = 0; i < myInventory.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i));//the last bit means that i (our current argument) is gonna replace the content of the curly bracket
            BinaryFormatter binary = new BinaryFormatter(); // i trasform the data in binary code
            var json = JsonUtility.ToJson(myInventory.myInventory[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()//on load i take a Json and overwrite the settings
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            var temp = ScriptableObject.CreateInstance<Inventory_Item>();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter(); // the formatter exists to take the info from the file and put it back in the gameobject
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);//this will deserialize the json file using the binary formatter, convert it into a string and overwrite it onto temp
            file.Close();
            myInventory.myInventory.Add(temp);
            i++;
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
