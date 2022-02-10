using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    
    public List<GameObject> weaponPrefabs;
    public List<GameObject> clothingPrefabs;
    public List<GameObject> consumablePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            AddRandomItemToInventoryFromList(weaponPrefabs);
            AddRandomItemToInventoryFromList(clothingPrefabs);
            AddRandomItemToInventoryFromList(consumablePrefabs);
        }

        
        Inventory.Instance.LogInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void AddRandomItemToInventoryFromList(List<GameObject> itemsPrefabList)
    {
        GameObject randomPrefab = itemsPrefabList[Random.Range(0, itemsPrefabList.Count)];
        Debug.Log($"adding {randomPrefab.name} to inventory...");
        Inventory.Instance.AddItemToTheInventory(randomPrefab);
    }
}
