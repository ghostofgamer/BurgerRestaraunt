using UnityEngine;

public class ClientZone : MonoBehaviour
{
    [SerializeField] private AcceptingOrderZone _acceptingOrderZone;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Client client))
        {
            _acceptingOrderZone.gameObject.SetActive(true);
            Debug.Log("Подошел к кассе");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.collider.TryGetComponent(out Client client))
        {
            Debug.Log("Ушел от кассы");
        }
    }
}
