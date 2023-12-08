using Zenject;

namespace LevelSpace
{
    public class CurrentLevelInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesAndSelfTo<Level>().AsSingle();
    }
}