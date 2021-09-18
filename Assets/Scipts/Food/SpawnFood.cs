using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;

    private float MinX;
    private float MaxX;
    private float YPosition;
    private float ZPosition;

    public SpawnFood()
    {
        MinX = -5.32f;
        MaxX = 13.73f;

        YPosition = 0.6f;
        ZPosition = 7.93f;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomFood());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRandomFood()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 1.0f));

        if(Random.Range(0, 10) >= 2)
        {
            Instantiate(FoodPrefab, new Vector3(Random.Range(MinX, MaxX), YPosition, ZPosition), Quaternion.identity);
        }

        // Use this to spawn food every second
        Invoke("Start", Random.Range(1.0f, 1.0f));
    }
}
