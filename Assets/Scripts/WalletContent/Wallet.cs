using System;
using UnityEngine;

namespace WalletContent
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private AcceptingOrder _acceptingOrder;
        
        public int Money { get; private set; }
        
        public event Action AmountMoneyChanged;

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