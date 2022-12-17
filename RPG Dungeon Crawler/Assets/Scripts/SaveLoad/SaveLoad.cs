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
        saveFile = Application.persistentDataPath + "/gamedata.json";
    }
    #endregion

    [System.Serializable]
    private struct Save
    {
        public enum SavedType
        {
            Spell = 0,
            Item = 1
        }

        public string savedName;
        public SavedType type;
        public int amount;
        public bool isEquiped;
        public int equipIndex;
        public int lvl;
    }

    private string saveFile;

    private const string SAVE_COINS = "Coins";
    private const string SAVE_BLUESCROLLS = "BlueScrolls";
    private const string SAVE_PURPLESCROLLS = "PurpleScrolls";
    private const string SAVE_REDSCROLLS = "RedScrolls";

    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject newGameButtonWQ;

    private void Start()
    {
        if (File.Exists(saveFile))
            continueButton.SetActive(true);
    }

    public void CheckSaveFile()
    {
        if (File.Exists(saveFile))
        {
            continueButton.SetActive(true);
            newGameButtonWQ.SetActive(true);
            newGameButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(false);
            newGameButtonWQ.SetActive(false);
            newGameButton.SetActive(true);
        }
    }


    public void SaveData()
    {
        if (File.Exists(saveFile))
            File.Delete(saveFile);

        List<Save> dataToSave = new List<Save>();

        foreach (Spell spell in MenuInventoryController.Instance.inventory.spellsInventory)
        {
            Save newData = new Save();

            newData.savedName = spell.spellName;
            newData.type = Save.SavedType.Spell;
            newData.isEquiped = false;
            newData.amount = 0;
            newData.lvl = spell.lvl;

            int index = 0;
            foreach (Spell spellUsing in MenuInventoryController.Instance.inventory.equipedSpells)
            {
                if (spellUsing == null) { index++; continue; }
                if (spell.spellName == spellUsing.spellName)
                {
                    newData.isEquiped = true;
                    newData.equipIndex = index;

                    break;
                }
                index++;
            }

            dataToSave.Add(newData);
        }

        foreach (Item item in MenuInventoryController.Instance.inventory.GlobalInventory)
        {
            bool isExist = false;
            Save newDataExist = new Save();

            //Check amount
            for (int i = 0; i < dataToSave.Count; i++)
            {
                if (dataToSave[i].savedName == item.itemName)
                {
                    newDataExist.savedName = item.itemName;
                    newDataExist.type = Save.SavedType.Item;
                    newDataExist.isEquiped = dataToSave[i].isEquiped;
                    newDataExist.amount = dataToSave[i].amount + 1;
                    newDataExist.lvl = dataToSave[i].lvl;

                    dataToSave.Remove(dataToSave[i]);
                    isExist = true;
                    break;
                }
            }

            if (isExist)
            {
                dataToSave.Add(newDataExist);
                continue;
            }

            Save newData = new Save();
            newData.savedName = item.itemName;
            newData.type = Save.SavedType.Item;
            newData.isEquiped = false;
            newData.amount = 1;
            newData.equipIndex = 0;
            newData.lvl = item.lvl;

            if (item == MenuInventoryController.Instance.inventory.armor)
                newData.isEquiped = true;
            if (item == MenuInventoryController.Instance.inventory.weapon)
                newData.isEquiped = true;
            if (item == MenuInventoryController.Instance.inventory.usable)
                newData.isEquiped = true;

            dataToSave.Add(newData);
        }

        //Serialize data
        string json = JsonConvert.SerializeObject(dataToSave);

        //Rewrite data to save file
        File.WriteAllText(saveFile, json);

        //Save money
        PlayerPrefs.SetInt(SAVE_COINS, MenuInventoryController.Instance.inventory.moneyInventory.amountCoins);
        PlayerPrefs.SetInt(SAVE_BLUESCROLLS, MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls);
        PlayerPrefs.SetInt(SAVE_PURPLESCROLLS, MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls);
        PlayerPrefs.SetInt(SAVE_REDSCROLLS, MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls);
    }

    public void LoadData()
    {
        if (File.Exists(saveFile))
        {
            //Deserialize file into list
            string fileContents = File.ReadAllText(saveFile);
            List<Save> loadedData = JsonConvert.DeserializeObject<List<Save>>(fileContents);

            //Add all items to inventory
            foreach(Save data in loadedData)
            {
                if(data.type == Save.SavedType.Spell) //Load spell
                {
                    Spell currentSpell = new Spell();
                    foreach(Spell spell in MenuInventoryController.Instance.inventory.AllSpellsInTheGame)
                    {
                        if(data.savedName == spell.spellName)
                        {
                            currentSpell = spell;
                        }
                    }

                    if(currentSpell != null) // Shouldn't happen but who knows
                    {
                        if (data.isEquiped)
                        {
                            MenuInventoryController.Instance.inventory.equipedSpells[data.equipIndex] = currentSpell;
                        }

                        currentSpell.lvl = data.lvl;
                        for (int i = 1; i < data.lvl; i++)
                        {
                            currentSpell.spellReference.UpgradeStats();
                        }

                        MenuInventoryController.Instance.inventory.spellsInventory.Add(currentSpell);
                    }
                }
                else if(data.type == Save.SavedType.Item) //Load item
                {
                    Item currentItem = new Item();
                    foreach(Item item in MenuInventoryController.Instance.inventory.AllItemsInTheGame)
                    {
                        if(data.savedName == item.itemName)
                        {
                            currentItem = item;
                        }
                    }

                    if(currentItem != null) // Shouldn't happen but who knows 
                    {                       
                        currentItem.lvl = data.lvl;

                        for (int i = 0; i < data.amount; i++)
                        {
                            MenuInventoryController.Instance.inventory.GlobalInventory.Add(currentItem);
                        }
                        for (int i = 1; i < data.lvl; i++)
                        {
                            currentItem.itemReference.UpgradeStats();
                        }

                        if (data.isEquiped)
                        {
                            switch (currentItem.type)
                            {
                                case Item.ItemType.Weapon:
                                    MenuInventoryController.Instance.inventory.weapon = currentItem;
                                    break;
                                case Item.ItemType.Armor:
                                    MenuInventoryController.Instance.inventory.armor = currentItem;
                                    break;
                                case Item.ItemType.Usable:
                                    MenuInventoryController.Instance.inventory.usable = currentItem;
                                    break;
                            }
                        }
                    }
                }
            }

            //Load money
            if (PlayerPrefs.HasKey(SAVE_COINS))
                MenuInventoryController.Instance.inventory.moneyInventory.amountCoins = PlayerPrefs.GetInt(SAVE_COINS);
            if (PlayerPrefs.HasKey(SAVE_BLUESCROLLS))
                MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls = PlayerPrefs.GetInt(SAVE_BLUESCROLLS);
            if (PlayerPrefs.HasKey(SAVE_PURPLESCROLLS))
                MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls = PlayerPrefs.GetInt(SAVE_PURPLESCROLLS);
            if (PlayerPrefs.HasKey(SAVE_REDSCROLLS))
                MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls = PlayerPrefs.GetInt(SAVE_REDSCROLLS);
        }
    }
}