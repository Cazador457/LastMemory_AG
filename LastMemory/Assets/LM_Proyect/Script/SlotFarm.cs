using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private string[] Plant;
    private GameObject _CurrentPlant;

    public void StartFarm()
    {
       if (_CurrentPlant != null && _CurrentPlant.activeSelf)
            return; 
       PoolManager.Instance.SpawnFromPool(Plant[Inventory.ItemSelect], _CurrentPlant.transform.position, _CurrentPlant.transform.rotation);
    }
    public void Harvest()
    {
        // Comprobar si existe una planta
        if (_CurrentPlant == null || !_CurrentPlant.activeSelf)
            return;
        _CurrentPlant.SetActive(false);
        _CurrentPlant = null;
    }
}
