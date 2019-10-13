// ReSharper disable UnusedMember.Global, Start and Update are called by the Unity Engine, attached to Scene.Main.
namespace Assets.Code
{
    using System;
    using Handlers;
    using States;
    using UnityEngine;

    public class Main : MonoBehaviour
    {
        private int _maximumNumber = 1000;
        private int _minimumNumber;
        private int _guess;

        private BinarySearchEngine _searchEngine;
        
        private GuessHandler _guessHandler;
        private InputHandler _inputHandler;

        private GameState _gameState;
        
        // Start is called before the first frame update
        public void Start()
        {
            Initialize();
            DisplayStartMessage();
        }

        // Update is called once per frame
        public void Update()
        {
            HandleUserInput();
        }

        private void AttemptGuess()
        {
            _gameState = GameState.Guess;
            _guess = _guessHandler.HandleGuess(_minimumNumber, _maximumNumber);
        }

        private void DisplayStartMessage()
        {
            var startMessage = $"Pick a number between {_minimumNumber} and {_maximumNumber}. Press the space bar when ready to continue...";
            Debug.Log(startMessage);
        }

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

        private void Initialize()
        {
            _searchEngine = new BinarySearchEngine(_minimumNumber, _maximumNumber);
            _guessHandler = new GuessHandler(_searchEngine);
            _inputHandler = new InputHandler();

            _gameState = GameState.Start;
        }
    }
}
