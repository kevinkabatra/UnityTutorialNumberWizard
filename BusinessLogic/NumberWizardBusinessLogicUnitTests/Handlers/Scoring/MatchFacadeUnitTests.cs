namespace NumberWizardBusinessLogicUnitTests.Handlers.Scoring
{
    using System;
    using NumberWizardBusinessLogic.Handlers.Scoring;
    using Xunit;

    public class MatchFacadeUnitTests : IDisposable
    {
        private MatchFacade _match;

        public MatchFacadeUnitTests()
        {
            MatchFacade.Reset();

            const int numberOfRounds = 1;
            _match = MatchFacade.GetMatchFacade(numberOfRounds);
        }

        /// <summary>
        ///     Need to reset the singleton after each test.
        /// </summary>
        public void Dispose()
        {
            MatchFacade.Reset();
        }

        [Fact]
        public void CanMakeMatchFacade()
        {
            Assert.NotNull(_match);
        }

        [Fact]
        public void CanMakeMatchFacadeWithExpectedValues()
        {
            const int expectedNumberOfRounds = 1;
            const int expectedScore = 0;
            
            Assert.Equal(expectedNumberOfRounds, _match.MaximumRounds);
            Assert.Equal(expectedScore, _match.ComputerScore);
            Assert.Equal(expectedScore, _match.PlayerScore);
        }

        [Fact]
        public void CanIncreaseComputerScore()
        {
            const int expectedScore = 1;
            
            _match.AddToComputerScore();

            Assert.Equal(expectedScore, _match.ComputerScore);
        }

        [Fact]
        public void CanIncreasePlayerScore()
        {
            const int expectedScore = 1;
            
            _match.AddToPlayerScore();

            Assert.Equal(expectedScore, _match.PlayerScore);
        }

        [Fact]
        public void CanIncreaseRound()
        {
            const int expectedRound = 1;

            var result = _match.NextRound();

            Assert.Equal(expectedRound, _match.Round);
            Assert.True(result);
        }
    }
}
