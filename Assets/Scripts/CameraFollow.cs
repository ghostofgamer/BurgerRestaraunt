using PlayerContent;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    [Inject] private Player _target;
    private float _smoothSpeed = 0.125f;
    private Vector3 _smoothedPosition;
    private Vector3 _targetPosition;

    private void LateUpdate()
    {
        _targetPosition = _target.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _smoothSpeed);
    }
}