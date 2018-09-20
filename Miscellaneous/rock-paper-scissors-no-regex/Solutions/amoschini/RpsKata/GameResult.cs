using System;
using System.Collections.Generic;
using System.Text;

namespace RpsKata
{
    public class GameResult
    {
        public bool TheWinnerIsPlayer1 { get; }
        public bool TheWinnerIsPlayer2 { get; }
        public bool ItIsADraw { get; }
        public string Explanation { get; }

        private GameResult(
            bool player1Won,
            bool player2Won,
            string explanation)
        {
            TheWinnerIsPlayer1 = player1Won;
            TheWinnerIsPlayer2 = player2Won;
            ItIsADraw = player1Won == player2Won;
            Explanation = explanation;
        }

        public static GameResult Player1Won(GameChoice winnerChoise, string action, GameChoice looserChoice) => new GameResult(true, false, $"{winnerChoise} {action} {looserChoice}");
        public static GameResult Player2Won(GameChoice winnerChoise, string action, GameChoice looserChoice) => new GameResult(false, true, $"{winnerChoise} {action} {looserChoice}");
        public static GameResult Draw(GameChoice choice) => new GameResult(false, false, $"Both players chose {choice.ToString()}");
    }
}
