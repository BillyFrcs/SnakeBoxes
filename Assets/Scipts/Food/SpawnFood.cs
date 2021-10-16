using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;

    [SerializeField] private float _MinX;
    [SerializeField] private float _MaxX;
    [SerializeField] private float _MinZ;
    [SerializeField] private float _MaxZ;
    [SerializeField] private float _YPosition;

    // Start is called before the first frame update
    void Start()
    {
        _MinX = -6.87f;
        _MaxX = 17.24f;

        _MinZ = 22.7f;
        _MaxZ = 2.1f;

        _YPosition = 0.31f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRandomFood()
    {
        Instantiate(FoodPrefab, new Vector3(Random.Range(_MinX, _MaxX), _YPosition, Random.Range(_MinZ, _MaxZ)), Quaternion.identity);

        // Instantiate(FoodPrefab, new Vector3(Random.Range(_MinX, _MaxX), _YPosition, Random.Range(_MinZ, _MaxZ)), transform.rotation);
    }
}
