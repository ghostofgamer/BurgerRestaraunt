using System;
using UnityEngine;
using Zenject;
using UnityEngine.AI;

public class ClientMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private ClientAnimation _clientAnimation;
    private Client _client;
    
    
    [Inject]private Camera _camera;
    
    public bool IsGoExit { get; private set; }

    private void Start()
    {
        _client = GetComponent<Client>();
        _clientAnimation = GetComponent<ClientAnimation>();
    }

    private void Update()
    {
        _clientAnimation.SetBoolWalking(_agent.velocity.magnitude > 0.1f);
        
        if (!IsGoExit)
            return;
        
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                IsGoExit = false;
                _client.OffFood();
                gameObject.SetActive(false);
            }
        }
    }

    public void MovePosition(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    public void GoExit()
    {
        IsGoExit = true;
    }
}
