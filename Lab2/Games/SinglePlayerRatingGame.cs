using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Games
{
    public class SinglePlayerRatingGame : BaseGame
    {
        private Random rand = new Random();
        private int gameRating = -1;
        private BaseGameAccount RankedPlayer;
        public SinglePlayerRatingGame(BaseGameAccount rankedPlayer)
        {  
            RankedPlayer = rankedPlayer;
        }

        public override int GetGameRating()
        {
            if (gameRating < 0)
            {
                gameRating = rand.Next(10, 100);
            }
            return gameRating;
        }
        public override int GetRatingForPlayer(BaseGameAccount player)
        {
            if (RankedPlayer == player)
            {
                return GetGameRating();
            }
            return 0;
        }
    }
}
