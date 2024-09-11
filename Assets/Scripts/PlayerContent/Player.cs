using System;
using UnityEngine;
using Zenject;

namespace PlayerContent
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Food _food;
        
        [Inject]private Stove _stove;

        private void OnEnable()
        {
            _stove.CookingFinished += TakeFood;
        }

        private void OnDisable()
        {
            _stove.CookingFinished -= TakeFood;
        }

        public bool IsThereFood { get; private set; }

        private void TakeFood()
        {
            IsThereFood = true;
            _food.gameObject.SetActive(IsThereFood);
        }

        public void PutAwayFood()
        {
            IsThereFood = false;
            _food.gameObject.SetActive(IsThereFood);
        }
    }
}