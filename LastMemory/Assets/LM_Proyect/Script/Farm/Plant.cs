using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private ItemData PlantData;
    [SerializeField] private GameObject[] PlantState;
    [SerializeField] private float[] GrowingTime;

    Coroutine PlantGrowing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GrowingState()
    {
        
        yield return new WaitForSeconds(GrowingTime[0]);
        yield return new WaitForSeconds(GrowingTime[1]);
        yield return new WaitForSeconds(GrowingTime[2]);
    }
}
