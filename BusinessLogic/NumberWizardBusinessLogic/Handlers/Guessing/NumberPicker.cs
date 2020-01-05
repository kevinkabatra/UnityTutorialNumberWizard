namespace NumberWizardBusinessLogic.Handlers.Guessing
{
    using System;
    using Display;

    /// <summary>
    ///     Random number generator for the computer to pick a number
    /// that the user must guess.
    /// </summary>
    public class NumberPicker
    {
        private readonly int _number;
        private readonly IDisplayHandler _displayHandler;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="displayHandler">The handler that will display messages to the user.</param>
        /// <param name="maximumNumber">The maximum value that the computer can pick.</param>
        /// <param name="minimumNumber">The minimum value that the computer can pick.</param>
        public NumberPicker(IDisplayHandler displayHandler, int maximumNumber, int minimumNumber = 0)
        {
            _displayHandler = displayHandler;
            _number = GetRandomNumber(maximumNumber, minimumNumber);
        }

        /// <summary>
        ///     Generates a random number and returns it.
        /// </summary>
        /// <param name="maximumNumber">The maximum value that the computer can pick.</param>
        /// <param name="minimumNumber">The minimum value that the computer can pick.</param>
        /// <returns>Int. Representing the number that the computer will pick.</returns>
        private static int GetRandomNumber(int maximumNumber, int minimumNumber = 0)
        {
            var randomGenerator = new Random();
            var randomNumber = randomGenerator.Next(minimumNumber, maximumNumber);

            return randomNumber;
        }

        /// <summary>
        ///     Validates the user's guess against the value that the computer picked.
        /// </summary>
        /// <param name="numberToGuess">The number that the player believes the computer has picked.</param>
        /// <returns>Boolean. Representing if the user guess correctly or not.</returns>
        public bool GuessNumber(int numberToGuess)
        {
            _displayHandler.Debug($"Computer's guess is: {_number}");
            var success = numberToGuess == _number;
            
            //ToDo: set up Resource file for hard coded text
            var successMessage = success ? "correct!" : "incorrect.";
            var message = $"Your guess was {successMessage}";
            
            _displayHandler.DisplayInstructions(message);

            return success;
        }
    }
}
