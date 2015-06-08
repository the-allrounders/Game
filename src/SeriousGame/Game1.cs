using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SeriousGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ScreenManager.Game = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Dimensions.Y;
            Fullscreen = SettingsManager.Fullscreen;

            base.Initialize();
        }

        /// <summary>
        /// Sets the IsFullScreen property to the Game graphics.
        /// Only use SettingsManager.Fullscreen to make sure this is saved in the game!
        /// </summary>
        public bool Fullscreen
        {
            set
            {
                graphics.IsFullScreen = value;
                graphics.ApplyChanges();
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.Load(Content);
            FontManager.Load(Content);
            ScreenManager.CurrentScreen = new SplashScreen();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();
            ScreenManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(46, 37, 7));

            spriteBatch.Begin();
            ScreenManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
