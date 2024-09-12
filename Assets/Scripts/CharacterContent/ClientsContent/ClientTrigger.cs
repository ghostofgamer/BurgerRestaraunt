using System.Collections;
using PlayerContent;
using UnityEngine;

public class ClientTrigger : MonoBehaviour
{
    private Client _client;
    private CharacterAnimation _characterAnimation;
    
    private void Start()
    {
        _client = GetComponent<Client>();
        _characterAnimation = GetComponent<CharacterAnimation>();
    }

    public void GiveFood(DeliveryTable deliveryTable, QueueReceive queueReceive)
    {
        StartCoroutine(ActionWithFood(deliveryTable, queueReceive));
    }
    
    private IEnumerator ActionWithFood(DeliveryTable deliveryTable, QueueReceive queueReceive)
    {
        _characterAnimation.SetTriggerStretch();
        yield return new WaitForSeconds(0.5f);
        _client.ShowFood();
        deliveryTable.RemoveFood();
        queueReceive.LeaveQueue();
    }
}