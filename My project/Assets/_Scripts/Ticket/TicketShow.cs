using TMPro;
using Zenject;

namespace TicketSpace
{
    public sealed class TicketShow : IInitializable
    {
        private Ticket ticket;
        private TextMeshProUGUI ticketIndicator;

        [Inject]
        public void Constructor(Ticket ticket, TextMeshProUGUI[] texts)
        {
            ticketIndicator = texts[0];
            this.ticket = ticket;
        }

        public void Initialize() => UpdateText();

        public void UpdateText() => ticketIndicator.text = ticket.CurrentTicket.ToString();
    }
}