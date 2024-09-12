using UnityEngine;

namespace PlayerContent
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Stretch = Animator.StringToHash("Stretch");

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBoolWalking(bool value)
        {
            _animator.SetBool(Walk, value);
        }
        
        public void SetTriggerStretch()
        {
            _animator.SetTrigger(Stretch);
        }
    }
}