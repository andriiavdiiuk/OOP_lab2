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
            foreach (GameRecord game in GameHistory)
            {
                result += $"|{game.Winner.Username,-12} | {game.Loser.Username,-12} | {game.Rating,-6} | {game.WinnerRatingChange,-20} | {game.LoserRatingChange,-20} | {game.Id,-4} | {game.Game.GetType().Name,-24} |\n";
            };
            result += "-----------------------------------------------------------------------------------------------------------------------\n";


            return result;
        }
    }
}
