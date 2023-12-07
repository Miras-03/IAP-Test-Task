using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level
{
    public sealed class OpenLevel : IInitializable
    {
        private CurrentLevel currentLevel;
        private Button[] buttons;

        private const string LevelEnabled = nameof(LevelEnabled);

        [Inject]
        public void Constructor(CurrentLevel currentLevel, Button[] buttons)
        {
            this.currentLevel = currentLevel;
            this.buttons = buttons;
        }

        public void Initialize() => AddButtonListeners();

        private void AddButtonListeners()
        {
            for (int i = 0; i < buttons.Length - 1; i++)
            {
                int nextLevel = i + 1;
                buttons[i].onClick.AddListener(() => OpenNextLevel(nextLevel));
            }
        }

        private void OpenNextLevel(int nextLevel)
        {
            PlayerPrefs.SetInt(LevelEnabled+nextLevel, 1);
            currentLevel.EnableLevels();
        }
    }
}