using Zenject;

namespace Level
{
    public class CurrentLevelInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesAndSelfTo<CurrentLevel>().AsSingle();
    }
}