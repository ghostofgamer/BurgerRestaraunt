using WorkPlaceContent;
using Zenject;

namespace Queues
{
    public class QueueWait : AbstractQueue
    {
        [Inject] private AcceptingOrder _acceptingOrder;
        [Inject] private QueueReceive _queueReceive;

        private void OnEnable()
        {
            _acceptingOrder.WorkCompleted += LeaveQueue;
        }

        private void OnDisable()
        {
            _acceptingOrder.WorkCompleted -= LeaveQueue;
        }

        public override void LeaveQueue()
        {
            _queueReceive.Add(Clients.Dequeue());
            ChangePosition();
        }
    }
}