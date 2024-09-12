using CharacterContent.ClientsContent;
using UnityEngine;
using Zenject;

namespace ObjectPoolContent
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Client _client;
        [SerializeField] private QueueWait _queueWait;
        [SerializeField] private ClientCounter _clientCounter;

        private ObjectPool<Client> _clientPool;
        private bool _autoExpand = false;
        [Inject]private DiContainer _diContainer;
        
        private void Start()
        {
            _clientPool = new ObjectPool<Client>(_client, _clientCounter.MaxAmountClients, _container,_diContainer);
            _clientPool.SetAutoExpand(_autoExpand);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_clientCounter.IsClientsLimit)
                    return;
                
                if (_clientPool.TryGetObject(out Client client, _client))
                {
                    client.transform.position = _startPosition.position;
                    _queueWait.Add(client);
                    _clientCounter.AddClient();
                }
            }
        }
    }
}