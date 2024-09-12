using System.Collections.Generic;
using CharacterContent.ClientsContent;
using UnityEngine;

namespace Queues
{
    public abstract class AbstractQueue : MonoBehaviour
    {
        [SerializeField] protected Transform[] _positions;

        private bool[] _positionOccupied;

        protected Queue<Client> Clients { get; private set; }

        private void Start()
        {
            Clients = new Queue<Client>();
            _positionOccupied = new bool[_positions.Length];
        }

        public void Add(Client client)
        {
            Clients.Enqueue(client);
            int positionIndex = GetPosition();

            if (positionIndex > -1)
            {
                client.GetComponent<ClientMover>().MovePosition(_positions[positionIndex].position);
                _positionOccupied[positionIndex] = true;
            }
        }

        public abstract void LeaveQueue();

        protected void ChangePosition()
        {
            for (int i = 0; i < _positionOccupied.Length; i++)
                _positionOccupied[i] = false;

            Client[] clientsArray = Clients.ToArray();

            for (int i = 0; i < Clients.Count; i++)
            {
                int positionIndex = GetPosition();

                if (positionIndex > -1)
                {
                    clientsArray[i].GetComponent<ClientMover>().MovePosition(_positions[positionIndex].position);
                    _positionOccupied[positionIndex] = true;
                }
            }
        }

        private int GetPosition()
        {
            for (int i = 0; i < _positionOccupied.Length; i++)
            {
                if (!_positionOccupied[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}