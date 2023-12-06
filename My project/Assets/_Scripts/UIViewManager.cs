using UnityEngine;
using UnityEngine.UI;

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

        private void Start()
        {
            CloseAndOpenMainView();
            AddButtonListeners();
            AddHomeButtonListeners();
        }

        private void AddButtonListeners()
        {
            play.onClick.AddListener(OpenLevelView);
            setting.onClick.AddListener(OpenSettingView);
            reward.onClick.AddListener(OpenRewardView);
            shop.onClick.AddListener(OpenShopView);
        }

        private void AddHomeButtonListeners()
        {
            foreach (Button button in homeButtons)
                button.onClick.AddListener(CloseAndOpenMainView);
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