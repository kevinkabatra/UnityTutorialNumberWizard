namespace NumberWizardBusinessLogicUnitTests.Handlers.Scoring
{
    using NumberWizardBusinessLogic.Handlers.Scoring;
    using Xunit;

    public class MatchFacadeUnitTests
    {
        [Fact]
        public void CanMakeMatchFacade()
        {
            const int numberOfRounds = 1;
            var match = new MatchFacade(numberOfRounds);

            Assert.NotNull(match);
        }

        [Fact]
        public void CanMakeMatchFacadeWithExpectedValues()
        {
            const int expectedNumberOfRounds = 1;
            const int expectedScore = 0;
            const int numberOfRounds = 1;

            var match = new MatchFacade(numberOfRounds);

            Assert.Equal(expectedNumberOfRounds, match.MaximumRounds);
            Assert.Equal(expectedScore, match.ComputerScore);
            Assert.Equal(expectedScore, match.PlayerScore);
        }

        [Fact]
        public void CanIncreaseComputerScore()
        {
            const int expectedScore = 1;
            const int numberOfRounds = 1;

            var match = new MatchFacade(numberOfRounds);
            match.AddToComputerScore();

            Assert.Equal(expectedScore, match.ComputerScore);
        }

        [Fact]
        public void CanIncreasePlayerScore()
        {
            const int expectedScore = 1;
            const int numberOfRounds = 1;

            var match = new MatchFacade(numberOfRounds);
            match.AddToPlayerScore();

            Assert.Equal(expectedScore, match.PlayerScore);
        }

        [Fact]
        public void CanIncreaseRound()
        {
            const int expectedRound = 1;
            const int numberOfRounds = 1;

            var match = new MatchFacade(numberOfRounds);
            var result = match.NextRound();

            Assert.Equal(expectedRound, match.Round);
            Assert.True(result);
        }
    }
}
