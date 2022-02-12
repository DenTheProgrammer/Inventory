using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class SaveLoadInventory : MonoBehaviour
{
    public string SAVEFILE_NAME;
    private string SAVE_PATH;
    private Inventory inventory;
    private JsonSerializerSettings jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
    private void Start()
    {
        inventory = Inventory.Instance;
        SAVE_PATH = Application.dataPath + "/Saves/";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

    }

    public void SaveInventory()
    {
        InventorySaveObject inventorySaveObject = new InventorySaveObject();
        foreach (InvTab tab in inventory.tabs)
        {
            TabSaveObject tabSaveObject = new TabSaveObject(tab.tabType, tab.tabTitle);
            foreach (KeyValuePair<string, InvGroupNamed> groupEntry in tab.groups)
            {
                GroupSaveObject groupSaveObject = new GroupSaveObject(groupEntry.Key);
                foreach (InvItem item in groupEntry.Value.items)
                {
                    groupSaveObject.itemList.Add(item.CreateSaveObject());
                }
                tabSaveObject.groupList.Add(groupSaveObject);
            }
            GroupSaveObject defaultGroupSaveObject = new GroupSaveObject(null);
            foreach (InvItem item in tab.defaultGroup.items)
            {
                defaultGroupSaveObject.itemList.Add(item.CreateSaveObject());
            }
            tabSaveObject.groupList.Add(defaultGroupSaveObject);
            inventorySaveObject.tabs.Add(tabSaveObject);
        }
        
        string savedInventory = JsonConvert.SerializeObject(inventorySaveObject, jsonSettings);
        File.WriteAllText(SAVE_PATH + SAVEFILE_NAME, savedInventory);
        Debug.Log(savedInventory);
    }

    public void LoadInventory()
    {
        inventory.DestroyAllItems();
        string savedInventory = File.ReadAllText(SAVE_PATH + SAVEFILE_NAME);
        InventorySaveObject inventorySaveObject = JsonConvert.DeserializeObject<InventorySaveObject>(savedInventory, jsonSettings);

        foreach (TabSaveObject tabSaveObject in inventorySaveObject.tabs)
        {
            foreach (GroupSaveObject groupSaveObject in tabSaveObject.groupList)
            {
                if (groupSaveObject.groupTitle == null)//add items to default group
                {
                    foreach (ItemSaveObject itemSaveObject in groupSaveObject.itemList)
                    {
                        GameObject itemPrefab = (GameObject)Resources.Load(itemSaveObject.itemTitle);
                        InvItem addedItem = inventory.AddItemToTheInventory(itemPrefab);
                        addedItem.LoadFromSaveObject(itemSaveObject);
                    }
                }
                else //create named group and add items to it
                {
                    foreach (ItemSaveObject itemSaveObject in groupSaveObject.itemList)
                    {
                        GameObject itemPrefab = (GameObject)Resources.Load(itemSaveObject.itemTitle);
                        InvItem addedItem = inventory.AddItemToTheInventory(itemPrefab);
                        addedItem.LoadFromSaveObject(itemSaveObject);
                        addedItem.currentTab.CreateNamedGroup(groupSaveObject.groupTitle);
                        addedItem.MoveToAnotherGroup(addedItem.currentTab.groups[groupSaveObject.groupTitle]);
                    }
                }
            }
        }
    }


}

[Serializable]
public class InventorySaveObject
{
    public List<TabSaveObject> tabs;

    public InventorySaveObject()
    {
        tabs = new List<TabSaveObject>();
    }
}

[Serializable]
public class TabSaveObject
{
    public string tabTitle; //not nessesary, only for better readability
    public ItemType tabType;
    public List<GroupSaveObject> groupList;

    public TabSaveObject(ItemType tabType, string tabTitle)
    {
        groupList = new List<GroupSaveObject>();
        this.tabType = tabType;
        this.tabTitle = tabTitle;
    }
}

[Serializable]
public class GroupSaveObject
{
    public string groupTitle;
    public List<ItemSaveObject> itemList;
    public GroupSaveObject(string groupTitle)
    {
        itemList = new List<ItemSaveObject>();
        this.groupTitle = groupTitle;
    }
}

[Serializable]
public class ItemSaveObject
{
    public string itemTitle;
    public int type;
    public int level;
    public ItemSaveObject(string itemTitle, int type, int level)
    {
        this.itemTitle = itemTitle;
        this.type = type;
        this.level = level;
    }
}