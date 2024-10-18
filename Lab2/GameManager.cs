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
        public static void PlayRandomGame(BaseGameAccount player1, BaseGameAccount player2)
        {
            int rand = random.Next(3);
            BaseGame game;
            switch (rand)
            {
                default:
                case 0:
                    game = GameFactory.GetStandardGame();
                    break;
                case 1:
                    game = GameFactory.GetTrainingGame();
                    break;
                case 2:
                    BaseGameAccount playerWithRating;
                    if (random.Next(2) == 0) playerWithRating = player1;
                    else playerWithRating = player2;
                    game = GameFactory.GetSinglePlayerRatingGame(playerWithRating);
                    break;
            }
            game.Play(player1, player2);
        }
    }
}
