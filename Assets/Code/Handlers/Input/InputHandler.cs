namespace Assets.Code.Handlers.Input
{
    using UnityEngine;

    /// <summary>
    ///     Finds the key press and returns it to the mediator.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        ///     Listens for any of the currently supported key codes.
        /// </summary>
        /// <returns>KeyCode. Returns the supported key that was pressed.</returns>
        public KeyCode Listen()
        {
            if (ListenForDownArrow())
            {
                return KeyCode.DownArrow;
            }

            if (ListenForN())
            {
                return KeyCode.N;
            }

            if (ListenForSpaceBar())
            {
                return KeyCode.Space;
            }

            if (ListenForUpArrow())
            {
                return KeyCode.UpArrow;
            }

            if (ListenForY())
            {
                return KeyCode.Y;
            }

            return KeyCode.None;
        }

        /// <summary>
        ///     Handles the actual listening.
        /// </summary>
        /// <param name="key">The Key Code that should be listened for.</param>
        /// <returns>Boolean. If the listener found its key press.</returns>
        private static bool Listener(KeyCode key)
        {
            var result = Input.GetKeyDown(key);
            return result;
        }

        /// <summary>
        ///     Listens for Down Arrow key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForDownArrow()
        {
            return Listener(KeyCode.DownArrow);
        }

        /// <summary>
        ///     Listens for N key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForN()
        {
            return Listener(KeyCode.N);
        }

        /// <summary>
        ///     Listens for Space Bar key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForSpaceBar()
        {
            return Listener(KeyCode.Space);
        }

        /// <summary>
        ///     Listens for Up Arrow key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForUpArrow()
        {
            return Listener(KeyCode.UpArrow);
        }

        /// <summary>
        ///     Listens for Y key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForY()
        {
            return Listener(KeyCode.Y);
        }
    }
}
