using System;
using UnityEngine;

namespace WalletContent
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private AcceptingOrder _acceptingOrder;
        
        public event Action AmountMoneyChanged;
        
        public int Money { get; private set; }

        private void OnEnable()
        {
            _acceptingOrder.AcceptingOrderFinished += IncreaseMoney;
        }

        private void OnDisable()
        {
            _acceptingOrder.AcceptingOrderFinished -= IncreaseMoney;
        }

        private void IncreaseMoney()
        {
            Money++;
            AmountMoneyChanged?.Invoke();
        }

        public void DecreaseMoney(int value)
        {
            if (value <= 0)
                return;

            Money -= value;
            AmountMoneyChanged?.Invoke();
        }
    }
}