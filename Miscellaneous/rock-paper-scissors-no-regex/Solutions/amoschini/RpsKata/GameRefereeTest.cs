using System;
using Xunit;

namespace RpsKata
{
    public class SimpleGameRefereeTest : GameRefereeTest<SimpleGameReferee>
    { }

    public class ExtensionRulesGameRefereeTest : GameRefereeTest<ExtensionRulesGameReferee>
    { }

    public class WinnerRulesGameRefereeTest : GameRefereeTest<WinnerRulesGameReferee>
    { }

    public class OopAdapterRulesGameRefereeTest : GameRefereeTest<OopAdapterRulesGameReferee>
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
        [InlineData(GameChoice.Rock, GameChoice.Rock, false, false, true, "Both players chose Rock")]
        [InlineData(GameChoice.Paper, GameChoice.Paper, false, false, true, "Both players chose Paper")]
        [InlineData(GameChoice.Scissors, GameChoice.Scissors, false, false, true, "Both players chose Scissors")]
        [InlineData(GameChoice.Spock, GameChoice.Spock, false, false, true, "Both players chose Spock")]
        [InlineData(GameChoice.Lizard, GameChoice.Lizard, false, false, true, "Both players chose Lizard")]

        [InlineData(GameChoice.Rock, GameChoice.Scissors, true, false, false, "Rock crushes Scissors")]
        [InlineData(GameChoice.Rock, GameChoice.Lizard, true, false, false, "Rock crushes Lizard")]
        [InlineData(GameChoice.Paper, GameChoice.Rock, true, false, false, "Paper covers Rock")]
        [InlineData(GameChoice.Paper, GameChoice.Spock, true, false, false, "Paper disproves Spock")]
        [InlineData(GameChoice.Scissors, GameChoice.Paper, true, false, false, "Scissors cuts Paper")]
        [InlineData(GameChoice.Scissors, GameChoice.Lizard, true, false, false, "Scissors decapitates Lizard")]
        [InlineData(GameChoice.Spock, GameChoice.Scissors, true, false, false, "Spock smashes Scissors")]
        [InlineData(GameChoice.Spock, GameChoice.Rock, true, false, false, "Spock vaporizes Rock")]
        [InlineData(GameChoice.Lizard, GameChoice.Spock, true, false, false, "Lizard poisons Spock")]
        [InlineData(GameChoice.Lizard, GameChoice.Paper, true, false, false, "Lizard eats Paper")]

        [InlineData(GameChoice.Scissors, GameChoice.Rock, false, true, false, "Rock crushes Scissors")]
        [InlineData(GameChoice.Scissors, GameChoice.Spock, false, true, false, "Spock smashes Scissors")]
        [InlineData(GameChoice.Rock, GameChoice.Paper, false, true, false, "Paper covers Rock")]
        [InlineData(GameChoice.Rock, GameChoice.Spock, false, true, false, "Spock vaporizes Rock")]
        [InlineData(GameChoice.Paper, GameChoice.Scissors, false, true, false, "Scissors cuts Paper")]
        [InlineData(GameChoice.Paper, GameChoice.Lizard, false, true, false, "Lizard eats Paper")]
        [InlineData(GameChoice.Spock, GameChoice.Paper, false, true, false, "Paper disproves Spock")]
        [InlineData(GameChoice.Spock, GameChoice.Lizard, false, true, false, "Lizard poisons Spock")]
        [InlineData(GameChoice.Lizard, GameChoice.Rock, false, true, false, "Rock crushes Lizard")]
        [InlineData(GameChoice.Lizard, GameChoice.Scissors, false, true, false, "Scissors decapitates Lizard")]
        public void Evaluate_all_combinations_should_return_the_expected_result(
            GameChoice player1Choice, 
            GameChoice player2Choice, 
            bool player1Won, 
            bool player2Won, 
            bool draw,
            string explanation)
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
            Assert.Equal(player1Won, result.TheWinnerIsPlayer1);
            Assert.Equal(player2Won, result.TheWinnerIsPlayer2);
            Assert.Equal(draw, result.ItIsADraw);
            Assert.Equal(explanation, result.Explanation);
        }
    }
}
