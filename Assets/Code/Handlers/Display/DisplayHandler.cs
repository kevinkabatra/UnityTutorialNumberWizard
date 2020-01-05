namespace Assets.Code.Handlers.Display
{
    using NumberWizardBusinessLogic.Handlers.Display;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    ///     Implementation of the Display Handler interface.
    /// </summary>
    public class DisplayHandler : IDisplayHandler
    {
        private UserInterfaceView _userInterface;

        public DisplayHandler()
        {
            _userInterface = GetUserInterfaceView();
        }

        public List<string> Instructions { get; private set; }

        public void AppendInstructions(string message)
        {
            Instructions.Add(message);
        }

        public void ClearInstructions()
        {
            Instructions.Clear();
        }

        public void Debug(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        public void DisplayComputerGuess(string message)
        {
            _userInterface.ComputerGuess.text = message;
        }

        public void DisplayInstructions(string message = null)
        {
            _userInterface.Instructions.text = (string.IsNullOrWhiteSpace(message)) ? Instructions.ToString() : message;
        }

        /// <summary>
        ///     Displays the start message to the user.
        /// </summary>
        public void DisplayStartMessage(int minimumNumber, int maximumNumber, int maximumRounds)
        {
            //ToDo: fix hard coded label.
            //ToDo: add instructions for scoring mechanic, should there be a max score? Most likely. Or best 3 out of 5, would be less awful to play.

            var startMessage = $"I am going to pick a number between {minimumNumber} and {maximumNumber}, you must do the same. We will have {maximumRounds} rounds to guess the each others number. Press the space bar when ready to continue...";
            DisplayInstructions(startMessage);
            Debug(startMessage);
        }

        /// <summary>
        ///     Displays a message to the user.
        /// </summary>
        /// <param name="message">Message to display.</param>
        [System.Obsolete("This method is deprecated, please use AppendInstructions and|or DisplayInstructions instead.")]
        public void DisplayMessage(string message)
        {
            Debug(message);
        }

        /// <summary>
        ///     Gets the User Interface View from the application.
        /// </summary>
        /// <returns>
        ///     UserInterfaceView, representing the user interface.
        /// </returns>
        private static UserInterfaceView GetUserInterfaceView()
        {
            var userInterfaceViewGameObject = GameObject.Find("UserInterfaceView");
            var userInterfaceViewScript = userInterfaceViewGameObject.GetComponent<UserInterfaceView>();

            return userInterfaceViewScript;
        }

        /// <summary>
        ///     Hides the user interface elements to prevent guessing.
        /// </summary>
        public void HideUserInterface()
        {
            SetMainUserInterfaceVisibility(false);
            SetComputerGuessIsCorrectOrIncorrectGameObjectsVisibility(false);
            SetComputerGuessingShouldBeHigherOrLowerGameObjectsVisibility(false);
        }

        /// <summary>
        ///     Shows the user interface elements to enable guessing.
        /// </summary>
        public void ShowUserInterface()
        {
            SetMainUserInterfaceVisibility(true);
        }

        public void SetComputerGuessIsCorrectOrIncorrectGameObjectsVisibility(bool isVisible)
        {
            foreach (var gameObject in _userInterface.GetComputerGuessIsCorrectOrIncorrectGameObjects())
            {
                gameObject.SetActive(isVisible);
            }
        }

        public void SetComputerGuessingShouldBeHigherOrLowerGameObjectsVisibility(bool isVisible)
        {
            foreach (var gameObject in _userInterface.GetComputerGuessShouldBeHigherOrLowerGameObjects())
            {
                gameObject.SetActive(isVisible);
            }
        }

        private void SetComputerGuessingUserInterfaceGameObjectsVisibility(bool isVisible)
        {
            foreach (var gameObject in _userInterface.GetComputerGuessingUserInterfaceGameObjects())
            {
                gameObject.SetActive(isVisible);
            }
        }

        private void SetUserGuessingUserInterfaceGameObjectsVisibility(bool isVisible)
        {
            foreach (var gameObject in _userInterface.GetUserGuessingUserInterfaceGameObjects())
            {
                gameObject.SetActive(isVisible);
            }
        }

        private void SetMainUserInterfaceVisibility(bool isVisible)
        {
            SetComputerGuessingUserInterfaceGameObjectsVisibility(isVisible);
            SetUserGuessingUserInterfaceGameObjectsVisibility(isVisible);
        }

        public int GetUserGuess()
        {
            var userGuessInputField = _userInterface.UserGuess.GetComponent<InputField>();
            var userGuess = int.Parse(userGuessInputField.text);

            return userGuess;
        }
    }
}
