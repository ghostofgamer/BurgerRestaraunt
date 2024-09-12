using ObjectPoolContent;
using UnityEngine;
using Zenject;

namespace CharacterContent.ClientsContent
{
    public class ClientDestroy : MonoBehaviour
    {
        [Inject]private ClientCounter _clientCounter;

        public void OffActive()
        {
            _clientCounter.RemoveClient();
            gameObject.SetActive(false);
        }
    }
}
