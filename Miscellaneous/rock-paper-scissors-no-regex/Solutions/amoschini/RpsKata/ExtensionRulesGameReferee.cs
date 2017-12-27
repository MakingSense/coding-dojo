using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpsKata
{
    public class ExtensionRulesGameReferee : IGameReferee
    {
        private (GameChoice player1Choice, GameChoice player2Choice, GameResult result)[] _rules = new[]
        {
            (GameChoice.Rock, GameChoice.Rock, GameResult.Draw(GameChoice.Rock)),
            (GameChoice.Paper, GameChoice.Paper, GameResult.Draw(GameChoice.Paper)),
            (GameChoice.Scissors, GameChoice.Scissors, GameResult.Draw(GameChoice.Scissors)),
            (GameChoice.Spock, GameChoice.Spock, GameResult.Draw(GameChoice.Spock)),
            (GameChoice.Lizard, GameChoice.Lizard, GameResult.Draw(GameChoice.Lizard)),
            (GameChoice.Rock, GameChoice.Scissors, GameResult.Player1Won(GameChoice.Rock, "crushes", GameChoice.Scissors)),
            (GameChoice.Rock, GameChoice.Lizard, GameResult.Player1Won(GameChoice.Rock, "crushes", GameChoice.Lizard)),
            (GameChoice.Paper, GameChoice.Rock, GameResult.Player1Won(GameChoice.Paper, "covers", GameChoice.Rock)),
            (GameChoice.Paper, GameChoice.Spock, GameResult.Player1Won(GameChoice.Paper, "disproves", GameChoice.Spock)),
            (GameChoice.Scissors, GameChoice.Paper, GameResult.Player1Won(GameChoice.Scissors, "cuts", GameChoice.Paper)),
            (GameChoice.Scissors, GameChoice.Lizard, GameResult.Player1Won(GameChoice.Scissors, "decapitates", GameChoice.Lizard)),
            (GameChoice.Spock, GameChoice.Scissors, GameResult.Player1Won(GameChoice.Spock, "smashes", GameChoice.Scissors)),
            (GameChoice.Spock, GameChoice.Rock, GameResult.Player1Won(GameChoice.Spock, "vaporizes", GameChoice.Rock)),
            (GameChoice.Lizard, GameChoice.Spock, GameResult.Player1Won(GameChoice.Lizard, "poisons", GameChoice.Spock)),
            (GameChoice.Lizard, GameChoice.Paper, GameResult.Player1Won(GameChoice.Lizard, "eats", GameChoice.Paper)),
            (GameChoice.Scissors, GameChoice.Rock, GameResult.Player2Won(GameChoice.Rock, "crushes", GameChoice.Scissors)),
            (GameChoice.Scissors, GameChoice.Spock, GameResult.Player2Won(GameChoice.Spock, "smashes", GameChoice.Scissors)),
            (GameChoice.Rock, GameChoice.Paper, GameResult.Player2Won(GameChoice.Paper, "covers", GameChoice.Rock)),
            (GameChoice.Rock, GameChoice.Spock, GameResult.Player2Won(GameChoice.Spock, "vaporizes", GameChoice.Rock)),
            (GameChoice.Paper, GameChoice.Scissors, GameResult.Player2Won(GameChoice.Scissors, "cuts", GameChoice.Paper)),
            (GameChoice.Paper, GameChoice.Lizard, GameResult.Player2Won(GameChoice.Lizard, "eats", GameChoice.Paper)),
            (GameChoice.Spock, GameChoice.Paper, GameResult.Player2Won(GameChoice.Paper, "disproves", GameChoice.Spock)),
            (GameChoice.Spock, GameChoice.Lizard, GameResult.Player2Won(GameChoice.Lizard, "poisons", GameChoice.Spock)),
            (GameChoice.Lizard, GameChoice.Rock, GameResult.Player2Won(GameChoice.Rock, "crushes", GameChoice.Lizard)),
            (GameChoice.Lizard, GameChoice.Scissors, GameResult.Player2Won(GameChoice.Scissors, "decapitates", GameChoice.Lizard))
        };

        public GameResult Evaluate(GameSetup gameSetup) => _rules
            .Where(x => x.player1Choice == gameSetup.Player1Choice)
            .Where(x => x.player2Choice == gameSetup.Player2Choice)
            .Select(x => x.result)
            .FirstOrDefault() ?? throw new NotImplementedException("No rule defined for this scenario");
    }
}
