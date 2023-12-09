using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RewardSpace
{
    public sealed class DailyRewardSystem : MonoBehaviour
    {
        [Space(10)]
        private SundayReward sundayReward;
        private DailyProgressIndicator progressIndicator;
        private Reward reward;
        private LoginDate loginDate;
        private RewardUI rewardUI;

        [Space(20)]
        [Header("Audio")]
        [SerializeField] private AudioSource clickSound;

        [Space(20)]
        [Header("Button")]
        [SerializeField] private Button rewardButton;
        [SerializeField] private Button[] dayButtons;

        [Space(20)]
        [Header("Image")]
        [SerializeField] private Image previousPoint;
        [SerializeField] private Image[] checkmarkImages;

        [Space(20)]
        [Header("TMP")]
        [SerializeField] private TextMeshProUGUI dayIndicator;
        [SerializeField] private TextMeshProUGUI rewardAmount;

        [Space(10)]
        [Header("Slider")]
        [SerializeField] private Slider progressBar;

        [Space(10)]
        [Header("Panel")]
        [SerializeField] private GameObject sundayPanel;

        private int daysPassed = 0;
        private const int maxDays = 6;
        private const string TakenReward_ = nameof(TakenReward_);

        [Inject]
        public void Construct(Reward reward)
        {
            this.reward = reward;
            loginDate = new LoginDate();
            progressIndicator = new DailyProgressIndicator(reward, progressBar, dayIndicator);
            sundayReward = new SundayReward(reward, sundayPanel, rewardAmount);
            rewardUI = new RewardUI(dayButtons, checkmarkImages, reward);
        }

        private void OnEnable() => AddButtonListeners();

        private void OnDestroy() => RemoveButtonListeners();

        private void AddButtonListeners()
        {
            rewardButton.onClick.AddListener(UpdateDailyRewards);
            for (int i = 0; i < maxDays; i++)
            {
                int day = i;
                dayButtons[i].onClick.AddListener(() => TakeReward(day));
            }
        }

        private void RemoveButtonListeners()
        {
            rewardButton.onClick.RemoveAllListeners();
            foreach (Button button in dayButtons)   
                button.onClick.RemoveAllListeners();
        }

        private void TakeReward(int day)
        {
            clickSound.Play();
            reward.TakeReward(day);
            IndicateProgress();
            UpdateButtons(day);
            loginDate.SaveLastLoginDate(DateTime.Now);
        }

        private void UpdateDailyRewards()
        {
            DateTime lastLoginDate = loginDate.GetLastLoginDate();
            DateTime currentDate = DateTime.Now;

            DisableButtons();
            daysPassed = (int)(currentDate-lastLoginDate).TotalDays;
            IndicateProgress();

            CheckOrExecuteSunday();
            UpdateButtons(daysPassed);
        }

        private void IndicateProgress() => progressIndicator.Indicate(daysPassed);

        private void CheckOrExecuteSunday()
        {
            previousPoint.color = Color.gray;
            if (daysPassed >= maxDays)
            {
                previousPoint.color = Color.green;
                ExecuteSundayReward();
                reward.SetRewardCount(maxDays);
                daysPassed = 0;
            }
        }

        private void ExecuteSundayReward()
        {
            ResetDailyRewards();
            reward.TakeReward(maxDays);
            sundayReward.Reward();
        }

        private void ResetDailyRewards()
        {
            for (int i = 0; i < maxDays; i++)
                PlayerPrefs.SetInt(reward.GetTakenRewardKey(i), 0);
        }

        private void UpdateButtons(int day) => rewardUI.UpdateButtons(day);
        private void DisableButtons() => rewardUI.DisableButtons();
    }
}