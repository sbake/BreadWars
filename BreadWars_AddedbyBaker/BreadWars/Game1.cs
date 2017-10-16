using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreadWars
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Attributes
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //The players
        Player player1;
        Player player2;

        //temp array holding both players(may be moved in the future)
        Player[] players;


        //phase and game states
        enum GameState { Start, Help, Game, Credits, GameOver};
        private GameState state;
        enum Phase { Player1, Player2, Pause, Results };
        private Phase phase;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            //The players
            player1 = new Player(1);
            player2 = new Player(2);

            //player array
            players = new Player[2];
            players[0] = player1;
            players[1] = player2;

            state = GameState.Start;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (state)
            {
                case GameState.Start:
                    break;
                case GameState.Help:
                    break;
                case GameState.Credits:
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Game:
                    break;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (state)
            {
                case GameState.Start:
                    break;
                case GameState.Help:
                    break;
                case GameState.Credits:
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Game:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
