using Zenject;

namespace Ticket
{
    public sealed class TicketInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.Bind<Ticket>().AsSingle();
    }
}