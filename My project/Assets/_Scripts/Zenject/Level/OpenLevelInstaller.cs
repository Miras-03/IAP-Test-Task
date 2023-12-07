using Zenject;

namespace Level
{
    public class OpenLevelInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesAndSelfTo<OpenLevel>().AsSingle();
    }
}