using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryIcon : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    [SerializeField] private Button _iconButton;
    [SerializeField] private Image _iconImage;

    void Start()
    {
        _iconButton = GetComponent<Button>();
        _iconImage = GetComponent<Image>();
        _iconImage.sprite = _item.Icon;
    }
    public void OnEnable()
    {
        _iconButton.onClick.AddListener(Icon);
    }
    public void OnDisable()
    {
        _iconButton.onClick.RemoveListener(Icon);
    }

    public void Icon()
    {
        Debug.Log("InfoUpdate");
    }


}
