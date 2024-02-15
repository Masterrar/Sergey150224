using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

public class TableController : MonoBehaviour
{
    [SerializeField] private List<TableItemData> Items = GetTableItemsInitList();
    private int lastId;

    [SerializeField] private PreviewRenderController _renderController;
    [SerializeField] private GameObject content;
    [SerializeField] private TableItem TableItemPrefab;
    public void Awake()
    {
        ReInitList(content, TableItemPrefab);
        lastId = Items.Max(e => e.id);
    }
    
    private T GetRandomItemFromList<T>(List<T> list)
    {
        var max = list.Count;
        var randomValue = Random.Range(0, max - 1);
        return list[randomValue];
    }
    public void ReInitList<T>(GameObject contentContainer, T prefab) where T:TableItem
    {
        contentContainer.DestroyChilds();
        foreach (var item in Items)
        {
            AddToGameObject(content, prefab, item);
        }
    }
    public void AddToGameObject<T>(GameObject contentContainer, T prefab, TableItemData item) where T:TableItem
    {
        var gO = Instantiate(prefab, contentContainer.transform);
        var model = _renderController.Models.SingleOrDefault(e => e.name == item.name);
        gO.Init(item, model);
        gO.renderController = _renderController;
    }
    
    public void Add()
    {
        var randomModel = GetRandomItemFromList(_renderController.Models);
        lastId++;
        var newItem = new TableItemData(lastId, randomModel.name);
        Items.Add(newItem);
        
        AddToGameObject(content, TableItemPrefab, newItem);
    }
    public void Remove(TableItem removeObject)
    {
        Items.Remove(removeObject.Data);
        Destroy(removeObject);
    }
    
    // Обычно в юнити делают просто открытый лист и добавляют туда, но тут просто решил так сделать, так быстрее
    private static List<TableItemData> GetTableItemsInitList()
    {
        var result = new List<TableItemData>()
        {
            new TableItemData(1, "Cube"),
            new TableItemData(2, "Sphere"),
            new TableItemData(3, "Quad"),
            new TableItemData(4, "Cube"),
            new TableItemData(5, "Sphere"),
            new TableItemData(6, "Quad"),
            new TableItemData(7, "Cube"),
            new TableItemData(8, "Sphere"),
            new TableItemData(9, "Quad"),
            new TableItemData(10, "Quad"),
        };

        return result;
    }
}
