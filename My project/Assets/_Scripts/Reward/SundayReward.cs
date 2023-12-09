using TMPro;
using UnityEngine;
using Zenject;

namespace RewardSpace
{
    public sealed class SundayReward : MonoBehaviour
    {
        [SerializeField] private GameObject sundayPanel;
        [SerializeField] private TextMeshProUGUI rewardAmount;
        private Reward reward;

        [HideInInspector] public int amount;

        [Inject]
        public void Construct(Reward reward) => this.reward = reward;

        public void Reward()
        {
            sundayPanel.SetActive(true);
            rewardAmount.text = reward.RewardAmount.ToString();
        }
    }
}