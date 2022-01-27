using UnityEngine;

namespace UIGame
{
    public class UIAnimation : MonoBehaviour
    {
        public static UIAnimation InstanceUIAnimation;

        private Animator _UIAnimator;

        private void Awake()
        {
            _UIAnimator = GetComponent<Animator>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceUIAnimation == null)
            {
                InstanceUIAnimation = this;
            }
        }

        public void PlayButtonAnimation()
        {
            _UIAnimator.SetTrigger("Play");
        }
    }
}
