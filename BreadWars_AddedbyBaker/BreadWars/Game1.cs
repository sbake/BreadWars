﻿using Microsoft.Xna.Framework;
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

        //Deck
        Deck deck;

        //Round
        Round round;

        //temp array holding both players(may be moved in the future)
        Player[] players;
        Card[] cardsInPlay = new Card[2];

        //124 to 768
        Rectangle[] cardPos = { new Rectangle(0,0, 20, 20), new Rectangle(0,0, 20, 20), new Rectangle(0,0, 20, 20), new Rectangle(0,0 ,20, 20) };

        //phase and game states
        enum GameState { Start, Help, Game, Credits, GameOver};
        private GameState state;
        enum Phase { Player1, Player2, Pause, Results };
        private Phase currPhase;
        private Phase prevPhase;
        private KeyboardState kState;
        private KeyboardState kStatePrev;

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
            prevPhase = Phase.Results;
            currPhase = Phase.Pause;

            //deck = new Deck();
            round = new Round(20, deck);
            kState = Keyboard.GetState();
            kStatePrev = Keyboard.GetState();
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
            kStatePrev = kState;
            kState = Keyboard.GetState();
            
            MouseState mState = Mouse.GetState();

            switch (state)
            {
                case GameState.Start:
                    if (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))
                    {
                        NewGame();
                        state = GameState.Game;
                        
                    }if(mState.Position == new Point(0,0)) //change pos, for credits
                    {
                        state = GameState.Credits;
                    }
                    if (mState.Position == new Point(0, 0)) //change pos for help
                    {
                        state = GameState.Help; 
                    }
                    break;
                case GameState.Help:
                    if (kState.IsKeyDown(Keys.Back))
                    {
                        state = GameState.Start;
                    }
                    break;
                case GameState.Credits:
                    if (kState.IsKeyDown(Keys.Back))
                    {
                        state = GameState.Start;
                    }
                    break;
                case GameState.GameOver:
                    if (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))
                    {
                        state = GameState.Start;
                    }
                    break;
                case GameState.Game:
                    switch (currPhase)
                    {
                        case Phase.Player1:
                            for (int i = 0; i < player1.Hand.Count; i++)
                            {
                                if (cardPos[i].Contains(mState.Position))
                                {
                                    cardsInPlay[0] = player1.Hand[i];
                                    prevPhase = currPhase;
                                    currPhase = Phase.Pause;
                                    break;
                                }
                            }
                            break;
                        case Phase.Player2:
                            for (int i = 0; i < player2.Hand.Count; i++)
                            {
                                if (cardPos[i].Contains(mState.Position))
                                {
                                    cardsInPlay[0] = player2.Hand[i];
                                    prevPhase = currPhase;
                                    currPhase = Phase.Pause;
                                    break;
                                }
                            }
                            break;
                        case Phase.Pause:
                            if (!(kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))) break;
                            switch (prevPhase)
                            {
                                case Phase.Player1:
                                    prevPhase = currPhase;
                                    currPhase = Phase.Player2;
                                    break;
                                case Phase.Player2:
                                    prevPhase = currPhase;
                                    currPhase = Phase.Results;
                                    break;
                                case Phase.Results:
                                    prevPhase = currPhase;
                                    currPhase = Phase.Player1;
                                    break;
                            }
                            break;
                        case Phase.Results:
                            byte winPlayer = round.CompareCards(cardsInPlay);
                            round.EditHealth(winPlayer, players);
                            round.SpecialCards(cardsInPlay[0], 0, players);
                            round.SpecialCards(cardsInPlay[1], 1, players);
                            if (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))
                            {
                                prevPhase = currPhase;
                                currPhase = Phase.Pause;
                            }
                            break;
                    }
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

            //test code to get screen size
            //no font---  spriteBatch.DrawString(, "Viewport Width:" + GraphicsDevice.Viewport.Width, new Vector2(10,10), Color.Black);
            
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
                    switch (currPhase)
                    {
                        case Phase.Player1:
                            break;
                        case Phase.Player2:
                            break;
                        case Phase.Pause:
                            switch (prevPhase)
                            {
                                case Phase.Player1:
                                    break;
                                case Phase.Player2:
                                    break;
                                case Phase.Results:
                                    break;
                            }
                            break;
                        case Phase.Results:
                            break;
                    }
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


        public void NewGame()
        {
            //initialize player hands
            player1.Hand.Clear();
            player2.Hand.Clear();
            for(int i=0; i<5; i++)
            {
                player1.Hand.Add(deck.Next());
                player2.Hand.Add(deck.Next());
            }
            player1.ResetHealth();
            player2.ResetHealth();
            currPhase = Phase.Pause;
            prevPhase = Phase.Results;
        }
    }
}
