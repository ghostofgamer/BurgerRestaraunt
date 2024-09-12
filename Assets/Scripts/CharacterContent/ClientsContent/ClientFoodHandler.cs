using System.Collections;
using FoodContent;
using PlayerContent;
using Queues;
using UnityEngine;

namespace CharacterContent.ClientsContent
{
    [RequireComponent(typeof(CharacterAnimation), typeof(ClientMover))]
    public class ClientFoodHandler : MonoBehaviour
    {
        [SerializeField] private Food _food;

        private ClientMover _clientMover;
        private CharacterAnimation _characterAnimation;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
        private Coroutine _coroutine;

        private void OnEnable()
        {
            SetActiveFood(false);
        }

        private void Start()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _clientMover = GetComponent<ClientMover>();
        }

        public void GiveFood(DeliveryTable deliveryTable, QueueReceive queueReceive)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ActionWithFood(deliveryTable, queueReceive));
        }

        private void SetActiveFood(bool value)
        {
            _food.gameObject.SetActive(value);
        }

        private IEnumerator ActionWithFood(DeliveryTable deliveryTable, QueueReceive queueReceive)
        {
            _characterAnimation.SetTriggerStretch();
            yield return _waitForSeconds;
            SetActiveFood(true);
            deliveryTable.RemoveFood();
            queueReceive.LeaveQueue();
            _clientMover.GoExit();
        }
    }
}