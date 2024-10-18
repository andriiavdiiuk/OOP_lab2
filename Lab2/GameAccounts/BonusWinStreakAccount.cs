using Lab2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.GameAccounts
{
    public class BonusWinStreakAccount : BaseGameAccount
    {
        public int Strike { get; private set; }
        public BonusWinStreakAccount(string username, int baseRating) : base(username, baseRating)
        {
        }
        public override int CalculateWinRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }
            if (rating == 0)
            {
                return 0;
            }
            return rating + 2 * Strike;
        }
        public override int CalculateLoseRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }
            return rating;
        }

        protected override void OnWin()
        {
            Strike++;
        }
        protected override void OnLose()
        {
            Strike = 0;   
        }
    }
}
