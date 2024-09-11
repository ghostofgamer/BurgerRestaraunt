using PlayerContent;
using UnityEngine;

public class AcceptingOrderZone : MonoBehaviour
{
    [SerializeField] private AcceptingOrder _acceptingOrder;

    private void OnEnable()
    {
        _acceptingOrder.AcceptingOrderFinished += OffObject;
    }

    private void OnDisable()
    {
        _acceptingOrder.AcceptingOrderFinished -= OffObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
             _acceptingOrder.StartAcceptingOrder();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
             _acceptingOrder.StopAcceptingOrder();
        }
    }

    private void OffObject()
    {
        gameObject.SetActive(false);
    }
}