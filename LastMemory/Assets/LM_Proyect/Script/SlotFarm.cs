using System.Collections;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private InventoryUI Inventory;
    [SerializeField] private string[] Plant;
    [SerializeField] private GameObject[] PlanyState;
    private GameObject _CurrentPlant;
    private Coroutine IsPlanted;

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

    IEnumerator PlantGrowing()
    {

        yield return new WaitForSeconds(2f);
    }
}
