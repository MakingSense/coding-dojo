using System;
using System.Collections.Generic;
using System.Text;

namespace RpsKata
{
    public class SimpleGameReferee : IGameReferee
    {
        public GameResult Evaluate(GameSetup gameSetup)
        {
            return Evaluate(GameResult.Player1Won, gameSetup.Player1Choice, gameSetup.Player2Choice)
                ?? Evaluate(GameResult.Player2Won, gameSetup.Player2Choice, gameSetup.Player1Choice)
                ?? GameResult.Draw(gameSetup.Player1Choice);
        }

        private GameResult Evaluate(Func<GameChoice, string, GameChoice, GameResult> playerWon, GameChoice playerAChoice, GameChoice playerBChoice)
        {
            return playerAChoice == GameChoice.Rock && playerBChoice == GameChoice.Scissors ? playerWon(playerAChoice, "crushes", playerBChoice)
                : playerAChoice == GameChoice.Rock && playerBChoice == GameChoice.Lizard ? playerWon(playerAChoice, "crushes", playerBChoice)
                : playerAChoice == GameChoice.Paper && playerBChoice == GameChoice.Rock ? playerWon(playerAChoice, "covers", playerBChoice)
                : playerAChoice == GameChoice.Paper && playerBChoice == GameChoice.Spock ? playerWon(playerAChoice, "disproves", playerBChoice)
                : playerAChoice == GameChoice.Scissors && playerBChoice == GameChoice.Paper ? playerWon(playerAChoice, "cuts", playerBChoice)
                : playerAChoice == GameChoice.Scissors && playerBChoice == GameChoice.Lizard ? playerWon(playerAChoice, "decapitates", playerBChoice)
                : playerAChoice == GameChoice.Spock && playerBChoice == GameChoice.Scissors ? playerWon(playerAChoice, "smashes", playerBChoice)
                : playerAChoice == GameChoice.Spock && playerBChoice == GameChoice.Rock ? playerWon(playerAChoice, "vaporizes", playerBChoice)
                : playerAChoice == GameChoice.Lizard && playerBChoice == GameChoice.Spock ? playerWon(playerAChoice, "poisons", playerBChoice)
                : playerAChoice == GameChoice.Lizard && playerBChoice == GameChoice.Paper ? playerWon(playerAChoice, "eats", playerBChoice)
                : null;
        }
    }
}
