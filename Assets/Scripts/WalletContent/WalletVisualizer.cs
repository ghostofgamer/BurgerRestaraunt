using TMPro;
using UnityEngine;
using WalletContent;

public class WalletVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AmountMoneyChanged += ShowMoney;
    }

    private void OnDisable()
    {
        _wallet.AmountMoneyChanged -= ShowMoney;
    }

    private void Start()
    {
        ShowMoney();
    }

    private void ShowMoney()
    {
        _moneyText.text = _wallet.Money.ToString();
    }
}