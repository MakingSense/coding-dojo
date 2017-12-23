using System;
using System.Collections.Generic;
using System.Text;

namespace RpsKata
{
    public class SimpleGameReferee : IGameReferee
    {
        public GameResult Evaluate(GameSetup gameSetup)
        {
            if (gameSetup.Player1Choice == gameSetup.Player2Choice)
            {
                return GameResult.Draw;
            }

            throw new NotImplementedException();
        }
    }
}
