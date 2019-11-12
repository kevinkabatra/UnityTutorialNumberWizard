namespace NumberWizardBusinessLogicUnitTests.Handlers.Scoring.ScoringSubSystems
{
    using System;
    using NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems;
    using Xunit;

    /// <summary>
    ///     Exercises Round Manager.
    /// </summary>
    public class RoundManagerUnitTests : IDisposable
    {
        /// <summary>
        ///     Need to reset the singleton after each test.
        /// </summary>
        public void Dispose()
        {
            RoundManager.Reset();
        }

        [Fact]
        public void CanMakeRoundManager()
        {
            const int numberOfRounds = 1;
            var manager = RoundManager.GetRoundManager(numberOfRounds);

            Assert.NotNull(manager);
        }

        [Fact]
        public void CanMakeRoundManagerWithExpectedNumberOfRounds()
        {
            const int expectedNumberOfRounds = 1;
            var manager = RoundManager.GetRoundManager(expectedNumberOfRounds);

            Assert.Equal(expectedNumberOfRounds, manager.MaxRounds);
        }

        [Fact]
        public void CanIncreaseRound()
        {
            const int maxNumberOfRounds = 1;
            const int expectedRound = 1;

            var manager = RoundManager.GetRoundManager(maxNumberOfRounds);
            var result = manager.NextRound();

            Assert.Equal(expectedRound, manager.Round);
            Assert.True(result);
        }

        [Fact]
        public void ExceptionThrownWhenNotSettingRounds()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => RoundManager.GetRoundManager());

            //ToDo: remove hard coded label
            Assert.Equal("MaxRounds must be supplied, and cannot be 0, when creating a RoundManager for the first time.", exception.Message);
        }

        [Fact]
        public void CannotIncreasePastMaxRounds()
        {
            const int maxNumberOfRounds = 1;
            const int expectedRound = 1;

            var manager = RoundManager.GetRoundManager(maxNumberOfRounds);
            manager.NextRound();
            var result = manager.NextRound();

            Assert.Equal(expectedRound, manager.Round);
            Assert.False(result);
        }
    }
}
