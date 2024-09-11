using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private QueueReceive _queueReceive;

    public void PutFood()
    {
        _food.gameObject.SetActive(true);
        Client client = _queueReceive.GetClient();
        client.ShowFood();
        _queueReceive.LeaveQueue();
    }
}