using System.Collections;
using UnityEngine;
using Zenject;

namespace PlayerContent
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Food _food;
        [SerializeField] private DeliveryTable _deliveryTable;

        private CharacterAnimation _characterAnimation;
        
        [Inject] private Stove _stove;

        private void OnEnable()
        {
            _stove.CookingFinished += TakeFood;
        }

        private void OnDisable()
        {
            _stove.CookingFinished -= TakeFood;
        }

        private void Start()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
        }

        public bool IsThereFood { get; private set; }

        private void TakeFood()
        {
            StartCoroutine(ActionWithFood(true));
        }

        public void PutAwayFood()
        {
            StartCoroutine(ActionWithFood(false));
        }

        private IEnumerator ActionWithFood(bool value)
        {
            IsThereFood = value;
            _characterAnimation.SetTriggerStretch();
            yield return new WaitForSeconds(0.5f);
            _food.gameObject.SetActive(IsThereFood);

            if (!value)
                _deliveryTable.PutFood();
        }
    }
}