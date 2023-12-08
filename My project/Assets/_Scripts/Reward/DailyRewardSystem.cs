using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RewardSpace
{
    public sealed class DailyRewardSystem : MonoBehaviour
    {
        public Button[] dayButtons;
        public Image[] checkmarkImages;

        private Reward reward;

        private const int maxDays = 7;
        private const string LastLoginDate = nameof(LastLoginDate);
        private const string TakenReward_ = nameof(TakenReward_);

        [Inject]
        public void Construct(Reward reward) => this.reward = reward;

        private void Start()
        {
            ResetDailyRewards();
            UpdateDailyRewards();
        }

        private void OnEnable() => AddButtonListeners();

        private void OnDestroy() => RemoveButtonListeners();

        private void AddButtonListeners()
        {
            for (int i = 0; i < maxDays-1; i++)
            {
                int day = i;
                dayButtons[i].onClick.AddListener(() => TakeReward(day));
            }
        }

        private void RemoveButtonListeners()
        {
            foreach (Button button in dayButtons)   
                button.onClick.RemoveAllListeners();
        }

        private void TakeReward(int day)
        {
            reward.TakeReward(day);
            dayButtons[day].interactable = false;
            checkmarkImages[day].enabled = true;
        }

        private void ResetDailyRewards()
        {
            for (int i = 0; i < maxDays - 1; i++)
            {
                dayButtons[i].interactable = false;
                checkmarkImages[i].enabled = false;
            }
        }

        private void UpdateDailyRewards()
        {
            DateTime lastLoginDate = GetLastLoginDate();
            DateTime currentDate = DateTime.Now;

            int daysPassed = (int)(currentDate - lastLoginDate).TotalDays;

            if (daysPassed >= maxDays)
                ResetDailyRewards();
            else
            {
                for (int i = 0; i <= daysPassed; i++)
                {
                    bool isRewardTaken = PlayerPrefs.GetInt(reward.GetTakenRewardKey(i), 0) == 1;

                    dayButtons[i].interactable = !isRewardTaken;
                    checkmarkImages[i].enabled = isRewardTaken;
                }
            }

            SaveLastLoginDate(currentDate);
        }

        private DateTime GetLastLoginDate()
        {
            if (PlayerPrefs.HasKey(LastLoginDate))
            {
                long ticks = Convert.ToInt64(PlayerPrefs.GetString(LastLoginDate));
                return new DateTime(ticks);
            }

            return DateTime.Now;
        }

        private void SaveLastLoginDate(DateTime date)
        {
            PlayerPrefs.SetString(LastLoginDate, date.Ticks.ToString());
            PlayerPrefs.Save();
        }
    }
}