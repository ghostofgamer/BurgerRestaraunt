using CharacterContent.ClientsContent;
using Queues;
using UnityEngine;
using Zenject;

namespace ZonesContent
{
    public class OrderZoneClients : MonoBehaviour
    {
        [Inject] private DeliveryTable _deliveryTable;
        [Inject] private QueueReceive _queueReceive;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ClientFoodHandler clientTrigger))
            {
                clientTrigger.GiveFood(_deliveryTable, _queueReceive);
                gameObject.SetActive(false);
            }
        }
    }
}