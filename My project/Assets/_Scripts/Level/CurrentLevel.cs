using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public sealed class CurrentLevel
    {
        private Button[] levels;

        public CurrentLevel(Button[] levels) => this.levels = levels;

        private void EnableLevels()
        {
            bool levelEnabled = PlayerPrefs.GetInt("LevelEnabled", 0) != 0;

            foreach (Button level in levels)
                level.interactable = levelEnabled;
        }

        private void DisableLevels()
        {
            foreach (Button level in levels) 
                level.interactable = false;
        }
    }
}