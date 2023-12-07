using UnityEngine;
using UnityEngine.UI;
using Zenject;

public sealed class ButtonInstaller : MonoInstaller
{
    [SerializeField] private Button[] buttons;

    public override void InstallBindings() => Container.BindInstance(buttons).AsSingle();
}