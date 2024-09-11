using UnityEngine;

namespace PlayerContent
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Walk = Animator.StringToHash("Walk");
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBoolWalking(bool value)
        {
            _animator.SetBool(Walk, value);
        }
    }
}