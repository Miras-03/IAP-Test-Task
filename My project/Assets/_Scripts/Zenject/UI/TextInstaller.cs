using TMPro;
using UnityEngine;
using Zenject;

public sealed class TextInstaller : MonoInstaller
{
    [SerializeField] private TextMeshProUGUI[] texts;

    public override void InstallBindings() => Container.BindInstance(texts);
}