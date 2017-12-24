using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpsKata
{
    public class WinnerRulesGameReferee : IGameReferee
    {
        private HashSet<(GameChoice winnerChoice, GameChoice looserChoice)> _rules = new HashSet<(GameChoice winnerChoice, GameChoice looserChoice)>()
        {
            (GameChoice.Rock, GameChoice.Scissors),
            (GameChoice.Paper, GameChoice.Rock),
            (GameChoice.Scissors, GameChoice.Paper)
        };

        public GameResult Evaluate(GameSetup gameSetup) =>
            _rules.Contains((gameSetup.Player1Choice, gameSetup.Player2Choice)) ? GameResult.Player1Won
            : _rules.Contains((gameSetup.Player2Choice, gameSetup.Player1Choice)) ? GameResult.Player2Won
            : GameResult.Draw;
    }
}
