using PlayerContent;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    [SerializeField] private DeliveryTable _deliveryTable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.IsThereFood)
            {
                player.PutAwayFood();
                _deliveryTable.PutFood();
            }
        }
    }

    /*private void OnCollisionExit(Collision other)
    {
        if (other.collider.TryGetComponent(out Player player))
        {
        }
    }*/
}