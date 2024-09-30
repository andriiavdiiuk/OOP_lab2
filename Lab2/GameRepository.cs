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
        private static List<BaseGame> GameHistory = new List<BaseGame>();

        public static void AddGame(BaseGame game)
        {
            GameHistory.Add(game);
        }

        public static List<BaseGame> GetHistory(BaseGameAccount player)
        {
            return GameHistory
                    .Where(game => game.Winner == player || game.Loser == player)
                    .ToList();
        }

        public static string GetStats()
        {
            string result = "All Games:\n";
            result += "--------------------------------------------------------------------------\n";
            result += $"|{"Winner",-12} | {"Loser",-12} | {"Rating",-6} |  {"Id",-4}| {"Game Type",-25} |\n";
            result += "--------------------------------------------------------------------------\n";
            foreach (BaseGame game in GameHistory)
            {

                result += $"|{game.Winner.Username,-12} | {game.Loser.Username,-12} | {game.Rating,-6} | {game.Id,-4 } | {game.GetType().Name,-25} |\n";
            };
            result += "--------------------------------------------------------------------------\n";
                       

            return result;
        }
    }
}
