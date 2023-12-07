using UnityEngine;

namespace Shop
{
    public sealed class Ticket
    {
        private const string TicketCount = nameof(TicketCount);

        public int CurrentTicket
        {
            get => PlayerPrefs.GetInt(TicketCount, 0);
            set => PlayerPrefs.SetInt(TicketCount, value);
        }
    }
}