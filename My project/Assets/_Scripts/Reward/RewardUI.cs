using UnityEngine;
using UnityEngine.UI;

namespace RewardSpace
{
    public sealed class RewardUI
    {
        private Button[] dayButtons;
        private Image[] checkmarkImages;

        private Reward reward;
        private const int maxDays = 6;

        public RewardUI(Button[] dayButtons, Image[] checkmarkImages, Reward reward)
        {
            this.dayButtons = dayButtons;
            this.checkmarkImages = checkmarkImages;
            this.reward = reward;
        }

        public void DisableButtons()
        {
            for (int i = 0; i < maxDays; i++)
            {
                dayButtons[i].interactable = false;
                checkmarkImages[i].enabled = false;
            }
        }

        public void UpdateButtons(int dayPassed)
        {
            bool isRewardTaken;
            for (int i = 0; i <= dayPassed; i++)
            {
                isRewardTaken = PlayerPrefs.GetInt(reward.GetTakenRewardKey(i), 0) == 1;

                dayButtons[i].interactable = !isRewardTaken;
                checkmarkImages[i].enabled = isRewardTaken;
            }
        }
    }
}