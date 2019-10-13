namespace Assets.Code.Handlers
{
    using UnityEngine;

    /// <summary>
    ///     Finds the key press and returns it to the mediator.
    /// </summary>
    public class InputHandler
    {
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

        private static bool Listener(KeyCode key)
        {
            var result = Input.GetKeyDown(key);
            return result;
        }

        private static bool ListenForDownArrow()
        {
            return Listener(KeyCode.DownArrow);
        }

        private static bool ListenForN()
        {
            return Listener(KeyCode.N);
        }

        private static bool ListenForSpaceBar()
        {
            return Listener(KeyCode.Space);
        }

        private static bool ListenForUpArrow()
        {
            return Listener(KeyCode.UpArrow);
        }

        private static bool ListenForY()
        {
            return Listener(KeyCode.Y);
        }
    }
}
