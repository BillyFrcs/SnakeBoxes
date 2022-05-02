using UnityEngine;
using UIGame;

namespace Player
{
    public class SnakeCollider : MonoBehaviour
    { 
        public static SnakeCollider InstanceSnakeCollider;

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceSnakeCollider == null)
            {
                InstanceSnakeCollider = this;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Sides"))
            {
                // Display game over screen
                GameOver.InstanceGameover.DisplayGameOverScreen();
                
                // Display score game
                ScoreSystem.InstanceScoreSystem.DisplayScoreGame();
                
                if (SnakeController.InstanceSnakeController != null)
                {
                    SnakeController.InstanceSnakeController.InstantiateDeadVFX();
                }

                Destroy(this.gameObject);
                
                // Debug.LogAssertion("Game Over"); // DEBUG ASSERTION
            }
        }
    }
}
