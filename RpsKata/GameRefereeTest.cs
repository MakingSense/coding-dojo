using System;
using Xunit;

namespace RpsKata
{
    public class SimpleGameRefereeTest : GameRefereeTest<SimpleGameReferee>
    { }

    public class ExtensionRulesGameRefereeTest : GameRefereeTest<ExtensionRulesGameReferee>
    { }

    public class WinnerRulesGameRefereeTest : GameRefereeTest<ExtensionRulesGameReferee>
    { }

    public abstract class GameRefereeTest<TSut> : GameRefereeTest
        where TSut : IGameReferee, new()
    {
        protected override IGameReferee GetSut() => new TSut();
    }

    public abstract class GameRefereeTest
    {
        protected abstract IGameReferee GetSut();

        [Theory]
        [InlineData(GameChoice.Rock, GameChoice.Rock, GameResult.Draw)]
        [InlineData(GameChoice.Paper, GameChoice.Paper, GameResult.Draw)]
        [InlineData(GameChoice.Scissors, GameChoice.Scissors, GameResult.Draw)]
        [InlineData(GameChoice.Rock, GameChoice.Scissors, GameResult.Player1Won)]
        [InlineData(GameChoice.Paper, GameChoice.Rock, GameResult.Player1Won)]
        [InlineData(GameChoice.Scissors, GameChoice.Paper, GameResult.Player1Won)]
        [InlineData(GameChoice.Scissors, GameChoice.Rock, GameResult.Player2Won)]
        [InlineData(GameChoice.Rock, GameChoice.Paper, GameResult.Player2Won)]
        [InlineData(GameChoice.Paper, GameChoice.Scissors, GameResult.Player2Won)]
        public void Evaluate_all_combinations_should_return_the_expected_result(GameChoice player1Choice, GameChoice player2Choice, GameResult expectedResult)
        {
            // Arrange
            var setup = new GameSetup()
            {
                Player1Choice = player1Choice,
                Player2Choice = player2Choice
            };
            var sut = GetSut();

            // Act
            var result = sut.Evaluate(setup);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
