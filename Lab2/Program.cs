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
            
            BaseGameAccount Player1 = new StandardAccount("Player 1", 1000);
            BaseGameAccount Player2 = new HalfLossPointsAccount("Player 2", 1000);
            BaseGameAccount Player3 = new BonusWinStreakAccount("Player 3", 1000);
            Random rand = new Random();

            for (int i = 0; i < 50; i++) 
            {
                GameManager.Play(Player1, Player2);
                GameManager.Play(Player1, Player3);
                GameManager.Play(Player2, Player3);
            }

            Console.WriteLine(Player1.GetStats());
            Console.WriteLine(Player2.GetStats());
            Console.WriteLine(Player3.GetStats());

            Console.WriteLine(GameRepository.GetStats());
        }
    }
}
