using System;
using UnityEngine;
using WorkPlaceContent;

namespace WalletContent
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private AcceptingOrder _acceptingOrder;

        public event Action AmountMoneyChanged;
        
        public int Money { get; private set; }

        private void OnEnable()
        {
            _acceptingOrder.WorkCompleted += IncreaseMoney;
        }

        private void OnDisable()
        {
            _acceptingOrder.WorkCompleted -= IncreaseMoney;
        }

        public void DecreaseMoney(int value)
        {
            if (value <= 0)
                return;

            Money -= value;
            AmountMoneyChanged?.Invoke();
        }

        private void IncreaseMoney()
        {
            Money++;
            AmountMoneyChanged?.Invoke();
        }
    }
}