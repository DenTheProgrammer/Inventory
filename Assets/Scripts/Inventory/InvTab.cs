using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvTab : MonoBehaviour
{
    public string displayName;
    public ItemType tabType; //same type as Items in it
    public Vector3 nextEmptySlot;
    [SerializeField]
    private List<InvGroup> groups;
    [SerializeField]
    private GameObject groupPrefab;
    private InvGroupDefault defaultGroup;

    private void Awake()
    {
        gameObject.name = displayName;
        GetComponentInChildren<TextMeshProUGUI>().text = displayName;
    }

    public void AddItemToTheTab(InvItem item)
    {
        if (defaultGroup == null)
        {
            GameObject groupDefault = Instantiate(groupPrefab, Inventory.Instance.topLeft);
            groupDefault.name = "default group";
            groupDefault.transform.SetParent(gameObject.transform);
            groupDefault.AddComponent<InvGroupDefault>();
            defaultGroup = groupDefault.GetComponent<InvGroupDefault>();
        }
        defaultGroup.AddItemToGroup(item); 
    }

    public void RemoveItemFromTheTab(InvItem item)
    {
        foreach (InvGroup group in groups)
        {
            group.RemoveItemFromTheGroup(item);
        }
        defaultGroup.RemoveItemFromTheGroup(item);
    }

    public void HideTab()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

    public void DrawTab()
    {
        nextEmptySlot = new Vector2(Inventory.Instance.topLeft.position.x, Inventory.Instance.topLeft.position.y);
        //Debug.Log(nextEmptySlot);
        /*foreach (Transform child in transform)
            child.gameObject.SetActive(true);*/
        foreach (InvGroup group in groups)
        {
            nextEmptySlot = group.DrawGroup(nextEmptySlot);
        }
        nextEmptySlot = defaultGroup.DrawGroup(nextEmptySlot);
        //Debug.Log(nextEmptySlot);
    }

    public void ClearTab()
    {
        //TODO
        /*defaultGroup.???
        groups = null;*/
    }


    public void LogTab()
    {
        Debug.Log($"Tab \"{displayName}\":");
        foreach (InvGroup group in groups)
        {
            group.LogGroup();
        }
        defaultGroup.LogGroup();
    }
}


