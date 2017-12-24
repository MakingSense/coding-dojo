using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpsKata
{
    public class WinnerRulesGameReferee : IGameReferee
    {
        private (GameChoice winnerChoice, GameChoice looserChoice)[] _rules = new[]
        {
            (GameChoice.Rock, GameChoice.Scissors),
            (GameChoice.Paper, GameChoice.Rock),
            (GameChoice.Scissors, GameChoice.Paper)
        };

        public GameResult Evaluate(GameSetup gameSetup) =>
            _rules.Any(x => x.winnerChoice == gameSetup.Player1Choice && x.looserChoice == gameSetup.Player2Choice) ? GameResult.Player1Won
            : _rules.Any(x => x.winnerChoice == gameSetup.Player2Choice && x.looserChoice == gameSetup.Player1Choice) ? GameResult.Player2Won
            : GameResult.Draw;
    }
}
