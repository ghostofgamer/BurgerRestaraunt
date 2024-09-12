using CharacterContent.ClientsContent;
using UnityEngine;

public class OrderZoneClients : MonoBehaviour
{
    [SerializeField] private DeliveryTable _deliveryTable;
    [SerializeField] private QueueReceive _queueReceive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ClientFoodHandler clientTrigger))
        {
            clientTrigger.GiveFood(_deliveryTable, _queueReceive);
            gameObject.SetActive(false);
        }
    }
}