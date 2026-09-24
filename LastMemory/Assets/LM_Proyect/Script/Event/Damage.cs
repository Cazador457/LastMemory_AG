using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 15f;
    public bool blocked=false;
    public void OnTriggerEnter(Collider other)
    {
        if(blocked) return;

        if(other.CompareTag("Shield"))
        {   
            Debug.Log("block activate");
            blocked=true;
        }

        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            blocked = false;
        }
        
    }
}
