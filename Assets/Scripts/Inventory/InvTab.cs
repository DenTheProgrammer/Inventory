using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InvTab : MonoBehaviour
{
    public string tabTitle;
    public ItemType tabType; //same type as Items in it
    public Vector3 nextEmptySlot;
    public InvGroupDefault defaultGroup;
    public Dictionary<string, InvGroupNamed> groups;
    [SerializeField]
    private GameObject groupPrefab;

    private void Awake()
    {
        gameObject.name = tabTitle;
        groups = new Dictionary<string, InvGroupNamed>();
        GetComponentInChildren<TextMeshProUGUI>().text = tabTitle;
        if (defaultGroup == null)
        {
            GameObject groupDefault = Instantiate(groupPrefab);
            groupDefault.name = "default group";
            groupDefault.transform.SetParent(gameObject.transform);
            groupDefault.AddComponent<InvGroupDefault>();
            defaultGroup = groupDefault.GetComponent<InvGroupDefault>();
            defaultGroup.itemsType = tabType;
        }
    }

    public void AddItemToTheTab(InvItem item)
    {
        item.currentTab = this;
        defaultGroup.AddItemToGroup(item);
    }

    public void AddItemToTheTab(InvItem item, string groupName)
    {
        if (groupName == null || groupName == "")
        {
            defaultGroup.AddItemToGroup(item);
        }
        if (!groups.ContainsKey(groupName))//group with new name
        {
            CreateNamedGroup(groupName);
        }
        groups[groupName].AddItemToGroup(item);
    }

    public void CreateNamedGroup(string groupTitle)
    {
        if (groups.ContainsKey(groupTitle) || groupTitle == null || groupTitle == "")
            return;
        GameObject newGroupGO = Instantiate(groupPrefab, Inventory.Instance.topLeft);
        newGroupGO.name = groupTitle;
        newGroupGO.transform.SetParent(gameObject.transform);
        newGroupGO.AddComponent<InvGroupNamed>();
        InvGroupNamed newGroup = newGroupGO.GetComponent<InvGroupNamed>();
        newGroup.groupTitle = groupTitle;
        newGroup.itemsType = tabType;
        groups.Add(groupTitle, newGroup);
    }

    public void RemoveItemFromTheTab(InvItem item)
    {
        foreach (KeyValuePair<string, InvGroupNamed> keyValue in groups)
        {
            keyValue.Value.RemoveItemFromTheGroup(item);
        }
        defaultGroup.RemoveItemFromTheGroup(item);
    }


    public void DestroyItemsInTab()
    {
        foreach (KeyValuePair<string, InvGroupNamed> groupEntry in groups)
        {
            groupEntry.Value.DestroyItemsInGroup();
            Destroy(groupEntry.Value.gameObject);
        }
        groups = new Dictionary<string, InvGroupNamed>();
        defaultGroup.DestroyItemsInGroup();
    }

    public void HideTab()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<TextMeshProUGUI>())
                continue;  //ignore tabs title text
            child.gameObject.SetActive(false);
        }
    }

    public void DrawTab()
    {
        nextEmptySlot = new Vector2(Inventory.Instance.topLeft.position.x, Inventory.Instance.topLeft.position.y);
        //Debug.Log(nextEmptySlot);
        /*foreach (Transform child in transform)
            child.gameObject.SetActive(true);*/

        foreach (KeyValuePair<string, InvGroupNamed> keyValue in groups)
        {
            nextEmptySlot = keyValue.Value.DrawGroup(nextEmptySlot);
        }

        nextEmptySlot = defaultGroup.DrawGroup(nextEmptySlot);

        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
        //Debug.Log(nextEmptySlot);
    }

    public void OnTabButtonPress()
    {
        Inventory.Instance.ChangeActiveTab(this);
    }
    public void LogTab()
    {
        Debug.Log($"Tab \"{tabTitle}\":");
        if (groups == null) return;
        foreach (KeyValuePair<string, InvGroupNamed> entry in groups)
        {
            entry.Value.LogGroup();
        }
        if (defaultGroup)
            defaultGroup.LogGroup();
    }
}


