using UnityEngine;
using UnityEngine.UI;

namespace Shop.Character
{
    public sealed class CharacterShopSystem : MonoBehaviour
    {
        public CharacterShopButton[] shopButtons;

        [SerializeField] private Button shopButton;

        private const string CurrentLevel = nameof(CurrentLevel);
        private const string TicketCount = nameof(TicketCount);

        private void Start() => shopButton.onClick.AddListener(InitializeShopButtons);

        public void InitializeShopButtons()
        {
            foreach (CharacterShopButton shopButton in shopButtons)
                shopButton.Initialize(CanBuy(shopButton.CharacterData));
        }

        private bool CanBuy(CharacterData characterData)
        {
            int playerLevel = PlayerPrefs.GetInt(CurrentLevel, 0);
            int ticketsCount = PlayerPrefs.GetInt(TicketCount, 0);
            return (ticketsCount >= characterData.price) && (characterData.requiredLevel > playerLevel);
        }
    }
}