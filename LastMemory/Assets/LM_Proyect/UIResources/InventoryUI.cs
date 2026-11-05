using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RavenInputActions RavenInput;
    [SerializeField] private GameObject UI;

    [Header("InventoryObjects")]
    [SerializeField] private ItemData[] AltarItems;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amount;
    [SerializeField] private TextMeshProUGUI _description;
    public int ItemSelect=0;

    public void OnEnable()
    {
        RavenInput.InventoryPerformed += InventoryActive;
        RefreshUI();
    }
    public void OnDisable()
    {
        RavenInput.InventoryPerformed -= InventoryActive;
    }
    public void InventoryActive()
    {
        bool IsOpen= !UI.activeSelf;
        UI.SetActive(IsOpen);
        if (IsOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void RefreshUI()
    {
        if (AltarItems == null || AltarItems.Length == 0)
            return;

        _name.text = AltarItems[ItemSelect].ID;
        _icon.sprite = AltarItems[ItemSelect].Icon;
        _amount.text = AltarItems[ItemSelect].Amount.ToString();
        _description.text = AltarItems[ItemSelect].Description;
    }
}
