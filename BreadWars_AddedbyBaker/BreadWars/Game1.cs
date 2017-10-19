using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

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

        //Deck + numbers
        Deck deck;
        Drawable numbers;
        Texture2D[] cardText;

        //Round
        Round round;

        //temp array holding both players(may be moved in the future)
        Player[] players;
        Card[] cardsInPlay = new Card[2];

        //drawing cards
        static int cardDepth = 350;
        static int backCardDepth = 100;
        static int cardWidth = 50;
        static int cardHeight = 75;
        Rectangle[] cardPos = { new Rectangle(100, cardDepth, cardWidth, cardHeight), new Rectangle(200, cardDepth, cardWidth, cardHeight), new Rectangle(300, cardDepth, cardWidth, cardHeight), new Rectangle(400, cardDepth, cardWidth, cardHeight), new Rectangle(500, cardDepth, cardWidth, cardHeight) };
        Rectangle[] backCardPos = { new Rectangle(100, backCardDepth, cardWidth, cardHeight), new Rectangle(200, backCardDepth, cardWidth, cardHeight), new Rectangle(300, backCardDepth, cardWidth, cardHeight), new Rectangle(400, backCardDepth, cardWidth, cardHeight), new Rectangle(500, backCardDepth, cardWidth, cardHeight) };
        List<string> deckFiles; //lists filenames for all decks

        //hudobject things
        HUDObjects background;
        HUDObjects introTest;
        HUDObjects backCard;
        Texture2D bGText;
        Texture2D testText;
        Texture2D backText;
        SpriteFont font;

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

            round = new Round(20, deck);
            kState = Keyboard.GetState();
            kStatePrev = Keyboard.GetState();
            IsMouseVisible = true;
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
            bGText = Content.Load<Texture2D>("green");
            background = new HUDObjects(bGText, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Width));
            testText = Content.Load<Texture2D>("introTest");
            introTest = new HUDObjects(testText, new Rectangle(0, 0, 400, 600));
            backText = Content.Load<Texture2D>("backCard");
            backCard = new HUDObjects(backText, new Rectangle(0, 0, 0, 0));

            //things with textures
            //cards- load all card textures into array here, rename card textures to numbers -card0, card1, card2... cardn
            cardText = new Texture2D[21];
            for (int i = 0; i < 21; i++)
            {
                cardText[i] = Content.Load<Texture2D>("Card");
            }
            //numbers and deck
            numbers = new Drawable(Content.Load<Texture2D>("testnumbers14020"), new Rectangle(0, 0, 140, 20));
            numbers.Rows = 1;
            numbers.Columns = 10;
            numbers.UnpackSprites();
            deck = new Deck(cardText, numbers);

            font = Content.Load<SpriteFont>("Arial");

            string[] allFiles = Directory.GetFiles(".");
            foreach(string f in allFiles)
            {
                if (f.Contains(".dat")) deckFiles.Add(f);
            }
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
                    if (kState.IsKeyDown(Keys.NumPad0))
                    {
                        NewGame(deckFiles[0]);
                        state = GameState.Game;
                    }
                    else if (kState.IsKeyDown(Keys.NumPad1)){
                        NewGame(deckFiles[1]);
                        state = GameState.Game;
                    }
                    else if (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))
                    {
                        NewGame("1.dat");
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
                                //assigning card positions
                                player1.Hand[i].Posit = cardPos[i];

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
                                //assigning card positions
                                player2.Hand[i].Posit = cardPos[i];

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

            background.DrawStatic(spriteBatch);
            
            switch (state)
            {
                case GameState.Start:
                    introTest.DrawStatic(spriteBatch);
                    for(int i=0; i< deckFiles.Count; i++)
                    {
                        spriteBatch.DrawString(font, "press "+ i+ "for " + deckFiles[i], new Vector2(10, 20*i), Color.Black);
                    }

                    //figuring out spritesheet problems
                    for (int i = 0; i < numbers.SpriteLocations.Count; i++)
                    {
                        numbers.DrawStatic(spriteBatch);
                    }
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
                            //draw all cards in a loop
                            for (int i = 0; i <player1.Hand.Count; i++)
                            {
                                player1.Hand[i].DrawStatic(spriteBatch);
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                backCard.Posit = backCardPos[i];
                                backCard.DrawStatic(spriteBatch);
                            }
                            break;
                        case Phase.Player2:
                            //draw all cards in a loop
                            for (int i = 0; i < player2.Hand.Count; i++)
                            {
                                player2.Hand[i].DrawStatic(spriteBatch);
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                backCard.Posit = backCardPos[i];
                                backCard.DrawStatic(spriteBatch);
                            }
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


        public void NewGame(string deckName)
        {
            deck.LoadDeck(deckName);
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
