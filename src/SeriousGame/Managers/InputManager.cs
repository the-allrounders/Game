using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SeriousGame.Managers
{
    /// <summary>
    /// Can be used troughout the game to check for user input.
    /// </summary>
    class InputManager
    {
        private static KeyboardState oldKeyboardState;
        private static KeyboardState keyboardState;

        private static MouseState oldMouseState;
        private static MouseState mouseState;

        /// <summary>
        /// Must be run at the beginning of every Update cycle, to get the new states.
        /// </summary>
        public static void Update()
        {
            // Setting all old states
            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;

            // Getting the new states
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        /// <summary>
        /// Checkes if the user is clicking the screen.
        /// </summary>
        /// <param name="on">The Rectangle that must be clicked</param>
        /// <param name="forTheFirstTime">If true, checks if the rectangle was clicked the previous Update cycle</param>
        public static bool IsClicking(Rectangle on = new Rectangle(), bool forTheFirstTime = true)
        {
            // Check if user is clicking the screen
            if (mouseState.LeftButton != ButtonState.Pressed)
            {
                return false;
            }

            // If onlyOnce is true, check if this is the first time the user is clicking the screen
            if (forTheFirstTime && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                return false;
            }

            // Convert the mouse position to a Rectangle, so it can be checked for intersection
            Rectangle mousePosition = new Rectangle(mouseState.Position.X, mouseState.Position.Y, 1, 1);

            // On fullscreen, fix the mouse position
            if (SettingsManager.Fullscreen)
            {
                mousePosition.X = (int)((float)mousePosition.X / (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * ScreenManager.Dimensions.X);
                mousePosition.Y = (int)((float)mousePosition.Y / (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * ScreenManager.Dimensions.Y);
            }

            // If a retangle is given to check for intersection, check
            if (on != new Rectangle() && !on.Intersects(mousePosition))
            {
                return false;
            }

            // If all checks passed, return true
            return true;
        }

        /// <summary>
        /// Checks if the user is pressing a button
        /// </summary>
        /// <param name="key">The key that must be pressed</param>
        /// <param name="onlyOnce">If true, checks if the button was pressed the previous Update cycle</param>
        public static bool IsPressing(Keys key, bool onlyOnce = true)
        {
            // Check if user is pressing the key
            if (!keyboardState.IsKeyDown(key))
            {
                return false;
            }

            // If onlyOnce is true, check if this is the first time the user is clicking this button
            if (onlyOnce && oldKeyboardState.IsKeyDown(key))
            {
                return false;
            }

            // If all checks passed, return true
            return true;
        }
    }
}
