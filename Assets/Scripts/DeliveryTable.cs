using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private QueueReceive _queueReceive;
    [SerializeField] private OrderZoneClients _orderZoneClients;

    public bool _isBusyPlace { get; private set; }

    public void PutFood()
    {
        _food.gameObject.SetActive(true);
        _orderZoneClients.gameObject.SetActive(true);
        _isBusyPlace = true;


        // _food.gameObject.SetActive(false);




        /*Client client = _queueReceive.GetClient();
        client.ShowFood();*/
        // _queueReceive.LeaveQueue();
    }

    public void RemoveFood()
    {
        _isBusyPlace = false;
        _food.gameObject.SetActive(false);
    }
}