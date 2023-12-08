using System;
using UnityEngine;
using Zenject;

namespace AudioSpace
{
    public sealed class Audio
    {
        private AudioListener audioListener;
        private AudioSource backgroundMusic;

        [Inject]
        public void Constructor(AudioListener audioListener, AudioSource[] audious)
        {
            this.audioListener = audioListener;
            backgroundMusic = audious[1];
        }

        public void SetSound(bool flag)
        {
            audioListener.enabled = flag;
            Sound = Convert.ToInt32(flag);
        }

        public void SetBackgroundMusic(bool flag)
        {
            backgroundMusic.enabled = flag;
            Music = Convert.ToInt32(flag);
        }

        public int Sound
        {
            get => PlayerPrefs.GetInt("Sound", 1);
            private set => PlayerPrefs.SetInt("Sound", value);
        }

        public int Music
        {
            get => PlayerPrefs.GetInt("Music", 1);
            private set => PlayerPrefs.SetInt("Music", value);
        }
    }
}