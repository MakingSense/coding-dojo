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
            var player1Choice = MapEnumToObject(gameSetup.Player1Choice, GameResult.Player1Won());
            var player2Choice = MapEnumToObject(gameSetup.Player2Choice, GameResult.Player2Won());
            return player1Choice.PlayAgainst(player2Choice);
        }

        // This method is only necessary to adapt this new implementation to previous 
        // interface. If we decided to use this implementation definitivaly, it should
        // not be necessary.
        private Choice MapEnumToObject(GameChoice choiceEnum, GameResult resultIfItWins)
        {
            switch (choiceEnum)
            {
                case GameChoice.Rock: return new Rock(resultIfItWins);
                case GameChoice.Paper: return new Paper(resultIfItWins);
                case GameChoice.Scissors: return new Scissors(resultIfItWins);
                case GameChoice.Lizard: return new Lizard(resultIfItWins);
                case GameChoice.Spock: return new Spock(resultIfItWins);
                default: throw new ArgumentOutOfRangeException(nameof(choiceEnum));
            }
        }

        private abstract class Choice
        {
            private readonly GameResult _resultIfIWin;

            public Choice(GameResult resultIfIWin)
            {
                _resultIfIWin = resultIfIWin;
            }

            protected GameResult Draw() => GameResult.Draw();
            public GameResult IWin() => _resultIfIWin;

            public abstract GameResult PlayAgainst(Choice other);
            public abstract GameResult PlayAgainst(Rock other);
            public abstract GameResult PlayAgainst(Paper other);
            public abstract GameResult PlayAgainst(Scissors other);
            public abstract GameResult PlayAgainst(Lizard other);
            public abstract GameResult PlayAgainst(Spock other);
        }

        private class Rock : Choice
        {
            public Rock(GameResult resultIfIWin) : base(resultIfIWin) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => Draw();
            public override GameResult PlayAgainst(Paper other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Scissors other) => IWin();
            public override GameResult PlayAgainst(Lizard other) => IWin();
            public override GameResult PlayAgainst(Spock other) => other.PlayAgainst(this);
        }

        private class Paper : Choice
        {
            public Paper(GameResult resultIfIWin) : base(resultIfIWin) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => IWin();
            public override GameResult PlayAgainst(Paper other) => Draw();
            public override GameResult PlayAgainst(Scissors other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Lizard other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Spock other) => IWin();
        }

        private class Scissors : Choice
        {
            public Scissors(GameResult resultIfIWin) : base(resultIfIWin) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Paper other) => IWin();
            public override GameResult PlayAgainst(Scissors other) => Draw();
            public override GameResult PlayAgainst(Lizard other) => IWin();
            public override GameResult PlayAgainst(Spock other) => other.PlayAgainst(this);
        }

        private class Lizard : Choice
        {
            public Lizard(GameResult resultIfIWin) : base(resultIfIWin) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Paper other) => IWin();
            public override GameResult PlayAgainst(Scissors other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Lizard other) => Draw();
            public override GameResult PlayAgainst(Spock other) => IWin();
        }

        private class Spock : Choice
        {
            public Spock(GameResult resultIfIWin) : base(resultIfIWin) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => IWin();
            public override GameResult PlayAgainst(Paper other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Scissors other) => IWin();
            public override GameResult PlayAgainst(Lizard other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Spock other) => Draw();
        }
    }
}
