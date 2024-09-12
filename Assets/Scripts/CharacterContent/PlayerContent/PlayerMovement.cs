using PlayerContent;
using UnityEngine;
using Zenject;

namespace CharacterContent.PlayerContent
{
    [RequireComponent(typeof(CharacterAnimation), typeof(CharacterController), typeof(PlayerParameters))]
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private IInput _input;

        private bool _isWalk;
        private CharacterAnimation _characterAnimation;
        private CharacterController _characterController;
        private PlayerParameters _playerParameters;
        private Quaternion _targetRotation;

        private void Start()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _characterController = GetComponent<CharacterController>();
            _playerParameters = GetComponent<PlayerParameters>();
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
                    _characterAnimation.SetBoolWalking(_isWalk);
                }

                _targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation,
                    _playerParameters.SpeedRotation * Time.deltaTime);
                _characterController.Move(moveDirection * (_playerParameters.SpeedMove * Time.deltaTime));
            }
            else
            {
                if (!_isWalk)
                    return;

                _isWalk = false;
                _characterAnimation.SetBoolWalking(_isWalk);
            }
        }
    }
}