namespace NumberWizardBusinessLogicUnitTests.Handlers.Guessing
{
    using Moq;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using NumberWizardBusinessLogic.Handlers.Display;
    using Xunit;

    /// <summary>
    ///     Exercises the Number Picker
    /// </summary>
    public class NumberPickerUnitTests
    {
        [Fact]
        public void CanCreateNumberPicker()
        {
            var displayHandler = new Mock<IDisplayHandler>().Object;
            var numberPicker = new NumberPicker(displayHandler, 0,0);
            
            Assert.NotNull(numberPicker);
        }

        [Fact]
        public void CanCreateNumberPickerWithExpectedNumber()
        {
            var displayHandler = new Mock<IDisplayHandler>().Object;
            const int expectedNumber = 42;
            var numberPicker = new NumberPicker(displayHandler, expectedNumber, expectedNumber);

            var canGuessExpectedNumber = numberPicker.GuessNumber(expectedNumber);

            Assert.True(canGuessExpectedNumber);
        }

        [Fact]
        public void CanDisplayMessageToUserAfterGuess()
        {
            var displayHandler = new Mock<IDisplayHandler>();
            displayHandler.Setup(mock => mock.DisplayMessage(It.IsAny<string>()));
            const int expectedNumber = 0;
            
            var numberPicker = new NumberPicker(displayHandler.Object, expectedNumber);
            numberPicker.GuessNumber(expectedNumber);

            displayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
