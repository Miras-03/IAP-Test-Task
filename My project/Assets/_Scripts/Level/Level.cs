using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level
{
    public sealed class Level : IInitializable
    {
        private Button[] levelButtons;

        private const int levelCount = 19;
        private const string LevelEnabled = nameof(LevelEnabled);

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
                levelEnabled = PlayerPrefs.GetInt(LevelEnabled + i, 0) != 0;
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