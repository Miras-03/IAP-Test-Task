using UnityEngine;
using Zenject;

namespace AudioSpace
{
    public sealed class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioListener audioListener;
        [SerializeField] private AudioSource[] audious;

        public override void InstallBindings()
        {
            Container.Bind<Audio>().AsSingle();
            Container.Bind<AudioListener>().FromInstance(audioListener).AsSingle();
            Container.BindInstance(audious).AsSingle();
        }
    }
}