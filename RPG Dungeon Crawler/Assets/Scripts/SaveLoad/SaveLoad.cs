using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveLoad : MonoBehaviour
{
    #region Singleton Init
    public static SaveLoad Instance;
    
    void Awake()
    {
        Instance = this;
    }
    #endregion

    private string saveFile;
    public CurrentInventory dataToSave;

    private void Start()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
    }

    public void SaveData()
    {
        //if (File.Exists(saveFile))
        //    File.Delete(saveFile);

        //string json = JsonConvert.SerializeObject(dataToSave);

        //File.WriteAllText(saveFile, json);
    }

    public void LoadData()
    {
        if (File.Exists(saveFile))
        {
            //string fileContents = File.ReadAllText(saveFile);

            //CurrentInventory loadedData = JsonConvert.DeserializeObject<CurrentInventory>(fileContents);

            //dataToSave.armor = loadedData.armor;
            //dataToSave.equipedSpells = loadedData.equipedSpells;
            //dataToSave.GlobalInventory = loadedData.GlobalInventory;
            //dataToSave.moneyInventory = loadedData.moneyInventory;
            //dataToSave.spellsInventory = loadedData.spellsInventory;
            //dataToSave.usable = loadedData.usable;
            //dataToSave.weapon = loadedData.weapon;
        }
    }
}