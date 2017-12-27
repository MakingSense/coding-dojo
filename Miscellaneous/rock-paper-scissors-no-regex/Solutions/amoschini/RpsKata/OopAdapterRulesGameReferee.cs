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
            var player1 = MapEnumToObject(gameSetup.Player1Choice);
            var player2 = MapEnumToObject(gameSetup.Player2Choice);
            return player1.PlayAgainst(player2);
        }

        // This method is only necessary to adapt this new implementation to previous 
        // interface. If we decided to use this implementation definitivaly, it should
        // not be necessary.
        private IChoice MapEnumToObject(GameChoice choiceEnum)
        {
            switch (choiceEnum)
            {
                case GameChoice.Rock: return new Rock();
                case GameChoice.Paper: return new Paper();
                case GameChoice.Scissors: return new Scissors();
                case GameChoice.Lizard: return new Lizard();
                case GameChoice.Spock: return new Spock();
                default: throw new ArgumentOutOfRangeException(nameof(choiceEnum));
            }
        }

        private interface IChoice
        {
            GameResult PlayAgainst(IChoice player2Choice);
            GameResult PlayAgainst(Rock player1Choice);
            GameResult PlayAgainst(Paper player1Choice);
            GameResult PlayAgainst(Scissors player1Choice);
            GameResult PlayAgainst(Lizard player1Choice);
            GameResult PlayAgainst(Spock player1Choice);
        }

        private class Rock : IChoice
        {
            public GameResult PlayAgainst(IChoice player2Choice) => player2Choice.PlayAgainst(this);
            public GameResult PlayAgainst(Rock player1Choice) => GameResult.Draw;
            public GameResult PlayAgainst(Paper player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Scissors player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Lizard player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Spock player1Choice) => GameResult.Player1Won;
        }

        private class Paper : IChoice
        {
            public GameResult PlayAgainst(IChoice player2Choice) => player2Choice.PlayAgainst(this);
            public GameResult PlayAgainst(Rock player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Paper player1Choice) => GameResult.Draw;
            public GameResult PlayAgainst(Scissors player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Lizard player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Spock player1Choice) => GameResult.Player2Won;
        }

        private class Scissors : IChoice
        {
            public GameResult PlayAgainst(IChoice player2Choice) => player2Choice.PlayAgainst(this);
            public GameResult PlayAgainst(Rock player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Paper player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Scissors player1Choice) => GameResult.Draw;
            public GameResult PlayAgainst(Lizard player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Spock player1Choice) => GameResult.Player1Won;
        }

        private class Lizard : IChoice
        {
            public GameResult PlayAgainst(IChoice player2Choice) => player2Choice.PlayAgainst(this);
            public GameResult PlayAgainst(Rock player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Paper player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Scissors player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Lizard player1Choice) => GameResult.Draw;
            public GameResult PlayAgainst(Spock player1Choice) => GameResult.Player2Won;
        }

        private class Spock : IChoice
        {
            public GameResult PlayAgainst(IChoice player2Choice) => player2Choice.PlayAgainst(this);
            public GameResult PlayAgainst(Rock player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Paper player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Scissors player1Choice) => GameResult.Player2Won;
            public GameResult PlayAgainst(Lizard player1Choice) => GameResult.Player1Won;
            public GameResult PlayAgainst(Spock player1Choice) => GameResult.Draw;
        }
    }
}
