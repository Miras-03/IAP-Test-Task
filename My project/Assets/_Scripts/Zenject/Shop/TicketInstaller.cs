using Zenject;

namespace Shop
{
    public sealed class TicketInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.Bind<Ticket>().AsSingle();
    }
}