using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Inject]private IInput _input;
    private float _speed = 3;

    private void Update()
    {
        Move(_input.GetDirection());
    }

    public void Move(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.deltaTime);
        }

        transform.position += moveDirection * _speed * Time.deltaTime;
    }
}
