using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableItem : MonoBehaviour
{
    // DI
    [SerializeField] public PreviewRenderController renderController;
    //

    
    public TableItemData Data;
    [SerializeField] private TextMeshProUGUI id;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private GameObject viewTargetObject;
    
    
    [SerializeField] private Button activateButton;

    public void Init(TableItemData data, GameObject targetObject)
    {
        this.Data = data;
        this.id.text = Data.id.ToString();
        this.name.text = Data.name;
        this.viewTargetObject = targetObject;
    }
    public void Awake()
    {
        activateButton.onClick.AddListener(Activate);
    }

    public void Activate()
    {
        renderController.Activate(viewTargetObject);
    }
}
