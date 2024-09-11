using System;
using UnityEngine;
using Zenject;
using UnityEngine.AI;

public class ClientMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    [Inject]private Camera _camera;

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit");
                _agent.SetDestination(hit.point);
            }
        }
    }*/

    public void MovePosition(Vector3 position)
    {
        _agent.SetDestination(position);
    }
}
