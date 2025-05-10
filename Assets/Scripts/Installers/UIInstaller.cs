using UnityEngine;
using Zenject;

namespace TankFury
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CollectionPrefabUI>().FromNew().AsSingle();
            Container.Bind<DialogSystem>().FromNew().AsSingle();
        }
    }
}