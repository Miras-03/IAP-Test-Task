using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelSpace
{
    public sealed class Level : IInitializable
    {
        private Button[] levelButtons;

        private const int levelCount = 19;
        private const string LevelEnabled_ = nameof(LevelEnabled_);

        [Inject]
        public void Constructor(Button[] levelButtons) => this.levelButtons = levelButtons;

        public void Initialize()
        {
            DisableLevels();
            EnableLevels();
        }

        public void EnableLevels()
        {
            bool levelEnabled;
            for (int i = 0; i < levelCount; i++)
            {
                int pressedLevel = i;
                levelEnabled = PlayerPrefs.GetInt(LevelEnabled_ + pressedLevel, 0) == 1;
                levelButtons[i].interactable = levelEnabled;
            }
            levelButtons[0].interactable = true;
        }

        private void DisableLevels()
        {
            for (int i = 0; i < levelCount; i++)
                levelButtons[i].interactable = false;
        }
    }
}