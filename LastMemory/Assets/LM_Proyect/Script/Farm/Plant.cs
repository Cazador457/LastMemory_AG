using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private ItemData PlantData;
    //[SerializeField] private SeedData Seed;
    //[SerializeField] private GameObject[] PlantState;
    //[SerializeField] private float[] GrowingTime;
    public float growingTime = 0;
    public float harvestState = 15.5f;
    Coroutine GrowingTime;
    void Start()
    {
        
    }
    void Update()
    {
        //Growing();
        Debug.Log($"{growingTime}");
    }
    public void Growing()
    {
        if (growingTime <= harvestState)
            growingTime += Time.deltaTime;
        if (growingTime >= harvestState)
            growingTime = harvestState;
        Debug.Log("Cosechable");
    }
    public void Harvest()
    {

    }
    IEnumerator GrowingState()
    {
        yield return new WaitForSeconds(2f);
    }
}
