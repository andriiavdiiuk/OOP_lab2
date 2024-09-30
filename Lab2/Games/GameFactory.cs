using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Games
{
    public static class GameFactory
    {
        public static StandardGame GetStandardGame(BaseGameAccount winner, BaseGameAccount loser)
        {
            return new StandardGame(winner,loser);
        }

        public static TrainingGame GetTrainingGame(BaseGameAccount winner, BaseGameAccount loser)
        {
            return new TrainingGame(winner, loser);
        }

        public static SinglePlayerRatingGame GetSinglePlayerRatingGame(BaseGameAccount winner, BaseGameAccount loser, BaseGameAccount rankedPlayer)
        {
            return new SinglePlayerRatingGame(winner, loser,rankedPlayer);
        }
    }
}
