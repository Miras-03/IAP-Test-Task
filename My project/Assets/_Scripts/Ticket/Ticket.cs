using UnityEngine;

namespace TicketSpace
{
    public sealed class Ticket
    {
        private const string TicketCount = nameof(TicketCount);

        public int CurrentTicket
        {
            get => PlayerPrefs.GetInt(TicketCount, 0);
            set
            {
                if (PlayerPrefs.GetInt(TicketCount, 0) + value >= 0)
                    PlayerPrefs.SetInt(TicketCount, value);
                else
                    PlayerPrefs.SetInt(TicketCount, 0);
            }
        }
    }
}