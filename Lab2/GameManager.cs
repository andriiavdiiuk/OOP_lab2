using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.GameAccounts;
using Lab2.Games;
namespace Lab2
{
    public static class GameManager
    { 
        private static Random random = new Random();
        public static void Play(BaseGameAccount player1, BaseGameAccount player2)
        {
            
            bool player1Wins = random.Next(2) == 0;
     
            if (player1Wins)
            {
                BaseGame game = RandomGame(player1, player2);
                GameRecord record = new GameRecord(player1, player2, game);
                GameRepository.AddGame(record);
                player1.WinGame(player1, game);
                player2.LoseGame(player2, game);

            }
            else
            {
                BaseGame game = RandomGame(player2, player1);
                GameRecord record = new GameRecord(player2,player1 ,game);
                GameRepository.AddGame(record);
                player1.LoseGame(player2, game);
                player2.WinGame(player1, game);
            }
        }
        private static BaseGame RandomGame(BaseGameAccount winner, BaseGameAccount loser)
        {
            int rand = random.Next(3);

            switch (rand)
            {
                default:
                case 0:
                    return GameFactory.GetStandardGame();
                case 1:
                    return GameFactory.GetTrainingGame();
                case 2:
                    BaseGameAccount playerWithRating;
                    if (random.Next(2) == 0) playerWithRating = winner;
                    else playerWithRating = loser;

                    return GameFactory.GetSinglePlayerRatingGame(playerWithRating);
            }
        }
    }
}
