using Queues;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class QueueInstaller : MonoInstaller
    {
        [SerializeField] private QueueReceive _queueReceive;
        [SerializeField] private QueueWait _queueWait;

        public override void InstallBindings()
        {
            Container.Bind<QueueReceive>().FromInstance(_queueReceive).AsSingle().NonLazy();
            Container.Bind<QueueWait>().FromInstance(_queueWait).AsSingle().NonLazy();
        }
    }
}