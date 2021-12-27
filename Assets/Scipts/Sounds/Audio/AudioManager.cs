using UnityEngine;

namespace Sounds
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _AudioGame;

        public static AudioManager InstanceAudioManager;

        private void Awake()
        {
            if (InstanceAudioManager != null)
            {
                Destroy(gameObject);
            }
            else
            {
                InstanceAudioManager = this;

                DontDestroyOnLoad(transform.gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
