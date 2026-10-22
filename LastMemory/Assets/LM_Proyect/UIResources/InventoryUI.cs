using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    [Header("InventoryObjects")]
    [SerializeField] private ItemData[] AltarItems;
    public TextMeshProUGUI _name;
    public Image _icon;
    public TextMeshProUGUI _amount;
    public TextMeshProUGUI _description;
    public int ItemSelect=0;

    public void OnEnable()
    {
        if (AltarItems == null)
        {
            _name = null;
            _icon = null;
            _amount = null;
            _description = null;
        }
        if (AltarItems != null)
        {
            _name.text = AltarItems[ItemSelect].ID;
            _icon = AltarItems[ItemSelect].Icon;
            _amount.text = $"{AltarItems[ItemSelect].Amount}";
            _description.text = AltarItems[ItemSelect].Description;
        }
    }
}
