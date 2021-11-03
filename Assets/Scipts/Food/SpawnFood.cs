using System.Collections;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;

    public static SpawnFood InstanceSpawnFood;

    [SerializeField] private float _MinX;
    [SerializeField] private float _MaxX;
    [SerializeField] private float _MinZ;
    [SerializeField] private float _MaxZ;
    [SerializeField] private float _YPosition;

    private float _spawned = 0.5f;

    private void Awake()
    {
        if (InstanceSpawnFood == null)
        {
            InstanceSpawnFood = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _MinX = -6.87f;
        _MaxX = 17.24f;

        _MinZ = 22.7f;
        _MaxZ = 2.1f;

        _YPosition = 0.31f;

        // Start spawned food
        Invoke(nameof(StartSpawning), _spawned);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartSpawning()
    {
        StartCoroutine(nameof(SpawnRandomFood));
    }

    private IEnumerator SpawnRandomFood()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));

        float randomAtPositionX = Random.Range(_MinX, _MaxX);

        float randomAtPositionZ = Random.Range(_MinZ, _MaxZ);

        if (FoodPrefab != null)
        {
            if (Random.Range(0, 10) >= 2)
            {
                Instantiate(FoodPrefab, new Vector3(randomAtPositionX, _YPosition, randomAtPositionZ), Quaternion.identity);
            }
        }

        Invoke(nameof(StartSpawning), 0f);
    }
}
