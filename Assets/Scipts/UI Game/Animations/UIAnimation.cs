using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public static UIAnimation InstanceUIAnimation;

    private Animator _UIAnimator;

    private void Awake()
    {
        _UIAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (InstanceUIAnimation == null)
        {
            InstanceUIAnimation = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonAnimation()
    {
        _UIAnimator.SetTrigger("Play");
    }
}
