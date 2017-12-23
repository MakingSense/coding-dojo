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
    }
}
