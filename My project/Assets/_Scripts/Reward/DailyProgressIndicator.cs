using TMPro;
using UnityEngine.UI;

namespace RewardSpace
{
    public class DailyProgressIndicator
    {
        private Slider progressBar;
        private TextMeshProUGUI dayCount;

        public DailyProgressIndicator(Slider progressBar, TextMeshProUGUI dayCount)
        {
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