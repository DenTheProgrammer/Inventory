using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{

    public TextMeshProUGUI headerText;
    public TextMeshProUGUI contentText;
    public bool dynamicPivot;
    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetText(string header, string content)
    {
        headerText.text = header;
        contentText.text = content;
    }

    private void Update()
    {
        Vector2 position = Input.mousePosition;
        if (dynamicPivot)
        {
            float pivotX = position.x / Screen.width;
            float pivotY = position.y / Screen.height;
            rectTransform.pivot = new Vector2(pivotX, pivotY);
        }
        transform.position = position;
    }
}
