using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpsKata
{
    public class OopAdapterRulesGameReferee : IGameReferee
    {
        public GameResult Evaluate(GameSetup gameSetup)
        {
            var player1Choice = MapEnumToObject(gameSetup.Player1Choice, GameResult.Player1Won);
            var player2Choice = MapEnumToObject(gameSetup.Player2Choice, GameResult.Player2Won);
            return player1Choice.PlayAgainst(player2Choice);
        }

        // This method is only necessary to adapt this new implementation to previous 
        // interface. If we decided to use this implementation definitivaly, it should
        // not be necessary.
        private Choice MapEnumToObject(GameChoice choiceEnum, Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins)
        {
            switch (choiceEnum)
            {
                case GameChoice.Rock: return new Rock(resultFactoryIfItWins);
                case GameChoice.Paper: return new Paper(resultFactoryIfItWins);
                case GameChoice.Scissors: return new Scissors(resultFactoryIfItWins);
                case GameChoice.Lizard: return new Lizard(resultFactoryIfItWins);
                case GameChoice.Spock: return new Spock(resultFactoryIfItWins);
                default: throw new ArgumentOutOfRangeException(nameof(choiceEnum));
            }
        }

        private abstract class Choice
        {
            private readonly Func<GameChoice, string, GameChoice, GameResult> _resultFactoryIfItWins;

            public Choice(Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins)
            {
                _resultFactoryIfItWins = resultFactoryIfItWins;
            }

            protected GameResult Draw() => GameResult.Draw(ToGameChoice());
            public GameResult IWin(string verb, Choice looser) => _resultFactoryIfItWins(ToGameChoice(), verb, looser.ToGameChoice());

            public abstract GameResult PlayAgainst(Choice other);
            public abstract GameResult PlayAgainst(Rock other);
            public abstract GameResult PlayAgainst(Paper other);
            public abstract GameResult PlayAgainst(Scissors other);
            public abstract GameResult PlayAgainst(Lizard other);
            public abstract GameResult PlayAgainst(Spock other);

            public abstract GameChoice ToGameChoice();
        }

        private class Rock : Choice
        {
            public Rock(Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins) : base(resultFactoryIfItWins) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => Draw();
            public override GameResult PlayAgainst(Paper other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Scissors other) => IWin("crushes", other);
            public override GameResult PlayAgainst(Lizard other) => IWin("crushes", other);
            public override GameResult PlayAgainst(Spock other) => other.PlayAgainst(this);
            public override GameChoice ToGameChoice() => GameChoice.Rock;
        }

        private class Paper : Choice
        {
            public Paper(Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins) : base(resultFactoryIfItWins) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => IWin("covers", other);
            public override GameResult PlayAgainst(Paper other) => Draw();
            public override GameResult PlayAgainst(Scissors other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Lizard other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Spock other) => IWin("disproves", other);
            public override GameChoice ToGameChoice() => GameChoice.Paper;
        }

        private class Scissors : Choice
        {
            public Scissors(Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins) : base(resultFactoryIfItWins) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Paper other) => IWin("cuts", other);
            public override GameResult PlayAgainst(Scissors other) => Draw();
            public override GameResult PlayAgainst(Lizard other) => IWin("decapitates", other);
            public override GameResult PlayAgainst(Spock other) => other.PlayAgainst(this);
            public override GameChoice ToGameChoice() => GameChoice.Scissors;
        }

        private class Lizard : Choice
        {
            public Lizard(Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins) : base(resultFactoryIfItWins) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Paper other) => IWin("eats", other);
            public override GameResult PlayAgainst(Scissors other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Lizard other) => Draw();
            public override GameResult PlayAgainst(Spock other) => IWin("poisons", other);
            public override GameChoice ToGameChoice() => GameChoice.Lizard;
        }

        private class Spock : Choice
        {
            public Spock(Func<GameChoice, string, GameChoice, GameResult> resultFactoryIfItWins) : base(resultFactoryIfItWins) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => IWin("vaporizes", other);
            public override GameResult PlayAgainst(Paper other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Scissors other) => IWin("smashes", other);
            public override GameResult PlayAgainst(Lizard other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Spock other) => Draw();
            public override GameChoice ToGameChoice() => GameChoice.Spock;
        }
    }
}
