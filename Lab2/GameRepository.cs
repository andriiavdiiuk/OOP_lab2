using Lab2.GameAccounts;
using Lab2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class GameRepository
    {
        private static List<GameRecord> GameHistory = new List<GameRecord>();

        public static void AddGame(GameRecord game)
        {
            GameHistory.Add(game);
        }

        public static List<GameRecord> GetHistory(BaseGameAccount player)
        {
            return GameHistory
                    .Where(game => game.Winner == player || game.Loser == player)
                    .ToList();
        }

        public static string GetStats()
        {
            string result = "All Games:\n";
            result += "-----------------------------------------------------------------------------------------------------------------------\n";
            result += $"|{"Winner",-12} | {"Loser",-12} | {"Rating",-6} | {"Winner Rating Change",-20} | {"Loser Rating Change",-20} | {"Id",-4} | {"Game Type",-24} |\n";
            result += "-----------------------------------------------------------------------------------------------------------------------\n";
            string winnerRating = "";
            string loserRating = "";
            foreach (GameRecord game in GameHistory)
            {
                winnerRating = $"{game.WinnerRating,-3} ({game.WinnerRatingChange})";
                loserRating = $"{game.LoserRating,-3} ({game.LoserRatingChange})";
                result += $"|{game.Winner.Username,-12} | {game.Loser.Username,-12} | {game.Rating,-6} | {winnerRating,-20} | {loserRating,-20} | {game.Id,-4} | {game.Game.GetType().Name,-24} |\n";
            };
            result += "-----------------------------------------------------------------------------------------------------------------------\n";

            return result;
        }
    }
}
