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
            var player1 = MapEnumToObject(gameSetup.Player1Choice, GameResult.Player1Won, GameResult.Player2Won);
            var player2 = MapEnumToObject(gameSetup.Player2Choice, GameResult.Player2Won, GameResult.Player1Won);
            return player1.PlayAgainst(player2);
        }

        // This method is only necessary to adapt this new implementation to previous 
        // interface. If we decided to use this implementation definitivaly, it should
        // not be necessary.
        private Choice MapEnumToObject(GameChoice choiceEnum, GameResult whoWinIfItWins, GameResult whoWinIfItLooses)
        {
            switch (choiceEnum)
            {
                case GameChoice.Rock: return new Rock(whoWinIfItWins, whoWinIfItLooses);
                case GameChoice.Paper: return new Paper(whoWinIfItWins, whoWinIfItLooses);
                case GameChoice.Scissors: return new Scissors(whoWinIfItWins, whoWinIfItLooses);
                case GameChoice.Lizard: return new Lizard(whoWinIfItWins, whoWinIfItLooses);
                case GameChoice.Spock: return new Spock(whoWinIfItWins, whoWinIfItLooses);
                default: throw new ArgumentOutOfRangeException(nameof(choiceEnum));
            }
        }

        private abstract class Choice
        {
            private readonly GameResult _whoWinIfIWin;
            private readonly GameResult _whoWinIfILoose;

            public Choice(GameResult whoWinIfIWin, GameResult whoWinIfILoose)
            {
                _whoWinIfIWin = whoWinIfIWin;
                _whoWinIfILoose = whoWinIfILoose;
            }

            protected GameResult Draw() => GameResult.Draw;
            protected GameResult IWin() => _whoWinIfIWin;
            protected GameResult ILoose() => _whoWinIfILoose;

            public abstract GameResult PlayAgainst(Choice other);
            public abstract GameResult PlayAgainst(Rock other);
            public abstract GameResult PlayAgainst(Paper other);
            public abstract GameResult PlayAgainst(Scissors other);
            public abstract GameResult PlayAgainst(Lizard other);
            public abstract GameResult PlayAgainst(Spock other);
        }

        private class Rock : Choice
        {
            public Rock(GameResult whoWinIfIWin, GameResult whoWinIfILoose) : base(whoWinIfIWin, whoWinIfILoose) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => Draw();
            public override GameResult PlayAgainst(Paper other) => ILoose();
            public override GameResult PlayAgainst(Scissors other) => IWin();
            public override GameResult PlayAgainst(Lizard other) => IWin();
            public override GameResult PlayAgainst(Spock other) => ILoose();
        }

        private class Paper : Choice
        {
            public Paper(GameResult whoWinIfIWin, GameResult whoWinIfILoose) : base(whoWinIfIWin, whoWinIfILoose) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => IWin();
            public override GameResult PlayAgainst(Paper other) => Draw();
            public override GameResult PlayAgainst(Scissors other) => ILoose();
            public override GameResult PlayAgainst(Lizard other) => ILoose();
            public override GameResult PlayAgainst(Spock other) => IWin();
        }

        private class Scissors : Choice
        {
            public Scissors(GameResult whoWinIfIWin, GameResult whoWinIfILoose) : base(whoWinIfIWin, whoWinIfILoose) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => ILoose();
            public override GameResult PlayAgainst(Paper other) => IWin();
            public override GameResult PlayAgainst(Scissors other) => Draw();
            public override GameResult PlayAgainst(Lizard other) => IWin();
            public override GameResult PlayAgainst(Spock other) => ILoose();
        }

        private class Lizard : Choice
        {
            public Lizard(GameResult whoWinIfIWin, GameResult whoWinIfILoose) : base(whoWinIfIWin, whoWinIfILoose) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => ILoose();
            public override GameResult PlayAgainst(Paper other) => IWin();
            public override GameResult PlayAgainst(Scissors other) => ILoose();
            public override GameResult PlayAgainst(Lizard other) => Draw();
            public override GameResult PlayAgainst(Spock other) => IWin();
        }

        private class Spock : Choice
        {
            public Spock(GameResult whoWinIfIWin, GameResult whoWinIfILoose) : base(whoWinIfIWin, whoWinIfILoose) { }
            public override GameResult PlayAgainst(Choice other) => other.PlayAgainst(this);
            public override GameResult PlayAgainst(Rock other) => IWin();
            public override GameResult PlayAgainst(Paper other) => ILoose();
            public override GameResult PlayAgainst(Scissors other) => IWin();
            public override GameResult PlayAgainst(Lizard other) => ILoose();
            public override GameResult PlayAgainst(Spock other) => Draw();
        }
    }
}
