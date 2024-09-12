using CharacterContent.PlayerContent;
using UnityEngine;
using WorkPlaceContent;
using Zenject;

namespace ZonesContent
{
    public class AcceptingOrderZone : MonoBehaviour
    {
        [Inject] private AcceptingOrder _acceptingOrder;

        private void OnEnable()
        {
            _acceptingOrder.WorkCompleted += OffObject;
        }

        private void OnDisable()
        {
            _acceptingOrder.WorkCompleted -= OffObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
                _acceptingOrder.Work();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
                _acceptingOrder.StopWork();
        }

        private void OffObject() => gameObject.SetActive(false);
    }
}