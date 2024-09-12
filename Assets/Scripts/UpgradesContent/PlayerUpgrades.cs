using CharacterContent.PlayerContent;
using UnityEngine;

namespace UpgradesContent
{
    public class PlayerUpgrades : Upgrades
    {
        [SerializeField] private PlayerParameters _playerParameters;
        
        public override void Upgrade()
        {
            base.Upgrade();
            _playerParameters.UpgradeParameters();
        }
    }
}
