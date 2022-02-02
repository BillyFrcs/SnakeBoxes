using UnityEngine;

namespace CameraGame
{
    internal interface ICameraFollow<V>
    {
        public void FollowPlayer(V NewPosition);
    }

    public class CameraFollow : MonoBehaviour, ICameraFollow<Vector3>
    {
        [Tooltip("Smooth Factor Interpolation")] [Range(0.1f, 5.0f)] [SerializeField] private float _smoothCameraFactor;

        private Transform _FollowTarget;
        
        private Vector3 _CameraOffset;

        public static CameraFollow InstanceCameraFollow;

        private void Awake()
        {
            if (InstanceCameraFollow == null)
            {
                InstanceCameraFollow = this;
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            _FollowTarget = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            
            _CameraOffset = gameObject.transform.position - _FollowTarget.transform.position;
        }

        // Late update is called after the Update method
        private void LateUpdate()
        {
            Vector3 NewTargetPosition = _FollowTarget.transform.position + _CameraOffset;

            FollowPlayer(NewTargetPosition);
        }

        /// <summary>
        /// Camera follow to the player 
        /// </summary>
        /// <param name="NewPosition">Vector3</param>
        public void FollowPlayer(Vector3 NewPosition) => gameObject.transform.position = Vector3.Slerp(transform.position, NewPosition, _smoothCameraFactor * Time.deltaTime);
    }
}
