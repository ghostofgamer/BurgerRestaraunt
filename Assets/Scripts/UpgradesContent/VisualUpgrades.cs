using TMPro;
using UnityEngine;
using WalletContent;

namespace UpgradesContent
{
    public class VisualUpgrades : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Upgrades _upgrades;
        [SerializeField] private Wallet _wallet;

        private void OnEnable()
        {
            _upgrades.ValueChanged += ShowInfo;
            _upgrades.MaxLevelCompleted += ShowCompleteInfo;
            _wallet.AmountMoneyChanged += SetColor;
        }

        private void OnDisable()
        {
            _upgrades.ValueChanged -= ShowInfo;
            _upgrades.MaxLevelCompleted -= ShowCompleteInfo;
            _wallet.AmountMoneyChanged -= SetColor;
        }

        private void ShowInfo(int level, int price)
        {
            SetColor();
            _levelText.text = $"{level.ToString()} ур.";
            _priceText.text = $"price: {price.ToString()}";
        }

        private void ShowCompleteInfo()
        {
            _levelText.text = "max ур.";
            _priceText.gameObject.SetActive(false);
        }

        private void SetColor()
        {
            _priceText.color = _wallet.Money < _upgrades.Price ? Color.red : Color.green;
        }
    }
}