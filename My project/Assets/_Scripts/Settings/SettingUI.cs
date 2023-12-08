using System;
using Zenject;
using AudioSpace;

namespace Setting
{
    public sealed class SettingUI : IInitializable, IDisposable
    {
        private Audio audio;
        private UnityEngine.UI.Button soundOffButton;
        private UnityEngine.UI.Button soundOnButton;
        private UnityEngine.UI.Button musicOffButton;
        private UnityEngine.UI.Button musicOnButton;

        [Inject]
        public void Constructor(Audio audio, UnityEngine.UI.Button[] buttons)
        {
            this.audio = audio;

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

        public void Dispose() => RemoveAllListeners();

        private void AddListeners()
        {
            soundOnButton.onClick.AddListener(OnSound);
            soundOffButton.onClick.AddListener(OffSound);
            musicOnButton.onClick.AddListener(OnMusic);
            musicOffButton.onClick.AddListener(OffMusic);
        }

        private void RemoveAllListeners()
        {
            soundOnButton.onClick.RemoveAllListeners();
            soundOffButton.onClick.RemoveAllListeners();
            musicOnButton.onClick.RemoveAllListeners();
            musicOffButton.onClick.RemoveAllListeners();
        }

        public void OnSound()
        {
            SetButton(soundOnButton, false);
            SetButton(soundOffButton, true);
        }

        public void OffSound()
        {
            SetButton(soundOffButton, false);
            SetButton(soundOnButton, true);
        }

        public void OnMusic()
        {
            SetButton(musicOnButton, false);
            SetButton(musicOffButton, true);
        }

        public void OffMusic()
        {
            SetButton(musicOffButton, false);
            SetButton(musicOnButton, true);
        }

        private void SetButton(UnityEngine.UI.Button button, bool flag)
        {
            button.enabled = flag;
            button.image.enabled = flag;
        }
    }
}