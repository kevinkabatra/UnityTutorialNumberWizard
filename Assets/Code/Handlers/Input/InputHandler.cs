namespace Assets.Code.Handlers.Input
{
    using Display;
    using States;
    using UnityEngine;

    public class InputHandler
    {
        private DisplayHandler _displayHandler;
        private InputListener _inputListener;

        public InputHandler(DisplayHandler displayHandler, InputListener inputListener)
        {
            _displayHandler = displayHandler;
            _inputListener = inputListener;
        }

        /// <summary>
        ///     Handler for all keyboard input, actions taken depend on the Game State.
        /// </summary>
        public GameState HandleKeyboardInput(GameState gameState)
        {
            var input = _inputListener.Listen();

            // ReSharper disable once SwitchStatementMissingSomeCases, most inputs are not supported.
            if(input == KeyCode.Space && gameState == GameState.Start)
            {
                _displayHandler.ShowUserInterface();
                var updatedGameState = GameState.Guess;
                
                return updatedGameState;
            }

            return gameState;

            /*
            case KeyCode.N:
                if (gameState == GameState.Guess)
                {
                    gameState = GameState.IterateGuess;
                    _guessHandler.DisplayGuessIterationInstructions();
                }
                break;

            case KeyCode.Y:
                if (gameState == GameState.Guess)
                {
                    const string endGameMessage = "Thank you for playing! - Kevin Kabatra";
                    _displayHandler.DisplayMessage(endGameMessage);

                    gameState = GameState.GameOver;
                }
                break;

            case KeyCode.DownArrow:
                if (gameState == GameState.IterateGuess)
                {
                    _maximumNumber = _guess - 1;
                    AttemptGuess();
                }
                break;

            case KeyCode.UpArrow:
                if (gameState == GameState.IterateGuess)
                {
                    _minimumNumber = _guess + 1;
                    AttemptGuess();
                }
                break;
            */
        }
    }
}
