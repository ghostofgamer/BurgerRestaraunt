using CharacterContent.ClientsContent;
using UnityEngine;

public class ClientZone : MonoBehaviour
{
    [SerializeField] private AcceptingOrderZone _acceptingOrderZone;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Client>(out _))
        {
            _acceptingOrderZone.gameObject.SetActive(true);
        }
    }
}