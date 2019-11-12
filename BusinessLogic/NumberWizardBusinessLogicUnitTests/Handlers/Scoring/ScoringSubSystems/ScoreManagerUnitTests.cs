namespace NumberWizardBusinessLogicUnitTests.Handlers.Scoring.ScoringSubSystems
{
    using System;
    using NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems;
    using Xunit;

    /// <summary>
    ///     Exercises Score Manager.
    /// </summary>
    public class ScoreManagerUnitTests : IDisposable
    {
        /// <summary>
        ///     Need to reset the singleton after each test.
        /// </summary>
        public void Dispose()
        {
            ScoreManager.Reset();
        }

        [Fact]
        public void CanMakeScoreManager()
        {
            var score = ScoreManager.GetScoreManager();

            Assert.NotNull(score);
        }

        [Fact]
        public void CanMakeScoreManagerWithExpectedValues()
        {
            const int expectedScore = 0;

            var score = ScoreManager.GetScoreManager();

            Assert.Equal(expectedScore,score.ComputerScore);
            Assert.Equal(expectedScore, score.PlayerScore);
        }

        [Fact]
        public void CanIncreaseComputerScore()
        {
            const int expectedScore = 1;

            var score = ScoreManager.GetScoreManager();
            score.AddToComputerScore();
            
            Assert.Equal(expectedScore, score.ComputerScore);
        }

        [Fact]
        public void CanIncreasePlayerScore()
        {
            const int expectedScore = 1;

            var score = ScoreManager.GetScoreManager();
            score.AddToPlayerScore();

            Assert.Equal(expectedScore, score.PlayerScore);
        }
    }
}
