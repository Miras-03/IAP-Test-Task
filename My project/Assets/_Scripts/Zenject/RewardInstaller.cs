using Zenject;

namespace RewardSpace
{
    public class RewardInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.Bind<Reward>().AsSingle();
    }
}