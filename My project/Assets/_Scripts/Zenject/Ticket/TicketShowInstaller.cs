using Zenject;

namespace Ticket
{
    public class TicketShowInstaller : MonoInstaller
    {
        public sealed override void InstallBindings() => Container.BindInterfacesAndSelfTo<TicketShow>().AsSingle();
    }
}