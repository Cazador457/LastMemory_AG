using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData",menuName = "ItemData")]

public class ItemData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _tag;
    [SerializeField] private int _itemNum;
    [SerializeField] private int _amount;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;
    [SerializeField] private GameObject _modelPrefab;
    public string ID => _id;
    public string Tag => _tag;
    public int ItemNum => _itemNum;
    public Category CurrentResource;
    public int Amount
    {
        get{ return _amount; }
        set{ _amount = value; }
    }
    public Sprite Icon => _icon;
    public string Description => _description;
    public GameObject ModelPrefab => _modelPrefab;
}
public enum Category
{
    Altar_Resources,
    Monster_Resources,
    Farm_Resources
}
