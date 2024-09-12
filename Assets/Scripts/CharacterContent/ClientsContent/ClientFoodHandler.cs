using System.Collections;
using PlayerContent;
using UnityEngine;

namespace CharacterContent.ClientsContent
{
    public class ClientFoodHandler : MonoBehaviour
    {
        [SerializeField] private Food _food;
        [SerializeField] private ClientMover _clientMover;

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