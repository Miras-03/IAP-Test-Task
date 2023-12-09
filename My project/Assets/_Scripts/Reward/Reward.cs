using TicketSpace;
using UnityEngine;
using Zenject;

namespace RewardSpace
{
    public sealed class Reward
    {
        private Ticket ticket;
        private TicketShow ticketShow;

        private int rewardAmount;
        private int[] rewards = { 500, 1000, 1500 };
        private const string TakenReward_ = nameof(TakenReward_);
        private const string rewardCount = "TakenRewardCount";

        [Inject]
        public void Constructor(Ticket ticket, TicketShow ticketShow)
        {
            this.ticket = ticket;
            this.ticketShow = ticketShow;
        }

        public void TakeReward(int day)
        {
            Take(day);
            CheckAndSetRewardCount(day);

            PlayerPrefs.SetInt(GetTakenRewardKey(day), 1);
            PlayerPrefs.Save();
        }

        private void CheckAndSetRewardCount(int day) => PlayerPrefs.SetInt(rewardCount, day);

        public string GetTakenRewardKey(int day) => TakenReward_ + day.ToString();

        private void Take(int day)
        {
            switch (day)
            {
                case 0:
                    rewardAmount = 500;
                    break;
                case 1:
                    rewardAmount = 500;
                    break;
                case 2:
                    rewardAmount = 1000;
                    break;
                case 3:
                    rewardAmount = 1000;
                    break;
                case 4:
                    rewardAmount = 1500;
                    break;
                case 5:
                    rewardAmount = 1500;
                    break;
                case 6:
                    rewardAmount = rewards[Random.Range(0,3)]/100;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
            ticket.CurrentTicket += rewardAmount;
            ticketShow.UpdateText();
        }

        public int GetTakenRewardCount() => PlayerPrefs.GetInt(rewardCount, 0);

        public void SetRewardCount(int takenDay)
        {
            int currentTakenReward = GetTakenRewardCount();
            if (takenDay>currentTakenReward || takenDay == 0)
                PlayerPrefs.SetInt(rewardCount, takenDay);
        }

        public int RewardAmount => rewardAmount;
    }
}