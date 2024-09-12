using UnityEngine;

public class OrderZoneClients : MonoBehaviour
{
    [SerializeField] private DeliveryTable _deliveryTable;
    [SerializeField] private QueueReceive _queueReceive;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Client client))
        {
            client.ShowFood();
            _queueReceive.LeaveQueue();
            _deliveryTable.RemoveFood();
            gameObject.SetActive(false);
        }
    }
}
