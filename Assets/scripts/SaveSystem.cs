using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<EInventoryItem> inventory;
}

public class SaveSystem : MonoBehaviour
{
    private static string PATH = Application.persistentDataPath + "/mysave";

    public static void Save(List<EInventoryItem>a_inventory)
    {
        SaveData DataToSave = new SaveData();
        DataToSave.inventory = a_inventory;

        string stringSaveData = JsonUtility.ToJson(DataToSave);
        File.WriteAllText(PATH, stringSaveData);
    }

    public static SaveData Load()
    {
        SaveData loadedData = null;
        if (File.Exists(PATH))
        {
            string loadData = File.ReadAllText(PATH);
            loadedData = JsonUtility.FromJson<SaveData>(loadData);
        }

        return loadedData;

    }
}
