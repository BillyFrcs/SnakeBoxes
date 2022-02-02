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
    }
}
