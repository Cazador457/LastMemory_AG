using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private ItemData Item;
    public int Value;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            AddValue(Value);
        }
    }
    public void AddValue(int cantidad)
    {
        if (Item != null)
        {
            Item.Amount += cantidad;
            gameObject.SetActive(false);
        }
    }
}
