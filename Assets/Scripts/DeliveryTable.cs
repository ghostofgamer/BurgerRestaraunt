using FoodContent;
using UnityEngine;
using Zenject;
using ZonesContent;

public class DeliveryTable : MonoBehaviour
{
    [SerializeField] private Food _food;
    
    [Inject] private OrderZoneClients _orderZoneClients;

    public bool IsBusyPlace { get; private set; }

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
        IsBusyPlace = value;
        _food.gameObject.SetActive(value);
    }
}