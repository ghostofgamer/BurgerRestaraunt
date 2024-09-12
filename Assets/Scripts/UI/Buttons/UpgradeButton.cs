using UnityEngine;
using UpgradesContent;

namespace UI.Buttons
{
    public class UpgradeButton : AbstractButton
    {
        [SerializeField] private Upgrades _upgrades;

        protected override void OnEnable()
        {
            base.OnEnable();
            _upgrades.MaxLevelCompleted += DeactivationButton;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _upgrades.MaxLevelCompleted -= DeactivationButton;
        }

        protected override void OnClick()
        {
            if (_upgrades.TryUpgrade())
                _upgrades.Upgrade();
        }

        private void DeactivationButton()
        {
            Button.interactable = false;
        }
    }
}