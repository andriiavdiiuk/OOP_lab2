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
        public abstract int GetRatingForPlayer(BaseGameAccount player);
        public abstract int GetGameRating();
    }
}
