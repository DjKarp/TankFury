using UnityEngine;
using Zenject;

namespace TankFury
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            /*var collectionPrefab = new CollectionPrefabUI();
            Container.Bind<CollectionPrefabUI>().FromInstance(collectionPrefab).AsSingle().NonLazy();
            Container.QueueForInject(collectionPrefab);

            var dialogSystem = new DialogSystem();
            Container.Bind<DialogSystem>().FromInstance(dialogSystem).AsSingle();
            Container.QueueForInject(dialogSystem);*/

            Container.Bind<CollectionPrefabUI>().FromNew().AsSingle();
            //Container.Bind<DialogSystem>().FromNew().AsSingle().NonLazy();

            BindSignals();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<PlayPauseGameSignal>().OptionalSubscriber();
        }
    }
}