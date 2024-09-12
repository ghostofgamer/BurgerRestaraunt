using UnityEngine;
using WorkPlaceContent;
using Zenject;
using ZonesContent;

namespace Installers
{
    public class CookingInstaller : MonoInstaller
    {
        [SerializeField] private ImageLoader _imageLoader;
        [SerializeField] private Stove _stove;
        [SerializeField] private DeliveryTable _deliveryTable;
        [SerializeField] private AcceptingOrder _acceptingOrder;
        [SerializeField] private AcceptingOrderZone _acceptingOrderZone;
        [SerializeField] private OrderZoneClients _orderZoneClients;
        
        public override void InstallBindings()
        {
            Container.Bind<ImageLoader>().FromInstance(_imageLoader).AsSingle().NonLazy();
            Container.Bind<Stove>().FromInstance(_stove).AsSingle().NonLazy();
            Container.Bind<DeliveryTable>().FromInstance(_deliveryTable).AsSingle().NonLazy();
            Container.Bind<AcceptingOrder>().FromInstance(_acceptingOrder).AsSingle().NonLazy();
            Container.Bind<AcceptingOrderZone>().FromInstance(_acceptingOrderZone).AsSingle().NonLazy();
            Container.Bind<OrderZoneClients>().FromInstance(_orderZoneClients).AsSingle().NonLazy();
        }
    }
}