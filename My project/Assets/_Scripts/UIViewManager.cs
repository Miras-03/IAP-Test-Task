using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UISpace
{
    public sealed class UIViewManager : MonoBehaviour
    {
        [Space(20)]
        [Header("Buttons")]
        [SerializeField] private Button play;
        [SerializeField] private Button setting;
        [SerializeField] private Button reward;
        [SerializeField] private Button shop;

        [Space(10)]
        [SerializeField] private Button[] homeButtons;

        [Space(20)]
        [Header("ViewPanels")]
        [SerializeField] private GameObject[] panels;

        private AudioSource clickSound;

        [Inject] 
        public void Constructor(AudioSource[] audious) => clickSound = audious[0];

        private void Start()
        {
            CloseAndOpenMainView();
            AddButtonListeners();
            AddHomeButtonListeners();
        }

        private void AddButtonListeners()
        {
            play.onClick.AddListener(OpenLevelView);
            play.onClick.AddListener(clickSound.Play);

            setting.onClick.AddListener(OpenSettingView);
            setting.onClick.AddListener(clickSound.Play);

            reward.onClick.AddListener(OpenRewardView);
            reward.onClick.AddListener(clickSound.Play);

            shop.onClick.AddListener(OpenShopView);
            shop.onClick.AddListener(clickSound.Play);
        }

        private void AddHomeButtonListeners()
        {
            foreach (Button button in homeButtons)
            {
                button.onClick.AddListener(CloseAndOpenMainView);
                button.onClick.AddListener(clickSound.Play);
            }
        }

        private void OpenMainView() => panels[0].SetActive(true);

        private void OpenLevelView() => panels[1].SetActive(true);

        private void OpenSettingView() => panels[2].SetActive(true);

        private void OpenShopView() => panels[3].SetActive(true);

        private void OpenRewardView() => panels[4].SetActive(true);

        private void CloseAndOpenMainView()
        {
            foreach (GameObject panel in panels)
                panel.SetActive(false);

            OpenMainView();
        }
    }
}