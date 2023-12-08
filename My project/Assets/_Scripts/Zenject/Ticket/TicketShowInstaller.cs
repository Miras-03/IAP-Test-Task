using Zenject;

namespace TicketSpace
{
    public class TicketShowInstaller : MonoInstaller
    {
        public sealed override void InstallBindings() => Container.BindInterfacesAndSelfTo<TicketShow>().AsSingle();
    }
}