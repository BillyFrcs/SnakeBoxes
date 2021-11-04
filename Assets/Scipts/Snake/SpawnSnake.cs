using UnityEngine;

public class SpawnSnake : MonoBehaviour
{
    [SerializeField] private GameObject[] _SpawnSnake;

    public static SpawnSnake InstanceSpawnSnake;

    // Start is called before the first frame update
    void Start()
    {
        if (InstanceSpawnSnake == null)
        {
            InstanceSpawnSnake = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateSnake()
    {
        foreach (GameObject spawn in _SpawnSnake)
        {
            Instantiate(spawn, transform.position, Quaternion.identity);
        }
    }
}
