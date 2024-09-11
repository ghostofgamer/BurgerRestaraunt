using System.Collections.Generic;
using UnityEngine;

public class QueueWait : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;

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

        Debug.Log(_clients.Count);
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