namespace NumberWizardBusinessLogicUnitTests.Handlers.Guessing
{
    using Moq;
    using NumberWizardBusinessLogic.Handlers.Display;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using NumberWizardBusinessLogic.Handlers.SearchEngines;
    using Xunit;

    /// <summary>
    ///     Exercises the Guess Handler.
    /// </summary>
    public class GuessHandlerUnitTests
    {
        [Fact]
        public void CanCreateGuessHandler()
        {
            var searchEngine = new Mock<ISearchEngine>().Object;
            var displayHandler = new Mock<IDisplayHandler>().Object;

            var handler = new GuessHandler(searchEngine, displayHandler);

            Assert.NotNull(handler);
        }

        [Fact]
        public void CanHandleGuessingWithMockSearchEngine()
        {
            const int minimumNumber = 0;
            const int maximumNumber = 1000;
            const int expectedGuess = 500;

            var searchEngine = new Mock<ISearchEngine>();
            searchEngine.SetupGet(mock => mock.Guess).Returns(500);
            var displayHandler = new Mock<IDisplayHandler>().Object;

            var handler = new GuessHandler(searchEngine.Object, displayHandler);
            var actualGuess = handler.HandleGuess(minimumNumber, maximumNumber);

            searchEngine.VerifyGet(mock => mock.Guess, Times.Once);
            Assert.Equal(expectedGuess, actualGuess);
        }

        [Fact]
        public void CanHandleGuessingWithBinarySearchEngine()
        {
            const int minimumNumber = 0;
            const int maximumNumber = 1000;
            const int expectedGuess = 500;

            var searchEngine = new BinarySearchEngine(minimumNumber, maximumNumber);
            var displayHandler = new Mock<IDisplayHandler>().Object;

            var handler = new GuessHandler(searchEngine, displayHandler);
            var actualGuess = handler.HandleGuess(minimumNumber, maximumNumber);

            Assert.Equal(expectedGuess, actualGuess);
        }

        [Fact]
        public void CanDisplayIterationInstructions()
        {
            var searchEngine = new Mock<ISearchEngine>().Object;
            var displayHandler = new Mock<IDisplayHandler>();
            displayHandler.Setup(mock => mock.DisplayMessage(It.IsAny<string>()));
            
            var handler = new GuessHandler(searchEngine, displayHandler.Object);
            handler.DisplayGuessIterationInstructions();

            displayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
