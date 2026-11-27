using UnityEngine;

[CreateAssetMenu(fileName = "NewSeedData",menuName = "SeedData")]

public class SeedData : Scriptableobject
{
[SerializeField] private float _currentGrowingTime;
[SerializeField] private float _growingTime;
[SerializeField] private bool _isGrowing;
[SerializeField] private GameObject _initialState;
[SerializeField] private GameObject _GrowingState;
[SerializeField] private GameObject _HarvestState;

public float CurrentGrowingTime => _currentGrowingTime;
public float GrowingTime => _griwingTime;
public bool IsGrowing => _isGrowing;
public GameObject InitialState => _initialDtate;
public GameObject GrowingState => _growingState;
public GameObject HarvestState => _harvestState;
}