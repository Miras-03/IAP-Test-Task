using TicketSpace;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelSpace
{
    public sealed class OpenLevel : IInitializable
    {
        private Level level;
        private Ticket ticket;
        private TicketShow ticketShow;

        private Button[] buttons;
        private AudioSource clickSound;

        private const string LevelEnabled_ = nameof(LevelEnabled_);
        private const string CurrentLevel = nameof(CurrentLevel);

        [Inject]
        public void Constructor(Level level, Ticket ticket, TicketShow ticketShow, 
            Button[] buttons, AudioSource[] audious) {
            this.level = level;
            this.ticket = ticket;
            this.ticketShow = ticketShow;
            this.buttons = buttons;
            clickSound = audious[0];
        }

        public void Initialize() => AddButtonListeners();

        private void AddButtonListeners()
        {
            for (int i = 0; i < buttons.Length - 1; i++)
            {
                int nextLevel = i + 1;
                buttons[i].onClick.AddListener(() => OpenNextLevel(nextLevel));
                buttons[i].onClick.AddListener(clickSound.Play);
            }
        }

        private void OpenNextLevel(int nextLevel)
        {
            PlayerPrefs.SetInt(LevelEnabled_+nextLevel, 1); 
            PlayerPrefs.SetInt(CurrentLevel, nextLevel);
            PlayerPrefs.Save();

            level.EnableLevels();
            UpgradeTicket();
        }

        private void UpgradeTicket()
        {
            ticket.CurrentTicket += 50;
            ticketShow.UpdateText();
        }
    }
}