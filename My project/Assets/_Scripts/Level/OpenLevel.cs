using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelSpace
{
    public sealed class OpenLevel : IInitializable
    {
        private Level level;

        private Button[] buttons;
        private AudioSource clickSound;

        private const int levelCount = 20;
        private const string LevelEnabled_ = nameof(LevelEnabled_);

        [Inject]
        public void Constructor(Level level, Button[] buttons, AudioSource[] audious) 
        {
            this.level = level;
            this.buttons = buttons;
            clickSound = audious[0];
        }

        public void Initialize() => AddButtonListeners();

        private void AddButtonListeners()
        {
            for (int i = 0; i < levelCount; i++)
            {
                int nextLevel = i + 1;
                buttons[i].onClick.AddListener(() => OpenNextLevel(nextLevel));
                buttons[i].onClick.AddListener(clickSound.Play);
            }
        }

        private void OpenNextLevel(int nextLevel)
        {
            PlayerPrefs.SetInt(LevelEnabled_+nextLevel, 1);
            level.CurrentLevel = nextLevel;
            PlayerPrefs.Save();

            level.EnableLevels();
        }
    }
}