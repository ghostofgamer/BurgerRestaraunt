using CharacterContent.ClientsContent;
using UnityEngine;
using Zenject;

namespace ZonesContent
{
    public class ClientZone : MonoBehaviour
    {
        [Inject] private AcceptingOrderZone _acceptingOrderZone;
    
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Client>(out _))
                _acceptingOrderZone.gameObject.SetActive(true);
        }
    }
}