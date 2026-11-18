using System.Collections;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private int _SlotNum;
    private GameObject _CurrentPlant;
    private Coroutine IsPlanted;

    private void Awake()
    {
        _CurrentPlant = transform.GetChild(0).gameObject;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
           return;

        Inventory.SlotTerrain = _SlotNum;
        Inventory.CanPlant = true;
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
    public void Planting(string Tag)
    {
        if (_CurrentPlant != null && _CurrentPlant.activeSelf)
            return;

        _CurrentPlant = PoolManager.Instance.SpawnFromPool(
            Tag,
            _SpawnPoint.position,
            _SpawnPoint.rotation
        );
    }
    IEnumerator PlantGrowing()
    {

        yield return new WaitForSeconds(2f);
    }
}
