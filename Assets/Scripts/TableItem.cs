using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableItem : MonoBehaviour
{
    // DI
    [SerializeField] public TableController tableController;
    //


    public TableItemData Data;
    [SerializeField] private TextMeshProUGUI id;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] public GameObject viewTargetObject;


    [SerializeField] private Button activateButton;

    public void Init(TableItemData data, GameObject targetObject)
    {
        Data = data;
        id.text = Data.id.ToString();
        name.text = Data.name;
        viewTargetObject = targetObject;
    }

    public void Awake()
    {
        activateButton.onClick.AddListener(Activate);
    }

    public void Activate()
    {
        tableController.ClickTableItem(this);
    }
}