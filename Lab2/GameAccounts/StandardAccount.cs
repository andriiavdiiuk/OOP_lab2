using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.GameAccounts
{
    public class StandardAccount : BaseGameAccount
    {
        public StandardAccount(string username, int baseRating) : base(username, baseRating)
        {
        }

        public override int CalculateWinRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }
            return rating;
        }
        public override int CalculateLoseRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }
            return rating;
        }     
    }
}
