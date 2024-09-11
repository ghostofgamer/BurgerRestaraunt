using UnityEngine;
using Zenject;

namespace InputContent
{
    public class JoystickHandler : IInput
    {
        [Inject] private Joystick _joystick;

        public Vector3 GetDirection()
        {
            return new Vector3(-_joystick.Horizontal, 0, -_joystick.Vertical);
        }
    }
}