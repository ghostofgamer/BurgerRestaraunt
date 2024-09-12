using System.Collections;
using FoodContent;
using PlayerContent;
using UnityEngine;
using WorkPlaceContent;
using Zenject;

namespace CharacterContent.PlayerContent
{
    public class PlayerFoodHandler : MonoBehaviour
    {
        [SerializeField] private Food _food;
        [SerializeField] private DeliveryTable _deliveryTable;

        [Inject] private Stove _stove;

        private CharacterAnimation _characterAnimation;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);

        public bool IsThereFood { get; private set; }

        private void OnEnable()
        {
            _stove.WorkCompleted += TakeFood;
        }

        private void OnDisable()
        {
            _stove.WorkCompleted -= TakeFood;
        }

        private void Start()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
        }

        public void PutAwayFood()
        {
            StartCoroutine(ActionWithFood(false));
        }

        private void TakeFood()
        {
            StartCoroutine(ActionWithFood(true));
        }

        private IEnumerator ActionWithFood(bool value)
        {
            IsThereFood = value;
            _characterAnimation.SetTriggerStretch();
            yield return _waitForSeconds;
            _food.gameObject.SetActive(IsThereFood);

            if (!value)
                _deliveryTable.PutFood();
        }
    }
}