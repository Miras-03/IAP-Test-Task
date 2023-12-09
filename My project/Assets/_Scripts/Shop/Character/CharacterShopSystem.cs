using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TicketSpace;
using LevelSpace;

namespace Shop.Character
{
    public sealed class CharacterShopSystem : MonoBehaviour
    {
        public CharacterForTicket[] shopButtons;

        [SerializeField] private Button shopButton;
        private Ticket ticket;
        private Level level;

        private const string CurrentLevel = nameof(CurrentLevel);
        private const string TicketCount = nameof(TicketCount);

        [Inject]
        public void Construct(Ticket ticket, Level level)
        {
            this.ticket = ticket;
            this.level = level;
        }

        private void Start() => shopButton.onClick.AddListener(InitializeShopButtons);

        public void InitializeShopButtons()
        {
            foreach (CharacterForTicket shopButton in shopButtons)
                shopButton.Initialize(CanBuy(shopButton.CharacterData));
        }

        private bool CanBuy(CharacterData characterData)
        {
            int playerLevel = level.CurrentLevel;
            int ticketsCount = ticket.CurrentTicket;
            return (ticketsCount >= characterData.price) && (playerLevel > characterData.requiredLevel);
        }
    }
}