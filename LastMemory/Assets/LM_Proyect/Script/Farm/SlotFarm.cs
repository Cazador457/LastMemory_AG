using System.Collections;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private GameObject _CurrentPlant;
    [SerializeField] private int _SlotNum;
    private Coroutine IsPlanted;

    private void Awake()
    {
        _CurrentPlant = transform.GetChild(0).GetComponent<GameObject>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.SlotTerrain = _SlotNum;
            Inventory.CanPlant = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.CanPlant = false;
        }
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
        _CurrentPlant = PoolManager.Instance.SpawnFromPool(Tag, _CurrentPlant.transform.position, _CurrentPlant.transform.rotation);
    }
    IEnumerator PlantGrowing()
    {

        yield return new WaitForSeconds(2f);
    }
}
