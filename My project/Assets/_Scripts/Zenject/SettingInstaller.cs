using UnityEngine;
using Zenject;

namespace Setting
{
    public sealed class SettingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Setting>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingUI>().AsSingle();
        }
    }
}