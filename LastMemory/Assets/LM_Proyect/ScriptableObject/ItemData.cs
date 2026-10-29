using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName = "NewItemData",menuName = "ItemData")]

public class ItemData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private int _itemNum;
    [SerializeField] private int _amount;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;
    public string ID => _id;
    public int ItemNum => _itemNum;
    public Category CurrentResource;
    public int Amount => _amount;
    public Sprite Icon => _icon;
    public string Description => _description;
}
public enum Category
{
    Altar_Resources,
    Monster_Resources,
    Farm_Resources
}
