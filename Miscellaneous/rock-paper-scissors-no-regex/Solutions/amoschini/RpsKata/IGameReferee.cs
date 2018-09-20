using System;
using System.Collections.Generic;
using System.Text;

namespace RpsKata
{
    public interface IGameReferee
    {
        GameResult Evaluate(GameSetup gameSetup);
    }
}
