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
        private static Random random = new Random();
        public abstract int GetRatingForPlayer(BaseGameAccount player);
        public abstract int GetGameRating();

        public virtual void Play(BaseGameAccount player1, BaseGameAccount player2)
        {
            bool player1Wins = random.Next(2) == 0;

            if (player1Wins)
            {
                player1.WinGame(player2, this);
            }
            else
            {
                player1.LoseGame(player2, this);
            }
        }
    }
}
