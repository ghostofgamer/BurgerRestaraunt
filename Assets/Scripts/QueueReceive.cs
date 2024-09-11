using System.Collections.Generic;
using UnityEngine;

public class QueueReceive : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private Transform _exitPosition;

    private Queue<Client> _clients;
    private bool[] _positionOccupied = new bool[3];

    private void Start()
    {
        _clients = new Queue<Client>();
    }

    public void Add(Client client)
    {
        _clients.Enqueue(client);
        int positionIndex = GetPosition();

        if (positionIndex > -1)
        {
            client.GetComponent<ClientMover>().MovePosition(_positions[positionIndex].position);
            _positionOccupied[positionIndex] = true;
        }

        Debug.Log("На выдоче стоит " + _clients.Count);
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

    public Client GetClient()
    {
        if (_clients.Count > 0)
        {
            Client client = _clients.Peek();
            return client;
        }

        return null;
    }

    public void LeaveQueue()
    {
        Client client = _clients.Peek();
        client.GetComponent<ClientMover>().MovePosition(_exitPosition.position);
        _clients.Dequeue();
        
        for (int i = 0; i < _positionOccupied.Length; i++)
            _positionOccupied[i] = false;

        Client[] clientsArray = _clients.ToArray();

        for (int i = 0; i < _clients.Count; i++)
        {
            int positionIndex = GetPosition();

            if (positionIndex > -1)
            {
                clientsArray[i].GetComponent<ClientMover>().MovePosition(_positions[positionIndex].position);
                _positionOccupied[positionIndex] = true;
            }
        }

        Debug.Log("Колличество после удаления " + _clients.Count);
    }
}