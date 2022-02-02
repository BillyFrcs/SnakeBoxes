using UnityEngine;
using UIGame;
using CameraGame;

namespace Player
{
    public class BodySnakeCollider : MonoBehaviour
    {
        [SerializeField] private GameObject _SnakeObject;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Body"))
            {
                if (SnakeController.InstanceSnakeController != null)
                {
                    SnakeController.InstanceSnakeController.InstantiateDeadVFX();
                }
                
                CameraFollow.InstanceCameraFollow.enabled = false;
                
                // Game over
                GameOver.InstanceGameover.DisplayGameOverScreen();
                
                // Display score game
                ScoreSystem.InstanceScoreSystem.DisplayScoreGame();

                Destroy(_SnakeObject);

                // Debug.LogAssertion("Game Over"); // DEBUG ASSERTION
            }
        }
    }
}
