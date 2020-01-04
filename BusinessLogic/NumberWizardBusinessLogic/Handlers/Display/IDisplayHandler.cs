namespace NumberWizardBusinessLogic.Handlers.Display
{
    using System.Collections.Generic;
    /// <summary>
    ///     Interface for displays.
    /// </summary>
    public interface IDisplayHandler
    {
        List<string> Instructions { get; }

        /// <summary>
        ///     Appends additional information to the Instructions.
        /// </summary>
        /// <param name="message"></param>
        void AppendInstructions(string message);

        /// <summary>
        ///     Clears out all of the current infomration stored in the Instructions.
        /// </summary>
        void ClearInstructions();

        /// <summary>
        ///     Writes messages to the console.
        /// </summary>
        /// <param name="message"></param>
        /// <remarks>
        ///     ToDo: remove once the coding is complete for the project.
        /// </remarks>
        void Debug(string message);

        /// <summary>
        ///     Displays the computer guess to the user.
        /// </summary>
        /// <param name="message"></param>
        void DisplayComputerGuess(string message);

        /// <summary>
        ///     If no message was passed, displays the current Instructions to the user.
        /// Else display the contents of the new message.
        /// </summary>
        void DisplayInstructions(string message = null);
        
        [System.Obsolete("This method is deprecated, please use AppendInstructions and|or DisplayInstructions instead.")]
        void DisplayMessage(string message);
    }
}
