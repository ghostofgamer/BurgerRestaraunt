using CharacterContent.ClientsContent;
using ObjectPoolContent;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField] private ClientCounter _clientCounter;
        [SerializeField] private Client _client;
        
        public override void InstallBindings()
        {
            Container.Bind<ClientCounter>().FromInstance(_clientCounter).AsSingle().NonLazy();
            Container.Bind<Client>().FromInstance(_client).AsSingle().NonLazy();
        }
    }
}