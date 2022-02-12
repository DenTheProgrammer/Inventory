using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveLoadInventory : MonoBehaviour
{
    public string SAVEFILE_NAME;
    private string SAVE_PATH;
    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;
        SAVE_PATH = Application.dataPath + "/Saves/";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

    }


/*    public void SaveInventory()
    {
        InventorySaveObject inventorySaveObject = new InventorySaveObject();
        foreach (InvTab tab in inventory.tabs)
        {
            foreach (KeyValuePair<string, InvGroupNamed> groupEntry in tab.groups)
            {
                foreach (InvItem item in groupEntry.Value.items)
                {
                    inventorySaveObject.items.Add(new ItemSaveObject(item.title, item.currentGroup.groupTitle));
                    Debug.Log(item.title);
                }
            }

            foreach (InvItem item in tab.defaultGroup.items)
            {
                inventorySaveObject.items.Add(new ItemSaveObject(item.title));
            }
        }
        string savedInventory = JsonUtility.ToJson(inventorySaveObject, true);
        File.WriteAllText(SAVE_PATH + SAVEFILE_NAME, savedInventory);
        Debug.Log(savedInventory);
    }

    public void LoadInventory()
    {
        inventory.DestroyAllItems();
        string savedInventory = File.ReadAllText(SAVE_PATH + SAVEFILE_NAME);
        InventorySaveObject inventorySaveObject = JsonUtility.FromJson<InventorySaveObject>(savedInventory);
        foreach (ItemSaveObject itemSaveObject in inventorySaveObject.items)
        {
            GameObject itemPrefab = (GameObject)Resources.Load(itemSaveObject.itemTitle);
            InvItem addedItem = inventory.AddItemToTheInventory(itemPrefab);
            if (!itemSaveObject.groupName.Equals(""))//was not in default group
            {
                addedItem.currentTab.CreateNamedGroup(itemSaveObject.groupName);
                addedItem.MoveToAnotherGroup(addedItem.currentTab.groups[itemSaveObject.groupName]);
            }
        }
    }*/

    public void SaveInventory()
    {
        InventorySaveObject inventorySaveObject = new InventorySaveObject();
        foreach (InvTab tab in inventory.tabs)
        {
            TabSaveObject tabSaveObject = new TabSaveObject(tab.tabType);
            foreach (KeyValuePair<string, InvGroupNamed> groupEntry in tab.groups)
            {
                GroupSaveObject groupSaveObject = new GroupSaveObject(groupEntry.Key);
                foreach (InvItem item in groupEntry.Value.items)
                {
                    ItemSaveObject itemSaveObject = new ItemSaveObject(item.title);
                    groupSaveObject.itemList.Add(itemSaveObject);
                }
                tabSaveObject.groupList.Add(groupSaveObject);
            }
            GroupSaveObject defaultGroupSaveObject = new GroupSaveObject(null);
            foreach (InvItem item in tab.defaultGroup.items)
            {
                ItemSaveObject itemSaveObject = new ItemSaveObject(item.title);
                defaultGroupSaveObject.itemList.Add(itemSaveObject);
            }
            tabSaveObject.groupList.Add(defaultGroupSaveObject);
            inventorySaveObject.tabs.Add(tabSaveObject);
        }
        string savedInventory = JsonUtility.ToJson(inventorySaveObject, true);
        File.WriteAllText(SAVE_PATH + SAVEFILE_NAME, savedInventory);
        Debug.Log(savedInventory);
    }
}

[Serializable]
public class InventorySaveObject
{
    public List<TabSaveObject> tabs;

    public InventorySaveObject()
    {
        this.tabs = new List<TabSaveObject>();
    }
}

[Serializable]
public class TabSaveObject
{
    public ItemType tabType;
    public List<GroupSaveObject> groupList;

    public TabSaveObject(ItemType tabType)
    {
        this.groupList = new List<GroupSaveObject>();
        this.tabType = tabType;
    }
}

[Serializable]
public class GroupSaveObject
{
    public string groupTitle;
    public List<ItemSaveObject> itemList;
    public GroupSaveObject(string groupTitle)
    {
        this.itemList = new List<ItemSaveObject>();
        this.groupTitle = groupTitle;
    }
}

[Serializable]
public class ItemSaveObject
{
    public string itemTitle;
    public ItemSaveObject(string itemTitle)
    {
        this.itemTitle = itemTitle;
    }
}