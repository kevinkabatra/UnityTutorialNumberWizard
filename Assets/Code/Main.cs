// ReSharper disable UnusedMember.Global, Start and Update are called by the Unity Engine, attached to Scene.Main.
namespace Assets.Code
{
    using System;
    using Handlers.Display;
    using Handlers.Input;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using NumberWizardBusinessLogic.Handlers.SearchEngines;
    using States;
    using UnityEngine;

    /// <summary>
    ///     Entry point to the application.
    /// </summary>
    /// <remarks>
    ///     This class follows the Mediator design pattern. All
    /// communication between the various components originates
    /// within this class.
    /// </remarks>
    /// <seealso href="https://refactoring.guru/design-patterns/mediator"/>
    public class Main : MonoBehaviour
    {
        private int _maximumNumber = 1000;
        private int _minimumNumber;
        private int _guess;

        private BinarySearchEngine _searchEngine;

        private DisplayHandler _displayHandler;
        private GuessHandler _guessHandler;
        private InputHandler _inputHandler;

        private GameState _gameState;

        /// <summary>
        ///     Start is called before the first frame update.
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Start()
        {
            Initialize();
            DisplayStartMessage();
        }

        /// <summary>
        ///     Update is called once per frame. 
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Update()
        {
            HandleUserInput();
        }

        /// <summary>
        ///     Uses the Guess Handler to attempt the next guess.
        /// </summary>
        private void AttemptGuess()
        {
            _gameState = GameState.Guess;
            _guess = _guessHandler.HandleGuess(_minimumNumber, _maximumNumber);
        }

        /// <summary>
        ///     Displays the start message to the user.
        /// </summary>
        private void DisplayStartMessage()
        {
            var startMessage = $"Pick a number between {_minimumNumber} and {_maximumNumber}. Press the space bar when ready to continue...";
            Debug.Log(startMessage);
        }

        /// <summary>
        ///     Handler for all keyboard input, actions taken depend on the Game State.
        /// </summary>
        private void HandleUserInput()
        {
            var input = _inputHandler.Listen();

            // ReSharper disable once SwitchStatementMissingSomeCases, most inputs are not supported.
            switch (input)
            {
                case KeyCode.Space:
                    if (_gameState == GameState.Start)
                    {
                        AttemptGuess();
                    }
                    break;
                    
                case KeyCode.None:
                    break;

                case KeyCode.N:
                    if (_gameState == GameState.Guess)
                    {
                        _gameState = GameState.IterateGuess;
                        _guessHandler.DisplayGuessIterationInstructions();
                    }
                    break;

                case KeyCode.Y:
                    if (_gameState == GameState.Guess)
                    {
                        const string endGameMessage = "Thank you for playing! - Kevin Kabatra";
                        Debug.Log(endGameMessage);

                        _gameState = GameState.GameOver;
                    }
                    break;

                case KeyCode.DownArrow:
                    if (_gameState == GameState.IterateGuess)
                    {
                        _maximumNumber = _guess - 1;
                        AttemptGuess();
                    }
                    break;

                case KeyCode.UpArrow:
                    if (_gameState == GameState.IterateGuess)
                    {
                        _minimumNumber = _guess + 1;
                        AttemptGuess();
                    }
                    break;

                default:
                    var errorMessage = $"KeyCode: {input} is not supported.";
                    throw new NotSupportedException(errorMessage);
            }
        }

        /// <summary>
        ///     Initializes all of the components.
        /// </summary>
        private void Initialize()
        {
            _displayHandler = new DisplayHandler();
            _searchEngine = new BinarySearchEngine(_minimumNumber, _maximumNumber);

            _guessHandler = new GuessHandler(_searchEngine, _displayHandler);
            _inputHandler = new InputHandler();

            _gameState = GameState.Start;
        }
    }
}
