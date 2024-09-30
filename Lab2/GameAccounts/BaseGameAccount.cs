using Lab2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.GameAccounts
{
    public abstract class BaseGameAccount : IEquatable<BaseGameAccount>
    {
        protected int _currentRating = 1;
        public string Username { get; protected set; }
        public int CurrentRating
        {
            get
            {
                return _currentRating;
            }
            protected set
            {
                if (value < 1)
                {
                    _currentRating = 1;
                }
                else
                {
                    _currentRating = value;
                }
            }
        }
        public int GamesCount
        {
            get
            {
                return GameRepository.GetHistory(this).Count;
            }
        }

        protected virtual void OnWin() { }
        protected virtual void OnLose() { }
        public abstract int CalculateWinRating(int rating);
        public abstract int CalculateLoseRating(int rating);

        public BaseGameAccount(string username, int baseRating)
        {
            Username = username;
            CurrentRating = baseRating;
        }

 
        public void WinGame(BaseGameAccount opponent, BaseGame game)
        {
            OnWin();
            CurrentRating += CalculateWinRating(game.GetRatingForPlayer(this));
        }
        //private void WinGame(BaseGameAccount opponent, BaseGame game, GameRecord record) 
        //{
        //    OnWin();
        //}
        public void LoseGame(BaseGameAccount opponent, BaseGame game)
        {
            OnLose();
            CurrentRating -= CalculateLoseRating(game.GetRatingForPlayer(this));
        }
        //private void LoseGame(BaseGameAccount opponent, BaseGame game, GameRecord record) 
        //{
        //    OnLose();
        //}
        public virtual string GetStats()
        {
            string result = $"{Username}\n";
            result += $"AccountType: {GetType().Name}\n";
            result += $"Current Rating: {CurrentRating}\n";
            result += $"Games Count: {GamesCount}\n";
            result += "-----------------------------------------------------------------------\n";
            result += $"|{"Opponent",-12} | {"Win/Lost",-10} | {"Rating",-6} |  {"Id",-4}| {"Game Type",-25} |\n";
            result += "-----------------------------------------------------------------------\n";
            string opponent = "";
            string winLost = "";
            List<BaseGame> history = GameRepository.GetHistory(this);
            foreach (BaseGame game in history)
            {
                if (game.Winner.Username == Username)
                {
                    opponent = game.Loser.Username;
                    winLost = "Win";
                }
                else
                {
                    opponent = game.Winner.Username;
                    winLost = "Lost";
                }
                
                result += $"|{opponent,-12} | {winLost,-10} | {game.Rating,-6} | {game.Id,-4}| {game.GetType().Name,-25} |\n";
            };
            result += "-----------------------------------------------------------------------\n";

            return result;
        }
        public bool Equals(BaseGameAccount? obj)
        {
            if (obj == null)
                return false;

            return Username == obj.Username;
        }
        public override bool Equals(object? obj) => Equals(obj as BaseGameAccount);
        public static bool operator ==(BaseGameAccount? b1, BaseGameAccount? b2)
        {
            if ((object)b1 == null)
                return ((object)b2 == null);

            return b1.Equals(b2);
        }

        public static bool operator !=(BaseGameAccount? b1, BaseGameAccount? b2)
        {
            return !(b1 == b2);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
}
}
