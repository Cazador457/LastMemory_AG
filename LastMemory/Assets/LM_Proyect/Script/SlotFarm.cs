using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private PoolManager PoolManager;
    [SerializeField] private string[] Plant;
    private GameObject _CurrentPlant;
    private GameObject _NewPlant;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void StartFarm()
    {
        PoolManager.SpawnFromPool(Plant[Inventory.ItemSelect], _CurrentPlant.transform.position, _CurrentPlant.transform.rotation);
    }
    public void ChangePLantState()
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        Transform father = transform.parent;

        GameObject NewPrefab = Instantiate(_NewPlant, position, rotation, father);

        NewPrefab.transform.localScale = transform.localScale;
    }
}
