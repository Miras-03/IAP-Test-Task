using Zenject;

namespace Level
{
    public class CurrentLevelInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesAndSelfTo<Level>().AsSingle();
    }
}