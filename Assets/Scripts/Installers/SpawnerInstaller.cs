using UnityEngine;
using Zenject;

namespace Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField] private ClientCounter _clientCounter;

        public override void InstallBindings()
        {
            Container.Bind<ClientCounter>().FromInstance(_clientCounter).AsSingle().NonLazy();
        }
    }
}
