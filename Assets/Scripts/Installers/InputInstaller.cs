using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;

    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<JoystickHandler>().AsSingle().NonLazy();
        Container.Bind<Joystick>().FromInstance(_joystick).AsSingle().NonLazy();
    }
}