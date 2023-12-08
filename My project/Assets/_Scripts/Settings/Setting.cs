using UnityEngine.UI;
using Zenject;
using UnityEngine;
using System;
using AudioSpace;

namespace Setting
{
    public sealed class Setting : IInitializable, IDisposable
    {
        private Audio audio;
        private AudioSource clickSound;
        private Button soundOffButton;
        private Button soundOnButton;
        private Button musicOffButton;
        private Button musicOnButton;

        [Inject]
        public void Constructor(Audio audio, Button[] buttons, AudioSource[] audious)
        {
            this.audio = audio;
            clickSound = audious[0];

            soundOffButton = buttons[20];
            soundOnButton = buttons[21];
            musicOffButton = buttons[22];
            musicOnButton = buttons[23];
        }

        public void Initialize()
        {
            AddListeners();
            CheckAndSetSound();
            CheckAndSetMusic();
        }

        public void Dispose() => RemoveListeners();

        private void CheckAndSetSound()
        {
            if (audio.Sound == 1)
                OnSound();
            else
                OffSound();
        }

        private void CheckAndSetMusic()
        {
            if (audio.Music == 1)
                OnMusic();
            else
                OffMusic();
        }

        private void AddListeners()
        {
            soundOnButton.onClick.AddListener(OnSound);
            soundOnButton.onClick.AddListener(clickSound.Play);
            soundOffButton.onClick.AddListener(OffSound);
            musicOnButton.onClick.AddListener(OnMusic);
            musicOnButton.onClick.AddListener(clickSound.Play);
            musicOffButton.onClick.AddListener(OffMusic);
        }

        private void RemoveListeners()
        {
            soundOnButton.onClick.RemoveAllListeners();
            soundOffButton.onClick.RemoveAllListeners();
            musicOnButton.onClick.RemoveAllListeners();
            musicOffButton.onClick.RemoveAllListeners();
        }

        private void OnSound() => audio.SetSound(true);

        private void OffSound() => audio.SetSound(false);

        private void OnMusic() => audio.SetBackgroundMusic(true);

        private void OffMusic() => audio.SetBackgroundMusic(false);
    }
}