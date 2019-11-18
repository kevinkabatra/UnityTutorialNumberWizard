namespace NumberWizardBusinessLogicUnitTests.Handlers.Scoring.ScoringSubSystems
{
    using System;
    using NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems;
    using Xunit;

    /// <summary>
    ///     Exercises Round Manager.
    /// </summary>
    public class RoundKeeperUnitTests
    {
        [Fact]
        public void CanMakeRoundManager()
        {
            const int numberOfRounds = 1;
            var manager = new RoundKeeper(numberOfRounds);

            Assert.NotNull(manager);
        }

        [Fact]
        public void CanMakeRoundManagerWithExpectedNumberOfRounds()
        {
            const int expectedNumberOfRounds = 1;
            var manager = new RoundKeeper(expectedNumberOfRounds);

            Assert.Equal(expectedNumberOfRounds, manager.MaximumRounds);
        }

        [Fact]
        public void CanIncreaseRound()
        {
            const int maxNumberOfRounds = 1;
            const int expectedRound = 1;

            var manager = new RoundKeeper(maxNumberOfRounds);
            var result = manager.NextRound();

            Assert.Equal(expectedRound, manager.Round);
            Assert.True(result);
        }

        [Fact]
        public void ExceptionThrownWhenNotSettingRoundsToZero()
        {
            const int numberOfRounds = 0;
            Exception exception = Assert.Throws<ArgumentException>(() => new RoundKeeper(numberOfRounds));

            //ToDo: remove hard coded label
            Assert.Equal("MaximumRounds must be supplied, and cannot be 0, when creating a RoundManager for the first time.", exception.Message);
        }

        [Fact]
        public void CannotIncreasePastMaxRounds()
        {
            const int maxNumberOfRounds = 1;
            const int expectedRound = 1;

            var manager = new RoundKeeper(maxNumberOfRounds);
            manager.NextRound();
            var result = manager.NextRound();

            Assert.Equal(expectedRound, manager.Round);
            Assert.False(result);
        }
    }
}
