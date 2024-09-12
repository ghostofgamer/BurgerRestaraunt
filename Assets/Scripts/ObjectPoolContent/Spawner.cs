using System.Collections;
using CharacterContent.ClientsContent;
using Queues;
using UnityEngine;
using Zenject;

namespace ObjectPoolContent
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private float _minDuration;
        [SerializeField] private float _maxDuration;

        private Client _client;
        private QueueWait _queueWait;
        private ClientCounter _clientCounter;
        private DiContainer _diContainer;
        private ObjectPool<Client> _clientPool;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;
        private bool _isWorking;
        private bool _autoExpand = false;
        private float _currentDuration = 0;

        private void Start()
        {
            _clientPool = new ObjectPool<Client>(_client, _clientCounter.MaxAmountClients, _container, _diContainer);
            _clientPool.SetAutoExpand(_autoExpand);
            _isWorking = true;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            _coroutine = StartCoroutine(SpawnClient());
        }

        [Inject]
        public void Construct(DiContainer diContainer, Client client, QueueWait queueWait, ClientCounter clientCounter)
        {
            _diContainer = diContainer;
            _client = client;
            _queueWait = queueWait;
            _clientCounter = clientCounter;
        }

        private IEnumerator SpawnClient()
        {
            while (_isWorking)
            {
                if (_clientCounter.IsClientsLimit)
                {
                    yield return null;
                    continue;
                }

                _currentDuration = Random.Range(_minDuration, _maxDuration);
                yield return new WaitForSeconds(_currentDuration);

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