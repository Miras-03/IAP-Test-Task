using TicketSpace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop.Character
{
    public sealed class CharacterShopButton : MonoBehaviour
    {
        [SerializeField] private CharacterShopSystem shopSystem;
        [SerializeField] private CharacterData characterData;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI levelText;

        [Header("Image")]
        [SerializeField] private Image checkmarkImage;
        [SerializeField] private Image ticketImage;

        [Header("Button")]
        [SerializeField] private Button buyButton;

        [Header("Audio")]
        [SerializeField] private AudioSource clickSound;

        private Ticket ticket;
        private TicketShow ticketShow;

        private int currentLevel;
        private bool isCharacterBought;
        private bool isThereSelectedButton;

        private const string CurrentLevel = nameof(CurrentLevel);
        private const string LastSelectedCharacter = nameof(LastSelectedCharacter);

        [Inject]
        public void Construct(Ticket ticket, TicketShow ticketShow)
        {
            this.ticket = ticket;
            this.ticketShow = ticketShow;
        }

        private void OnEnable() => buyButton.onClick.AddListener(OnBuyButtonClick);

        private void OnDestroy() => buyButton.onClick.RemoveAllListeners();

        private void OnBuyButtonClick()
        {
            SavePurchaseStatus(characterData.buttonId);
            clickSound.Play();
        }

        public void Initialize(bool canBuy)
        {
            GetDates();

            priceText.text = isCharacterBought ? "0" : characterData.price.ToString();

            buyButton.interactable = canBuy || isCharacterBought;
            priceText.enabled = !isThereSelectedButton;
            ticketImage.enabled = !isThereSelectedButton;

            SetButtonColor(canBuy || isCharacterBought);
            MarkAsSelected(isThereSelectedButton);
            SetTextColor(currentLevel >= characterData.requiredLevel);
        }

        private void GetDates()
        {
            isCharacterBought = PlayerPrefs.GetInt($"Is_{characterData.buttonId}_CharacterBought", 0) == 1;
            isThereSelectedButton = PlayerPrefs.GetInt(LastSelectedCharacter, 0) == characterData.buttonId;
            currentLevel = PlayerPrefs.GetInt(CurrentLevel);
        }

        private void SetButtonColor(bool canBuy) => 
            buyButton.image.color = canBuy ? Color.green : Color.red;

        private void SetTextColor(bool hasEnoughLevel) => 
            levelText.color = hasEnoughLevel ? Color.green : Color.red;

        private void MarkAsSelected(bool isSelected)
        {
            if (isSelected)
                buyButton.image.color = Color.grey;

            checkmarkImage.enabled = isThereSelectedButton;
        }

        private void SavePurchaseStatus(int id)
        {
            PlayerPrefs.SetInt($"Is_{id}_CharacterBought", 1);
            PlayerPrefs.SetInt(LastSelectedCharacter, id);

            shopSystem.InitializeShopButtons();

            UpdateTicket();
        }

        private void UpdateTicket()
        {
            if (!isThereSelectedButton)
                ticket.CurrentTicket -= characterData.price;
            ticketShow.UpdateText();
        }

        public CharacterData CharacterData => characterData;
    }
}