using System;
using Xunit;

namespace RpsKata
{
    public class SimpleGameRefereeTest
    {
        [Theory]
        [InlineData(GameChoice.Rock)]
        [InlineData(GameChoice.Paper)]
        [InlineData(GameChoice.Scissors)]
        public void Evaluate_same_choice_should_return_Draw(GameChoice selectedChoice)
        {
            // Arrange
            var setup = new GameSetup()
            {
                Player1Choice = selectedChoice,
                Player2Choice = selectedChoice
            };
            var expectedResult = GameResult.Draw;
            var sut = new SimpleGameReferee();

            // Act
            var result = sut.Evaluate(setup);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(GameChoice.Rock, GameChoice.Paper)]
        [InlineData(GameChoice.Rock, GameChoice.Scissors)]
        [InlineData(GameChoice.Paper, GameChoice.Rock)]
        [InlineData(GameChoice.Paper, GameChoice.Scissors)]
        [InlineData(GameChoice.Scissors, GameChoice.Rock)]
        [InlineData(GameChoice.Scissors, GameChoice.Paper)]
        public void Evaluate_different_choice_should_not_return_Draw(GameChoice player1Choice, GameChoice player2Choice)
        {
            // Arrange
            var setup = new GameSetup()
            {
                Player1Choice = player1Choice,
                Player2Choice = player2Choice
            };
            var wrongResult = GameResult.Draw;
            var sut = new SimpleGameReferee();

            GameResult? result;

            // Act
            try
            {
                result = sut.Evaluate(setup);
            }
            catch
            {
                // I am not worry about it in this test
                result = null;
            }

            // Assert
            Assert.NotEqual(wrongResult, result);
        }

        [Theory]
        [InlineData(GameChoice.Rock, GameChoice.Scissors)]
        [InlineData(GameChoice.Paper, GameChoice.Rock)]
        [InlineData(GameChoice.Scissors, GameChoice.Paper)]
        public void Evaluate_some_pairs_should_return_Player1Won(GameChoice player1Choice, GameChoice player2Choice)
        {
            // Arrange
            var setup = new GameSetup()
            {
                Player1Choice = player1Choice,
                Player2Choice = player2Choice
            };
            var expectedResult = GameResult.Player1Won;
            var sut = new SimpleGameReferee();

            // Act
            var result = sut.Evaluate(setup);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(GameChoice.Scissors, GameChoice.Rock)]
        [InlineData(GameChoice.Rock, GameChoice.Paper)]
        [InlineData(GameChoice.Paper, GameChoice.Scissors)]
        public void Evaluate_some_pairs_should_return_Player2Won(GameChoice player1Choice, GameChoice player2Choice)
        {
            // Arrange
            var setup = new GameSetup()
            {
                Player1Choice = player1Choice,
                Player2Choice = player2Choice
            };
            var expectedResult = GameResult.Player2Won;
            var sut = new SimpleGameReferee();

            // Act
            var result = sut.Evaluate(setup);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
