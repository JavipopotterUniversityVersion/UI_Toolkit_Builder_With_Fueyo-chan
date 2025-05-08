using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private void OnEnable() {
        LoadGame();
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    public static void SaveInt(string key, int value)
    {
        string persistentDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + key + ".txt";
        StreamWriter writer = new StreamWriter(persistentDataPath);
        writer.Write(value.ToString());
        writer.Close();
    }

    public static int LoadInt(string key, int defaultValue = 0)
    {
        string persistentDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + key + ".txt";
        if (File.Exists(persistentDataPath))
        {
            StreamReader reader = new StreamReader(persistentDataPath);
            string value = reader.ReadToEnd();
            reader.Close();
            return int.Parse(value);
        }
        return defaultValue;
    }
    
    public static void SaveGame()
    {
        InventoryData _inventory = Resources.Load<InventoryData>("Inventory");
        InventoryData _team = Resources.Load<InventoryData>("CurrentTeam");

        string persistentDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + _inventory.name + ".json";
        StreamWriter writer = new StreamWriter(persistentDataPath);
        writer.Write(JsonUtility.ToJson(_inventory));
        writer.Close();

        persistentDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + _team.name + ".json";
        writer = new StreamWriter(persistentDataPath);
        writer.Write(JsonUtility.ToJson(_team));
        writer.Close();
    }

    public static void LoadGame()
    {
        InventoryData _inventory = Resources.Load<InventoryData>("Inventory");
        InventoryData _team = Resources.Load<InventoryData>("CurrentTeam");

        string persistentDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + _inventory.name + ".json";
        if (File.Exists(persistentDataPath))
        {
            StreamReader reader = new StreamReader(persistentDataPath);
            string json = reader.ReadToEnd();
            JsonUtility.FromJsonOverwrite(json, _inventory);
            reader.Close();
        }

        persistentDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + _team.name + ".json";
        if (File.Exists(persistentDataPath))
        {
            StreamReader reader = new StreamReader(persistentDataPath);
            string json = reader.ReadToEnd();
            JsonUtility.FromJsonOverwrite(json, _team);
            reader.Close();
        }
    }
}
