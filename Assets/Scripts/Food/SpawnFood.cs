using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Food
{
    public class SpawnFood : MonoBehaviour
    {
        public List<GameObject> FoodPrefab = new List<GameObject>();

        private GameObject _SpawnFood;

        public static SpawnFood InstanceSpawnFood;

        [SerializeField] private float _MinX;
        [SerializeField] private float _MaxX;
        [SerializeField] private float _MinZ;
        [SerializeField] private float _MaxZ;
        [SerializeField] private float _YPosition;

        private float _spawned = 0.5f;
        private int _randomIndex;

        private void Awake()
        {
            if (InstanceSpawnFood == null)
            {
                InstanceSpawnFood = this;
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            _MinX = -6.87f;
            _MaxX = 17.24f;

            _MinZ = 22.7f;
            _MaxZ = 2.1f;

            _YPosition = -0.16f;

            // Start spawned food
            Invoke(nameof(StartSpawning), _spawned);
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
                    _randomIndex = Random.Range(0, FoodPrefab.Count);

                    _SpawnFood = Instantiate(FoodPrefab[_randomIndex], new Vector3(randomAtPositionX, _YPosition, randomAtPositionZ), Quaternion.identity);
                }
            }

            Invoke(nameof(StartSpawning), 0f);
        }
    }
}
