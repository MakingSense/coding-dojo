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
            (GameChoice.Rock, GameChoice.Rock, GameResult.Draw),
            (GameChoice.Paper, GameChoice.Paper, GameResult.Draw),
            (GameChoice.Scissors, GameChoice.Scissors, GameResult.Draw),
            (GameChoice.Rock, GameChoice.Scissors, GameResult.Player1Won),
            (GameChoice.Paper, GameChoice.Rock, GameResult.Player1Won),
            (GameChoice.Scissors, GameChoice.Paper, GameResult.Player1Won),
            (GameChoice.Scissors, GameChoice.Rock, GameResult.Player2Won),
            (GameChoice.Rock, GameChoice.Paper, GameResult.Player2Won),
            (GameChoice.Paper, GameChoice.Scissors, GameResult.Player2Won)
        };

        public GameResult Evaluate(GameSetup gameSetup) => _rules
            .Where(x => x.player1Choice == gameSetup.Player1Choice)
            .Where(x => x.player2Choice == gameSetup.Player2Choice)
            .Select(x => (GameResult?)x.result)
            .FirstOrDefault() ?? throw new NotImplementedException("No rule defined for this scenario");
    }
}
