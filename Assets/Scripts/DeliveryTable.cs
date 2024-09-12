using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private QueueReceive _queueReceive;
    [SerializeField] private OrderZoneClients _orderZoneClients;

    public bool _isBusyPlace { get; private set; }

    public void PutFood()
    {
        _orderZoneClients.gameObject.SetActive(true);
        SetActiveFoodValue(true);
    }

    public void RemoveFood()
    {
        SetActiveFoodValue(false);
    }

    private void SetActiveFoodValue(bool value)
    {
        _isBusyPlace = value;
        _food.gameObject.SetActive(value);
    }
}