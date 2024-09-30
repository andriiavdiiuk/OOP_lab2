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
        public int BaseRating { get; private set; }
        public string Username { get; protected set; }
        public int CurrentRating
        {
            get
            {
                return _currentRating;
            }
            private set
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
            BaseRating = baseRating;
            CurrentRating = baseRating;
        }

 
        public void WinGame(BaseGameAccount opponent, BaseGame game)
        {
            CurrentRating += CalculateWinRating(game.GetRatingForPlayer(this));
            OnWin();
        }
        public void LoseGame(BaseGameAccount opponent, BaseGame game)
        {        
            CurrentRating -= CalculateLoseRating(game.GetRatingForPlayer(this));
            OnLose();
        }
        public virtual string GetStats()
        {
            string result = $"{Username}\n";
            result += $"AccountType: {GetType().Name}\n";
            result += $"Current Rating: {CurrentRating}\n";
            result += $"Games Count: {GamesCount}\n";
            result += "--------------------------------------------------------------------------------------------\n";
            result += $"|{"Opponent",-12} | {"Win/Lost",-10} | {"Game Rating",-11} | {"Rating Change",-13} | {"Id",-4}| {"Game Type",-25} |\n";
            result += "--------------------------------------------------------------------------------------------\n";
            string opponent = "";
            string winLost = "";
            int baseRating = BaseRating;
            int ratingChange = 0;
            string rating = "";
            List<GameRecord> history = GameRepository.GetHistory(this);
            foreach (GameRecord game in history)
            {
                if (game.Winner.Username == Username)
                {
                    opponent = game.Loser.Username;
                    ratingChange = game.WinnerRatingChange;
                    winLost = "Win";
                }
                else
                {
                    opponent = game.Winner.Username;
                    ratingChange = game.LoserRatingChange;
                   
                    winLost = "Lost";
                }
                baseRating += ratingChange;
                rating = $"{baseRating,-5} ({ratingChange})";
                result += $"|{opponent,-12} | {winLost,-10} | {game.Rating,-11} | {rating + "",-13} | {game.Id,-4}| {game.Game.GetType().Name,-25} |\n";
            };
            result += "--------------------------------------------------------------------------------------------\n";

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
