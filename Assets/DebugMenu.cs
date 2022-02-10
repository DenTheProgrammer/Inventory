using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    private Inventory inventory;
    public List<GameObject> weaponPrefabs;
    public List<GameObject> clothingPrefabs;
    public List<GameObject> consumablePrefabs;
    private void Start()
    {
        inventory = Inventory.Instance;
        GenerateItems();
    }

    public void ClearInventory()
    {
        inventory.DestroyAllItems();
    }

    public void GenerateItems(int number = 10)
    {
        for (int i = 0; i < number; i++)
        {
            AddRandomItemToInventoryFromList(weaponPrefabs);
            AddRandomItemToInventoryFromList(clothingPrefabs);
            AddRandomItemToInventoryFromList(consumablePrefabs);
        }
    }

    private void AddRandomItemToInventoryFromList(List<GameObject> itemsPrefabList)
    {
        GameObject randomPrefab = itemsPrefabList[Random.Range(0, itemsPrefabList.Count)];
        Debug.Log($"adding {randomPrefab.name} to {inventory}...");
        inventory.AddItemToTheInventory(randomPrefab);
    }
}
