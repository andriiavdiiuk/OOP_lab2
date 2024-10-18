using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;
using Lab2.GameAccounts;
namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {      
            BaseGameAccount Player1 = new StandardAccount("Player 1", 100);
            BaseGameAccount Player2 = new HalfLossPointsAccount("Player 2", 100);
            BaseGameAccount Player3 = new BonusWinStreakAccount("Player 3", 100);

            for (int i = 0; i < 10; i++) 
            {
                GameManager.PlayRandomGame(Player1, Player2);
                GameManager.PlayRandomGame(Player1, Player3);
                GameManager.PlayRandomGame(Player2, Player3);
            }

            Console.WriteLine(Player1.GetStats());
            Console.WriteLine(Player2.GetStats());
            Console.WriteLine(Player3.GetStats());

            Console.WriteLine(GameRepository.GetStats());
        }
    }
}
