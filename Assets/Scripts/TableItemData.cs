using UnityEngine;

public class TableItemData
{
    [SerializeField] public int id { get; private set; }
    [SerializeField] public string name { get; private set; }

    public TableItemData(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}