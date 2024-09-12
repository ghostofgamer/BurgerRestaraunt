using System.Collections;
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
        [SerializeField] private float _minDuration;
        [SerializeField] private float _maxDuration;

        private ObjectPool<Client> _clientPool;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;
        private bool _isWorking;
        private bool _autoExpand = false;
        private float _currentDuration = 0;
        [Inject] private DiContainer _diContainer;

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
            
            _coroutine =  StartCoroutine(SpawnClient());
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