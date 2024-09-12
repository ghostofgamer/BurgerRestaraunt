using System;
using UnityEngine;
using WalletContent;

namespace UpgradesContent
{
    public class Upgrades : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private int _price;
        [SerializeField] private int _maxLevel;
        [SerializeField] private int _stepUpPrice = 2;

        private int _level = 1;

        public event Action<int, int> ValueChanged;
        public event Action MaxLevelCompleted;

        public int Price => _price;

        private void Start()
        {
            ValueChanged?.Invoke(_level, _price);
        }

        public bool TryUpgrade()
        {
            return _wallet.Money >= _price;
        }

        public void Upgrade()
        {
            _wallet.DecreaseMoney(_price);
            _level++;
            _price *= _stepUpPrice;
            ValueChanged?.Invoke(_level, _price);

            if (_level >= _maxLevel)
                MaxLevelCompleted?.Invoke();
        }
    }
}