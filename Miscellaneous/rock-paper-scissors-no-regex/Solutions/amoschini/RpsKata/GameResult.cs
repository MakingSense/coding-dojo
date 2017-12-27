﻿using System;
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

        private GameResult(bool player1Won, bool player2Won)
        {
            TheWinnerIsPlayer1 = player1Won;
            TheWinnerIsPlayer2 = player2Won;
            ItIsADraw = player1Won == player2Won;
        }

        public static GameResult Player1Won() => new GameResult(true, false);
        public static GameResult Player2Won() => new GameResult(false, true);
        public static GameResult Draw() => new GameResult(false, false);
    }
}
