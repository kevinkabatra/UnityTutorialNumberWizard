﻿// ReSharper disable UnusedMember.Global, Start and Update are called by the Unity Engine, attached to Scene.Main.
namespace Assets.Code
{
    using System;
    using Handlers.Display;
    using Handlers.Input;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using NumberWizardBusinessLogic.Handlers.Scoring;
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
        private const int MaximumRounds = 10;
        private int _maximumNumber = 1000;
        private int _minimumNumber;
        private int _guess;

        private BinarySearchEngine _searchEngine;

        private DisplayHandler _displayHandler;
        private GuessHandler _guessHandler;
        private InputHandler _inputHandler;

        private MatchFacade _match;

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
            //ToDo: Add UI text field: user input will need to come from a text field in the user interface
            //ToDo: MVP hard code user's guess: The user's guess can be hard coded to get the game logic working, then the UI can be layered on top of that.
            //ToDo: Add additional state: While we are waiting for the user's guess to come in the state should change to `WaitingForUserGuess`, this will disable the other inputs from being listened for
            //ToDo: Update State Machine: Once the user enters their guess the state will switch to the current GameState:Guess.
            //ToDo: Both guesses will be considered at the same time, so both the computer and the player could score on each turn.
            //ToDo: The computer and the player will tell one another if the guess was correct, too high, or too low.
            //ToDo: After the guesses are displayed the round should be updated
            //ToDo: Add conditional logic: if there are no more rounds then the "match" will have finished.
            //ToDo: Implement best out of three system. Could either use a state machine for this, or another class like RoundManager. Might make more sense given the design to have a MatchManager instead.

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
            //ToDo: fix hard coded label.
            //ToDo: add instructions for scoring mechanic, should there be a max score? Most likely. Or best 3 out of 5, would be less awful to play.

            var startMessage = $"I am going to pick a number between {_minimumNumber} and {_maximumNumber}, you must do the same. We will have {MaximumRounds} rounds to guess the each others number. Press the space bar when ready to continue...";
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

            _match = new MatchFacade(MaximumRounds);

            _gameState = GameState.Start;
        }
    }
}
