namespace Assets.Code.Buttons
{
    using Handlers.Display;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using UnityEngine;
    using UnityEngine.UI;

    public class AttemptGuess
    {
        private DisplayHandler _displayHandler;
        private NumberPicker _computerChosenNumber;

        public AttemptGuess(DisplayHandler displayHandler, NumberPicker computerChosenNumber)
        {
            _displayHandler = displayHandler;
            _computerChosenNumber = computerChosenNumber;
        }

        public void SetOnClickForAttemptGuess()
        {
            var attemptGuessButton = GameObject.Find("AttemptGuess").GetComponent<Button>();
            attemptGuessButton.onClick.AddListener(UserAttemptsGuess);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UserAttemptsGuess()
        {
            var userGuess = _displayHandler.GetUserGuess();
            var userGuessResult = _computerChosenNumber.GuessNumber(userGuess);

            _displayHandler.Debug($"User Guess: {userGuess}"); //ToDo: remove later on
            _displayHandler.Debug($"User Guess Result: {userGuessResult}"); //ToDo: remove later on

            if (userGuessResult)
            {
                //ToDo: will need to do something janky here to make this work. Perhaps get the game object that displays the score and then increment that, treat the UI as if it is the source of truth.
                //_match.AddToPlayerScore();
            }
        }
    }
}
