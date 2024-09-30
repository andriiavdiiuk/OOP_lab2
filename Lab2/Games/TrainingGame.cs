using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Games
{
    public class TrainingGame : BaseGame
    {
        public override int GetGameRating()
        {
            return 0;
        }
        public override int GetRatingForPlayer(BaseGameAccount player)
        {
            return GetGameRating();
        }
    }
}
