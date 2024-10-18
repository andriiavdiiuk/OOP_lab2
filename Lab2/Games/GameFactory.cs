using Lab2.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Games
{
    public enum GameType
    {
        Standard,
        Training,
        SinglePlayer
    } 
    public static class GameFactory
    {
        public static BaseGame GetGame(GameType type, BaseGameAccount? rankedPlayer=null)
        {
            switch (type)
            {
                case GameType.Standard:
                    return new StandardGame();
                case GameType.Training:
                    return new TrainingGame();
                case GameType.SinglePlayer:
                    if (rankedPlayer != null)
                    {
                        return new SinglePlayerRatingGame(rankedPlayer);
                    }
                    break;
            }
            throw new ArgumentException();
        }
    }
}
