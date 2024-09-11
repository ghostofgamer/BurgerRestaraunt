using UnityEngine;
using Zenject;
using UnityEngine.AI;

public class ClientMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    [Inject]private Camera _camera;
    public bool IsGoExit { get; private set; }

    private void Update()
    {
        if (!IsGoExit)
            return;
        
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                Debug.Log("Target reached, disabling object.");
                IsGoExit = false;
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
