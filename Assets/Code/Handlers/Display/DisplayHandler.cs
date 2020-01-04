namespace Assets.Code.Handlers.Display
{
    using NumberWizardBusinessLogic.Handlers.Display;
    using System.Collections.Generic;
    using UnityEngine;

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
    }
}
