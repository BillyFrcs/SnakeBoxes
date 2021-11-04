using UnityEngine;

public class CollectFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Deactivated spawned food
        Invoke(nameof(DestroyFood), Random.Range(3f, 6f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreSystem.score++;

        Destroy(gameObject);
    }

    private void DestroyFood() => Destroy(gameObject);
}