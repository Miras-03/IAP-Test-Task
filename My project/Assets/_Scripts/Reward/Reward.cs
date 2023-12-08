using TicketSpace;
using UnityEngine;
using Zenject;

namespace RewardSpace
{
    public sealed class Reward
    {
        private TicketSpace.Ticket ticket;
        private TicketShow ticketShow;
        private const string TakenReward_ = nameof(TakenReward_);

        [Inject]
        public void Constructor(TicketSpace.Ticket ticket, TicketShow ticketShow)
        {
            this.ticket = ticket;
            this.ticketShow = ticketShow;
        }
    
        public string GetTakenRewardKey(int day) => TakenReward_ + day.ToString();

        public void TakeReward(int day)
        {
            Take(day);
            PlayerPrefs.SetInt(GetTakenRewardKey(day), 1);
            PlayerPrefs.Save();
        }

        private void Take(int day)
        {
            switch (day)
            {
                case 0:
                    ticket.CurrentTicket += 500;
                    break;
                case 1:
                    ticket.CurrentTicket += 500;
                    break;
                case 2:
                    ticket.CurrentTicket += 1000;
                    break;
                case 3:
                    ticket.CurrentTicket += 1000;
                    break;
                case 4:
                    ticket.CurrentTicket += 1500;
                    break;
                case 5:
                    ticket.CurrentTicket += 1500;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
            ticketShow.UpdateText();
        }
    }
}