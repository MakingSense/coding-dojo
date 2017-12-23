using System;
using System.Collections.Generic;
using System.Text;

namespace RpsKata
{
    public class SimpleGameReferee : IGameReferee
    {
        public GameResult Evaluate(GameSetup gameSetup)
        {
            return GameResult.Draw;
        }
    }
}
