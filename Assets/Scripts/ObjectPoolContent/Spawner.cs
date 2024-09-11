using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _startPosition;
    [SerializeField]private Client _client;

    private ObjectPool<Client> _clientPool;
    private int _maxAmountClients = 3;
    private bool _autoExpand = false;

    private void Start()
    {
        _clientPool = new ObjectPool<Client>(_client, _maxAmountClients, _container);
        _clientPool.SetAutoExpand(_autoExpand);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space ))
        {
            if (_clientPool.TryGetObject(out Client client, _client))
            {
                client.transform.position = _startPosition.position;
            }
        }
    }
}
