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
        public static StandardGame GetStandardGame()
        {
            return new StandardGame();
        }

        public static TrainingGame GetTrainingGame()
        {
            return new TrainingGame();
        }

        public static SinglePlayerRatingGame GetSinglePlayerRatingGame(BaseGameAccount rankedPlayer)
        {
            return new SinglePlayerRatingGame(rankedPlayer);
        }
    }
}
