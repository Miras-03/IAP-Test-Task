using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level
{
    public sealed class OpenLevel : IInitializable
    {
        private Level currentLevel;
        private Button[] buttons;
        private AudioSource clickSound;

        private const string LevelEnabled = nameof(LevelEnabled);

        [Inject]
        public void Constructor(Level currentLevel, Button[] buttons, AudioSource[] audious)
        {
            this.currentLevel = currentLevel;
            this.buttons = buttons;
            clickSound = audious[0];
        }

        public void Initialize() => AddButtonListeners();

        private void AddButtonListeners()
        {
            for (int i = 0; i < buttons.Length - 1; i++)
            {
                int nextLevel = i + 1;
                buttons[i].onClick.AddListener(() => OpenNextLevel(nextLevel));
                buttons[i].onClick.AddListener(clickSound.Play);
            }
        }

        private void OpenNextLevel(int nextLevel)
        {
            PlayerPrefs.SetInt(LevelEnabled+nextLevel, 1);
            currentLevel.EnableLevels();
        }
    }
}