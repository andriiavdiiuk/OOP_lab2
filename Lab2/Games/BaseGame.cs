using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Games
{
    public abstract class BaseGame
    {
        private static int TotalIds = 0;
        public int Id { get; set; }
        public BaseGameAccount Winner { get; set; }
        public BaseGameAccount Loser { get; set; }
        public int WinnerRatingChange { get; set; }
        public int LoserRatingChange { get; set; }
        public int Rating { get; set; }

        public BaseGame(BaseGameAccount winner, BaseGameAccount loser) 
        {
            Id = TotalIds;
            Winner = winner;
            Loser = loser;
            Rating = GetGameRating();

            TotalIds++;
        }

        public abstract int GetRatingForPlayer(BaseGameAccount player);
        public abstract int GetGameRating();
    }
}
