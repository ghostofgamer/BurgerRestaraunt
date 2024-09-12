using CharacterContent.PlayerContent;
using UnityEngine;
using Zenject;

namespace ZonesContent
{
    public class DeliveryZone : MonoBehaviour
    {
        [Inject] private DeliveryTable _deliveryTable;

        private void OnTriggerEnter(Collider other)
        {
            if (_deliveryTable.IsBusyPlace)
                return;

            if (other.TryGetComponent(out PlayerFoodHandler player))
            {
                if (player.IsThereFood)
                    player.PutAwayFood();
            }
        }
    }
}