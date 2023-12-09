using System;
using UnityEngine;

namespace RewardSpace
{
    public sealed class LoginDate
    {
        private const string LastLoginDate = nameof(LastLoginDate);

        public DateTime GetLastLoginDate()
        {
            if (PlayerPrefs.HasKey(LastLoginDate))
            {
                long ticks = Convert.ToInt64(PlayerPrefs.GetString(LastLoginDate));
                return new DateTime(ticks);
            }

            return DateTime.Now;
        }

        public void SaveLastLoginDate(DateTime date)
        {
            PlayerPrefs.SetString(LastLoginDate, date.Ticks.ToString());
            PlayerPrefs.Save();
        }
    }
}