using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class TableController : MonoBehaviour
{
    [SerializeField] private List<TableItemData> Items = GetTableItemsInitList();
    private int lastId;

    [SerializeField] private Button addButton;
    [SerializeField] private Button removeButton;

    [SerializeField] private TableItem currentTableItem;

    [SerializeField] private PreviewRenderController renderController;
    [SerializeField] private GameObject content;
    [SerializeField] private TableItem TableItemPrefab;

    public void Awake()
    {
        addButton.onClick.AddListener(Add);
        removeButton.onClick.AddListener(Remove);
        ReInitList(content, TableItemPrefab);
        lastId = Items.Max(e => e.id);
    }

    private T GetRandomItemFromList<T>(List<T> list)
    {
        var max = list.Count;
        var randomValue = Random.Range(0, max - 1);
        return list[randomValue];
    }

    public void ReInitList<T>(GameObject contentContainer, T prefab) where T : TableItem
    {
        contentContainer.DestroyChilds();
        foreach (var item in Items)
        {
            AddToGameObject(content, prefab, item);
        }
    }

    public void AddToGameObject<T>(GameObject contentContainer, T prefab, TableItemData item) where T : TableItem
    {
        var gO = Instantiate(prefab, contentContainer.transform);
        var model = renderController.Models.SingleOrDefault(e => e.name == item.name);
        gO.Init(item, model);
        gO.tableController = this;
    }

    public void Add()
    {
        var randomModel = GetRandomItemFromList(renderController.Models);
        lastId++;
        var newItem = new TableItemData(lastId, randomModel.name);
        Items.Add(newItem);

        AddToGameObject(content, TableItemPrefab, newItem);
    }

    public void Remove()
    {
        if (currentTableItem != null)
        {
            Items.Remove(currentTableItem.Data);
            Destroy(currentTableItem.gameObject);
            currentTableItem = null;
        }
    }

    public void ClickTableItem(TableItem tableItem)
    {
        currentTableItem = tableItem;
        renderController.Activate(tableItem.viewTargetObject);
    }

    // Обычно в юнити делают просто открытый лист и добавляют туда, но тут просто решил так сделать, так быстрее
    private static List<TableItemData> GetTableItemsInitList()
    {
        var result = new List<TableItemData>()
        {
            new(1, "Cube"),
            new(2, "Sphere"),
            new(3, "Quad"),
            new(4, "Cube"),
            new(5, "Sphere"),
            new(6, "Quad"),
            new(7, "Cube"),
            new(8, "Sphere"),
            new(9, "Quad"),
            new(10, "Quad")
        };

        return result;
    }
}