using UnityEngine;

public class Reward
{
    private const string TakenReward_ = nameof(TakenReward_);

    public string GetTakenRewardKey(int day) => TakenReward_ + day.ToString();

    public void TakeReward(int day)
    {
        PlayerPrefs.SetInt(GetTakenRewardKey(day), 1);
        PlayerPrefs.Save();
    }
}
