using UnityEngine;
using Zenject;
using TankFury;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private TankMove _tankMove;
    [SerializeField] private InputHandler _input;
    [SerializeField] private TankViewController _viewController;


    public override void InstallBindings()
    {
        Container.Bind<TankMove>().FromInstance(_tankMove).AsSingle();
        Container.Bind<InputHandler>().FromInstance(_input).AsSingle();
        Container.Bind<TankViewController>().FromInstance(_viewController).AsSingle();
    }
}