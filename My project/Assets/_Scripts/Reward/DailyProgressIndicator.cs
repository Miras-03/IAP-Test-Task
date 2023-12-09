using TMPro;
using UnityEngine.UI;

namespace RewardSpace
{
    public class DailyProgressIndicator
    {
        private Reward reward;
        private Slider progressBar;
        private TextMeshProUGUI dayCount;

        public DailyProgressIndicator(Reward reward, Slider progressBar, TextMeshProUGUI dayCount)
        {
            this.reward = reward;
            this.progressBar = progressBar;
            this.dayCount = dayCount;
        }

        public void Indicate(int day)
        {
            day += 1;
            progressBar.value = (float)day / 7;
            dayCount.text = $"{day}/7";
        }
    }
}