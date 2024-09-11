using PlayerContent;
using UnityEngine;
using Zenject;

public class CookingZone : MonoBehaviour
{
    [Inject]private Stove _stove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.IsThereFood)
                return;
            
            Debug.Log("Зашел");
            _stove.StartCooking();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.IsThereFood)
                return;
            Debug.Log("Вышел");
            _stove.StopCooking();
        }
    }
}
