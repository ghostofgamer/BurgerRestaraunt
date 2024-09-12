using UnityEngine;
using UpgradesContent;

public class DurationUpgrades :Upgrades
{
    [SerializeField] private ParametersLoad _parametersLoad;
    
    public override void Upgrade()
    {
        base.Upgrade();
        _parametersLoad.DecreaseDuration();
    }
}
