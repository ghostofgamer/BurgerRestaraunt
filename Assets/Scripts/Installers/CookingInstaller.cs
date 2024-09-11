using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CookingInstaller : MonoInstaller
{
   [SerializeField] private Image _loadImage;
   [SerializeField] private Image _loadFill;
   [SerializeField] private ImageLoader _imageLoader;
   [SerializeField]private Stove _stove;
   
   public override void InstallBindings()
   {
      /*Container.Bind<Image>().FromInstance(_loadImage).AsSingle().NonLazy();
      Container.Bind<Image>().FromInstance(_loadFill).AsSingle().NonLazy();*/
      Container.Bind<ImageLoader>().FromInstance(_imageLoader).AsSingle().NonLazy();
      Container.Bind<Stove>().FromInstance(_stove).AsSingle().NonLazy();
   }
}
