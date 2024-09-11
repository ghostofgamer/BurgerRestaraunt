using UnityEngine;
using Zenject;

namespace PlayerContent
{
    [RequireComponent(typeof(PlayerAnimation), typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private IInput _input;
        
        private float _speedMove = 3;
        private float _speedRotation = 6;
        private bool _isWalk;
        private PlayerAnimation _playerAnimation;
        private CharacterController _characterController;

        private void Start()
        {
            _playerAnimation = GetComponent<PlayerAnimation>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move(_input.GetDirection());
        }

        private void Move(Vector3 moveDirection)
        {
            if (moveDirection != Vector3.zero)
            {
                if (!_isWalk)
                {
                    _isWalk = true;
                    _playerAnimation.SetBoolWalking(_isWalk);
                }

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedRotation * Time.deltaTime);
                _characterController.Move(moveDirection * (_speedMove * Time.deltaTime));
            }
            else
            {
                if (!_isWalk) 
                    return;

                _isWalk = false;
                _playerAnimation.SetBoolWalking(_isWalk);
            }
        }
    }
}