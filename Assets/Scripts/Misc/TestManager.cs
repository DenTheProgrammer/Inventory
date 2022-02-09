using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    
    public List<InvWeaponItem> weaponItems;
    public List<InvClothingItem> clothingItems;
    public List<InvConsumableItem> consumableItems;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            AddRandomItemToInventoryFromList(weaponItems);
            AddRandomItemToInventoryFromList(clothingItems);
            AddRandomItemToInventoryFromList(consumableItems);
        }

        Inventory.Instance.activeTab.AddItemToTheTab(consumableItems[0], "Test");
        Inventory.Instance.activeTab.AddItemToTheTab(clothingItems[0], "Test");
        Inventory.Instance.activeTab.AddItemToTheTab(clothingItems[0], "Test2");
        Inventory.Instance.LogInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void AddRandomItemToInventoryFromList<T>(List<T> items) where T : InvItem
    {
        InvItem randomItem = items[Random.Range(0, items.Count)];
        Debug.Log($"adding {randomItem.title} to inventory...");
        Inventory.Instance.AddItemToTheInventory(randomItem);
    }
}
