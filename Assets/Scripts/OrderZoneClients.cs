using UnityEngine;

public class OrderZoneClients : MonoBehaviour
{
    [SerializeField] private DeliveryTable _deliveryTable;
    [SerializeField] private QueueReceive _queueReceive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Client client))
        {
            gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out ClientTrigger clientTrigger))
        {
            clientTrigger.GiveFood(_deliveryTable, _queueReceive);
            gameObject.SetActive(false);
        }
    }
}