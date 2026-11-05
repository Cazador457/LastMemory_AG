using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryIcon : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private int _buttonValue;
    [SerializeField] private ItemData _item;
    [SerializeField] private Button _iconButton;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _IconAmount;

    void Start()
    {
        _iconButton = GetComponent<Button>();
        _iconImage = GetComponent<Image>();
        _IconAmount=transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _iconImage.sprite = _item.Icon;
        _IconAmount.text = _item.Amount.ToString();
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
        Inventory.ItemSelect = _buttonValue;
        Inventory.RefreshUI();
        Debug.Log("InfoUpdate");
    }


}
