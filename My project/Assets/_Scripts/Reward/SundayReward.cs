using TMPro;
using UnityEngine;

namespace RewardSpace
{
    public sealed class SundayReward : MonoBehaviour
    {
        [SerializeField] private GameObject sundayPanel;
        [SerializeField] private TextMeshProUGUI rewardAmount;
        private Reward reward;

        public SundayReward(Reward reward, GameObject sundayPanel, TextMeshProUGUI rewardAmount)
        {
            this.reward = reward;
            this.sundayPanel = sundayPanel;
            this.rewardAmount = rewardAmount;
        }

        public void Reward()
        {
            sundayPanel.SetActive(true);
            rewardAmount.text = $"{reward.RewardAmount}x";
        }
    }
}