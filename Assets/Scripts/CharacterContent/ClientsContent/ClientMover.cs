using PlayerContent;
using UnityEngine;
using UnityEngine.AI;

namespace CharacterContent.ClientsContent
{
    [RequireComponent(typeof(CharacterAnimation), typeof(NavMeshAgent), typeof(ClientDestroy))]
    public class ClientMover : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private ClientDestroy _clientDestroy;
        private CharacterAnimation _characterAnimation;
        private bool _isGoExit;
        private float _minVelocity = 0.1f;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _agent = GetComponent<NavMeshAgent>();
            _clientDestroy = GetComponent<ClientDestroy>();
        }

        private void Update()
        {
            _characterAnimation.SetBoolWalking(_agent.velocity.magnitude > _minVelocity);

            if (!_isGoExit)
                return;

            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _isGoExit = false;
                    _clientDestroy.OffActive();
                }
            }
        }

        public void MovePosition(Vector3 position) => _agent.SetDestination(position);

        public void GoExit() => _isGoExit = true;
    }
}