using Zenject;

namespace LevelSpace
{
    public class OpenLevelInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesAndSelfTo<OpenLevel>().AsSingle();
    }
}