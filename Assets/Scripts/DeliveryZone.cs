using CharacterContent.PlayerContent;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    [SerializeField] private DeliveryTable _deliveryTable;

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