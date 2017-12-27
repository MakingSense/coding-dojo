using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpsKata
{
    public class WinnerRulesGameReferee : IGameReferee
    {
        private Dictionary<(GameChoice winnerChoice, GameChoice looserChoice), string> _verbByRule = new Dictionary<(GameChoice winnerChoice, GameChoice looserChoice), string>()
        {
            [(GameChoice.Rock, GameChoice.Scissors)] = "crushes",
            [(GameChoice.Rock, GameChoice.Lizard)] = "crushes",
            [(GameChoice.Paper, GameChoice.Rock)] = "covers",
            [(GameChoice.Paper, GameChoice.Spock)] = "disproves",
            [(GameChoice.Scissors, GameChoice.Paper)] = "cuts",
            [(GameChoice.Scissors, GameChoice.Lizard)] = "decapitates",
            [(GameChoice.Spock, GameChoice.Scissors)] = "smashes",
            [(GameChoice.Spock, GameChoice.Rock)] = "vaporizes",
            [(GameChoice.Lizard, GameChoice.Spock)] = "poisons",
            [(GameChoice.Lizard, GameChoice.Paper)] = "eats",
        };

        public GameResult Evaluate(GameSetup gameSetup) =>
            _verbByRule.TryGetValue((gameSetup.Player1Choice, gameSetup.Player2Choice), out var verb1) ? GameResult.Player1Won(gameSetup.Player1Choice, verb1, gameSetup.Player2Choice)
            : _verbByRule.TryGetValue((gameSetup.Player2Choice, gameSetup.Player1Choice), out var verb2) ? GameResult.Player2Won(gameSetup.Player2Choice, verb2, gameSetup.Player1Choice)
            : GameResult.Draw(gameSetup.Player1Choice);
    }
}
