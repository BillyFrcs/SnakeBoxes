using UIGame;
using UnityEngine;

namespace Player
{
    public class SpawnSnake : MonoBehaviour
    {
        [SerializeField] private GameObject[] _SpawnSnake;

        private float _MinX = -6.87f;
        private float _MaxX = 17.24f;
        private float _MinZ = 22.7f;
        private float _MaxZ = 2.1f;
        private float _YPosition = 0.0f;

        public static SpawnSnake InstanceSpawnSnake;

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceSpawnSnake == null)
            {
                InstanceSpawnSnake = this;
            }
        }

        public void InstantiateSnake()
        {
            foreach (GameObject spawn in _SpawnSnake)
            {
                Instantiate(spawn, new Vector3(Random.Range(_MinX, _MaxX), _YPosition, Random.Range(_MinZ, _MaxZ)), Quaternion.identity);
            }
        }
    }
}
