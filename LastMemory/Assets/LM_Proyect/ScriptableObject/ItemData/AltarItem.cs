using UnityEngine;

public class AltarItem : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryUI Inventory = other.GetComponent<InventoryUI>();
            
            
        }
    }
}
