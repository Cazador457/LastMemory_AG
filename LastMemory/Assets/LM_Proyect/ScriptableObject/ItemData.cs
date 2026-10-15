using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewItemData",menuName = "ItemData")]

public class ItemData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _description;
    [SerializeField] private int _value;
    public string ID => _id;
    public string Description => _description;
    public int Value => _value;
}
