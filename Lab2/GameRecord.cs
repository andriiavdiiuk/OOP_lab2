using Lab2.GameAccounts;
using Lab2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class GameRecord
    {
        private static int TotalIds = 0;
        public int Id { get; set; }
        public BaseGameAccount Winner { get; set; }
        public BaseGameAccount Loser { get; set; }
        public BaseGame Game { get; set; }  
        public int WinnerRatingChange { get; set; }
        public int LoserRatingChange { get; set; }
        public int Rating { get; set; }

        public GameRecord(BaseGameAccount winner, BaseGameAccount loser, BaseGame game)
        {
            Id = TotalIds;
            Winner = winner;
            Loser = loser;
            Rating = game.GetGameRating();
            WinnerRatingChange = winner.CalculateWinRating(game.GetRatingForPlayer(winner));
            LoserRatingChange = -loser.CalculateLoseRating(game.GetRatingForPlayer(loser));
            Game = game;

            TotalIds++;
        }
    }
}
