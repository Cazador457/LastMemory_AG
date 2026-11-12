using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryIcon : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private int _buttonValue;
    [SerializeField] private ItemData _item;
    [SerializeField] private Button _iconButtonRefresh;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _IconAmount;
    [SerializeField] private Button _IconButtonFarm;

    private void Awake()
    {
        _iconButtonRefresh = GetComponent<Button>();
        _iconImage = GetComponent<Image>();
        _IconAmount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _IconButtonFarm = transform.GetChild(1).GetComponent<Button>();
    }
    void Start()
    {
        
        _iconImage.sprite = _item.Icon;
        _IconAmount.text = _item.Amount.ToString();
    }
    public void OnEnable()
    {
        _iconButtonRefresh.onClick.AddListener(Icon);
        _IconButtonFarm.onClick.AddListener(Farm);
    }
    public void OnDisable()
    {
        _iconButtonRefresh.onClick.RemoveListener(Icon);
        _IconButtonFarm.onClick.RemoveListener(Farm);
    }

    public void Icon()
    {
        Inventory.ItemSelect = _buttonValue;
        Inventory.RefreshUI();
        Debug.Log("InfoUpdate");
    }
    public void Farm()
    {
        SlotFarm Planted= Inventory.FarmTerrain[Inventory.SlotTerrain].GetComponent<SlotFarm>();
        Planted.Planting(_item.Tag);
    }


}
