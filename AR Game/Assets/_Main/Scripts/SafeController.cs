using AR.UI.VFX;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    private static int _fullAnimation;
    private static int _spinAnimation;
    private static int _openAnimation;
    private static int _idleAnimation;
    
    [Header("Animator")]
    [SerializeField] private Animator animator;
    [SerializeField] private string fullAnimation = "AppearFull";
    [SerializeField] private string spinAnimation = "Appear";
    [SerializeField] private string openAnimation = "Open";
    [SerializeField] private string idleAnimation = "Idle";
    
    [Header("Confetti")]
    [SerializeField] private ConfettiController confetti;

    private bool _confettiEnabled;
    private bool _spinEnabled;
    private bool _openDoorEnabled;

    private void Awake()
    {
        _fullAnimation = Animator.StringToHash(fullAnimation);
        _spinAnimation = Animator.StringToHash(spinAnimation);
        _openAnimation = Animator.StringToHash(openAnimation);
        _idleAnimation = Animator.StringToHash(idleAnimation);
    }

    private int GetAnimation() => _spinEnabled ? _openDoorEnabled ? _fullAnimation : _spinAnimation :
        _openDoorEnabled ? _openAnimation : _idleAnimation;

    public void Play()
    {
        if (confetti.IsPlaying())
        {
            confetti.Stop();
        }
        //animator.Play(idleAnimation);

        if (_confettiEnabled)
        {
            confetti.Play();
        }
        
        animator.Play(GetAnimation(), 0, .01f);
    }

    public void Stop()
    {
        if (confetti.IsPlaying())
        {
            confetti.Stop();
        }
        
        animator.Play("Idle");
    }

    public void SetConfetti(bool value)
    {
        _confettiEnabled = value;
    }

    public void SetSpin(bool value)
    {
        _spinEnabled = value;
    }

    public void SetOpenDoor(bool value)
    {
        _openDoorEnabled = value;
    }
}
