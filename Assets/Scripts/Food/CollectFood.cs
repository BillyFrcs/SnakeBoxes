using UnityEngine;
using UIGame;

namespace Food
{
    public class CollectFood : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            // Deactivated spawned food
            Invoke(nameof(DestroyFood), Random.Range(3f, 6f));
        }

        private void OnTriggerEnter(Collider other)
        {
            ScoreSystem.InstanceScoreSystem.IncreaseScoreGame++;

            Destroy(gameObject);
        }

        private void DestroyFood() => Destroy(gameObject);
    }
}