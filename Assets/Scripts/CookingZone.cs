using PlayerContent;
using UnityEngine;
using Zenject;

public class CookingZone : MonoBehaviour
{
    [Inject]private Stove _stove;
    [Inject] private Player _player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            
            Debug.Log("Зашел");
            _stove.StartCooking();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Debug.Log("Вышел");
            _stove.StopCooking();
        }
    }
}
