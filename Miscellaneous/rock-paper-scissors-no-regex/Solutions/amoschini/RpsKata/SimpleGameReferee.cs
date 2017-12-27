﻿using System;
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
                return GameResult.Draw(gameSetup.Player1Choice);
            }

            if (gameSetup.Player1Choice == GameChoice.Rock && gameSetup.Player2Choice == GameChoice.Scissors
                || gameSetup.Player1Choice == GameChoice.Rock && gameSetup.Player2Choice == GameChoice.Lizard
                || gameSetup.Player1Choice == GameChoice.Paper && gameSetup.Player2Choice == GameChoice.Rock
                || gameSetup.Player1Choice == GameChoice.Paper && gameSetup.Player2Choice == GameChoice.Spock
                || gameSetup.Player1Choice == GameChoice.Scissors && gameSetup.Player2Choice == GameChoice.Paper
                || gameSetup.Player1Choice == GameChoice.Scissors && gameSetup.Player2Choice == GameChoice.Lizard
                || gameSetup.Player1Choice == GameChoice.Spock && gameSetup.Player2Choice == GameChoice.Scissors
                || gameSetup.Player1Choice == GameChoice.Spock && gameSetup.Player2Choice == GameChoice.Rock
                || gameSetup.Player1Choice == GameChoice.Lizard && gameSetup.Player2Choice == GameChoice.Spock
                || gameSetup.Player1Choice == GameChoice.Lizard && gameSetup.Player2Choice == GameChoice.Paper)
            {
                return GameResult.Player1Won(gameSetup.Player1Choice, "TODO", gameSetup.Player2Choice);
            }

            return GameResult.Player2Won(gameSetup.Player2Choice, "TODO", gameSetup.Player1Choice);
        }
    }
}
