using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RavenInputActions RavenInput;
    [SerializeField] private GameObject UI;
    private bool IsInventoryActive=false;

    [Header("InventoryObjects")]
    [SerializeField] private ItemData[] AltarItems;
    public TextMeshProUGUI _name;
    public Image _icon;
    public TextMeshProUGUI _amount;
    public TextMeshProUGUI _description;
    public int ItemSelect=0;

    public void InventoryActive()
    {
        if (RavenInput.InventoryPressed & !IsInventoryActive)
        {
            UI.SetActive(true);
            IsInventoryActive = true;
        }
        if (RavenInput.InventoryPressed & IsInventoryActive)
        {
            UI.SetActive(false);
            IsInventoryActive = false;
        }
    }
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
            _icon.sprite = AltarItems[ItemSelect].Icon;
            _amount.text = $"{AltarItems[ItemSelect].Amount}";
            _description.text = AltarItems[ItemSelect].Description;
        }
    }
}
