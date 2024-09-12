using UnityEngine;

public class ParametersLoad : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _factorDecreaseDuration;
    
    public float Duration => _duration;

    public void DecreaseDuration()
    {
        _duration *= _factorDecreaseDuration;
    }
}