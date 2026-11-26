using System.Collections;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private Transform _SpawnPoint;
    [SerializeField] private int _SlotNum;
    private GameObject _CurrentPlant;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
           return;
        if (other.CompareTag("Player"))
        {
            Inventory.SlotTerrain = _SlotNum;
            Inventory.CanPlant = true;
            Debug.Log("Update SlotNum");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
           return;
        if (Inventory.SlotTerrain == _SlotNum)
            Inventory.CanPlant = false;
        
    }
    public void Harvest()
    {
        // Comprobar si existe una planta
        if (_CurrentPlant == null || !_CurrentPlant.activeSelf)
            return;
        _CurrentPlant.SetActive(false);
        _CurrentPlant = null;
    }
    public bool Planting(string Tag)
    {
        if (_CurrentPlant != null && _CurrentPlant.activeInHierarchy)
            return false;

        _CurrentPlant = PoolManager.Instance.SpawnFromPool(
            Tag,
            _SpawnPoint.position,
            _SpawnPoint.rotation
        );
        return _CurrentPlant != null;
    }
    IEnumerator PlantGrowing()
    {
        yield return new WaitForSeconds(2f);
    }
}
