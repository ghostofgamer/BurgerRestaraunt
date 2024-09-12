using UnityEngine;

public class ClientAnimation : MonoBehaviour
{
    private static readonly int Walk = Animator.StringToHash("Walk");

    [SerializeField] private Animator _animator;

    public void SetBoolWalking(bool value)
    {
        _animator.SetBool(Walk, value);
    }
}