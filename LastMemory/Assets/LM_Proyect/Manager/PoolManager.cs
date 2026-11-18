using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        public ItemData Item;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.Item.ModelPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.Item.Tag, objectPool);
        }

    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"No existe el tag {tag} en el PoolManager");
            return null;
        }

        foreach (GameObject obj in poolDictionary[tag])
        {
            if (!obj.activeInHierarchy).      { obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);

                 return obj;
            }
        }
        Pool pool = pools.Find(p => p.Item.Tag == tag);

    if (pool == null)
        return null;
        GameObject newObject = Instantiate(pool.Item.ModelPrefab);

    newObject.transform.SetPositionAndRotation(position, rotation);
    newObject.SetActive(true);
        poolDictionary[tag].Enqueue(newObject);

    return newObject;
        /*GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;*/
    }
}
