using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateGroupPrompt : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    
    public void CreateGroupFromInputField()
    {
        Inventory.Instance.activeTab.CreateNamedGroup(inputField.text);
        Inventory.Instance.DrawInventory();
    }
}
