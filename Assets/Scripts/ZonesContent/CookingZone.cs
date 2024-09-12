using CharacterContent.PlayerContent;
using UnityEngine;
using WorkPlaceContent;
using Zenject;

namespace ZonesContent
{
    public class CookingZone : MonoBehaviour
    {
        [Inject]private Stove _stove;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerFoodHandler player))
            {
                if (player.IsThereFood)
                    return;
            
                _stove.Work();
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerFoodHandler player))
            {
                if (player.IsThereFood)
                    return;
           
                _stove.StopWork();
            }
        }
    }
}
