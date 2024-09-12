using CharacterContent.ClientsContent;
using UnityEngine;

namespace Queues
{
    public class QueueReceive : AbstractQueue
    {
        [SerializeField] private Transform _exitPosition;

        public override void LeaveQueue()
        {
            Client client = Clients.Peek();
            client.GetComponent<ClientMover>().MovePosition(_exitPosition.position);
            Clients.Dequeue();
            ChangePosition();
        }
    }
}