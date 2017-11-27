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
        byte winPlayer;

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
        static int cardDepth = 300;
        static int backCardDepth = 50;
        static int resultCardDepth = 135;
        static int cardWidth = 100;
        static int cardHeight = 150;
        Rectangle[] cardPos = { new Rectangle(80, cardDepth, cardWidth, cardHeight), new Rectangle(200, cardDepth, cardWidth, cardHeight), new Rectangle(320, cardDepth, cardWidth, cardHeight), new Rectangle(440, cardDepth, cardWidth, cardHeight), new Rectangle(560, cardDepth, cardWidth, cardHeight) };
        Rectangle[] backCardPos = { new Rectangle(80, backCardDepth, cardWidth, cardHeight), new Rectangle(200, backCardDepth, cardWidth, cardHeight), new Rectangle(320, backCardDepth, cardWidth, cardHeight), new Rectangle(440, backCardDepth, cardWidth, cardHeight), new Rectangle(560, backCardDepth, cardWidth, cardHeight) };
        Rectangle[] resultCardPos = { new Rectangle(260, resultCardDepth, cardWidth, cardHeight), new Rectangle(440, resultCardDepth, cardWidth, cardHeight) };
        List<string> deckFiles= new List<string>(); //lists filenames for all decks
        Rectangle[] deckButtonPos = { new Rectangle(80, 50, cardWidth, cardHeight), new Rectangle(200, 50, cardWidth, cardHeight), new Rectangle(320, 50, cardWidth, cardHeight), new Rectangle(80, 200, cardWidth, cardHeight), new Rectangle(200, 200, cardWidth, cardHeight), new Rectangle(320, 200, cardWidth, cardHeight) };
        Drawable[] deckButtons = new Drawable[6];
        Rectangle[] numPlayButtonPos = { new Rectangle(80, 450, cardWidth, cardHeight), new Rectangle(200, 450, cardWidth, cardHeight) };
        Drawable[] numPlayButtons = new Drawable[2];
        int currDeck = 0;

        //hudobject things
        HUDObjects background;
        HUDObjects introTest;
        HUDObjects backCard;
        HUDObjects pause1;
        HUDObjects pause2;
        HUDObjects pause;
        HUDObjects vs;
        HUDObjects player1wins;
        HUDObjects player2wins;
        HUDObjects tie1;
        HUDObjects tie2;
        HUDObjects help;
        HUDObjects credits;
        HUDObjects toaster1;
        HUDObjects toasterNib1;
        HUDObjects toaster2;
        HUDObjects toasterNib2;
        Texture2D bGText;
        Texture2D testText;
        Texture2D backText;
        Texture2D pause1Text;
        Texture2D pause2Text;
        Texture2D pauseText;
        Texture2D vsText;
        Texture2D win1Text;
        Texture2D win2Text;
        Texture2D tie1Text;
        Texture2D tie2Text;
        Texture2D helpSplash;
        Texture2D creditSplash;
        Texture2D toasterText;
        Texture2D nibText;
        Texture2D button;

        //tutorial
        HUDObjects tutorialStart;
        Texture2D tutStartText;
        HUDObjects downArrow;
        Texture2D downArrowText;
        //drawing arrows
        static int arrowDepth = 255;
        static int arrowWidth = 32;
        static int arrowHeight = 30;
        Rectangle[] arrowPos = { new Rectangle(80, arrowDepth, arrowWidth, arrowHeight), new Rectangle(200, arrowDepth, arrowWidth, arrowHeight), new Rectangle(320, arrowDepth, arrowWidth, arrowHeight), new Rectangle(440, arrowDepth, arrowWidth, arrowHeight), new Rectangle(560, arrowDepth, arrowWidth, arrowHeight) };
        int arrow = 0;
        //tutorial variables
        bool player1Tut;
        bool player2Tut;
        int play1TutRound;
        int play2TutRound;

        //health things
        //room from top to bottom for toaster nib to move
        const double tHDif = 99;
        //solved location, solved in update, used in draw
        int toastNib1Y;
        int toastNib2Y;


        SpriteFont font;

        //phase and game states
        enum GameState { Start, Help, Game, Credits, GameOver, PickDeck};
        private GameState state;
        enum Phase { Player1, Player2, Pause, Results };
        private Phase currPhase;
        private Phase prevPhase;
        private KeyboardState kState;
        private KeyboardState kStatePrev;
        private MouseState mState;
        private MouseState mStatePrev;
        private bool resultCalculated;

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

            //starting game and phase states
            state = GameState.Start;
            prevPhase = Phase.Results;
            currPhase = Phase.Pause;

            round = new Round(20, deck);
            kState = Keyboard.GetState();
            kStatePrev = Keyboard.GetState();
            IsMouseVisible = true;
            resultCalculated = false;
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
            //background images + full screen displays
            bGText = Content.Load<Texture2D>("bgCuteTemp");
            background = new HUDObjects(bGText, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            testText = Content.Load<Texture2D>("introscreenTemp");
            introTest = new HUDObjects(testText, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            helpSplash = Content.Load<Texture2D>("helpScreen");
            help = new HUDObjects(helpSplash, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            creditSplash = Content.Load<Texture2D>("CreditsScreen");
            credits = new HUDObjects(creditSplash, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            tie1Text = Content.Load<Texture2D>("tieGame1");
            tie2Text = Content.Load<Texture2D>("tieGame2");
            tie1 = new HUDObjects(tie1Text, new Rectangle(240, 290, 320, 60));
            tie2 = new HUDObjects(tie2Text, new Rectangle(240, 380, 320, 60));

            //deck& AI buttons
            button = Content.Load<Texture2D>("button");
            for (int i = 0; i < 6; i++) deckButtons[i] = new Drawable(button, deckButtonPos[i]);
            for (int i = 0; i < 2; i++) numPlayButtons[i] = new Drawable(button, numPlayButtonPos[i]);

            //full screen cont.- pause screens
            pause1Text = Content.Load<Texture2D>("pausephase1");
            pause1 = new HUDObjects(pause1Text, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            pause2Text = Content.Load<Texture2D>("pausephase2");
            pause2 = new HUDObjects(pause2Text, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            pauseText = Content.Load<Texture2D>("pausephaseBlank");
            pause = new HUDObjects(pauseText, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

            //results text
            win1Text = Content.Load<Texture2D>("player1wins");
            player1wins = new HUDObjects(win1Text, new Rectangle(240, 290, 320, 60));
            win2Text = Content.Load<Texture2D>("player2wins");
            player2wins = new HUDObjects(win2Text, new Rectangle(230, 290, 340, 60));
            vsText = Content.Load<Texture2D>("vs");
            vs = new HUDObjects(vsText, new Rectangle(365, 160, 70, 50));

            //Card backs 
            backText = Content.Load<Texture2D>("backCard");
            backCard = new HUDObjects(backText, new Rectangle(0, 0, 0, 0));

            //Health Assets
            nibText = Content.Load<Texture2D>("toasternib");
            toasterNib1 = new HUDObjects(nibText, new Rectangle(24, 0, 30, 15));
            toasterNib2 = new HUDObjects(nibText, new Rectangle(24, 0, 30, 15));
            toasterText = Content.Load<Texture2D>("toaster");
            toaster1 = new HUDObjects(toasterText, new Rectangle(0, 50, 60, 150));
            toaster2 = new HUDObjects(toasterText, new Rectangle(0, 300, 60, 150));


            font = Content.Load<SpriteFont>("Arial");

            //things with textures
            //cards- load all card textures into array here, rename card textures to numbers -card0, card1, card2... cardn
            cardText = new Texture2D[21];
            for (int i = 0; i < 21; i++)
            {
                cardText[i] = Content.Load<Texture2D>("cards/card"+ (i+1));
            }
            //numbers
            numbers = new Drawable(Content.Load<Texture2D>("numbers14020"), new Rectangle(0, 0, 140, 20));
            numbers.Rows = 1;
            numbers.Columns = 10;
            numbers.UnpackSprites();
            //Deck
            deck = new Deck(cardText, numbers);
            string[] allFiles = Directory.GetFiles("..\\..\\..\\..\\..\\..\\Bread Wars Deck Builder\\bin\\Debug");
            foreach(string f in allFiles)
            {
                if (f.Contains(".dat")) deckFiles.Add(f);
            }


            //The players
            player1 = new Player(1, font, new Vector2(20, 100));
            player2 = new Player(2, font, new Vector2(600, 100));

            //player array
            players = new Player[2];
            players[0] = player1;
            players[1] = player2;

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
            
            kStatePrev = kState;
            kState = Keyboard.GetState();
            mStatePrev = mState;
            mState = Mouse.GetState();
           
            
            switch (state)
            {
                case GameState.Start:
                    for(int i=0; i<2; i++)
                    {
                        if (numPlayButtonPos[i].Contains(mState.Position) && mState.LeftButton == ButtonState.Pressed &&mStatePrev.LeftButton == ButtonState.Released)
                        {
                            if (i == 0) player2.IsAI = true;
                            else player2.IsAI = false;
                            state = GameState.PickDeck;
                        }
                    }
                    
                        if (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))
                    {
                        player2.IsAI = true;
                        state = GameState.PickDeck;
                        
                    }
                    else if(kState.IsKeyDown(Keys.H)|| kState.IsKeyDown(Keys.F1))
                    {
                        state = GameState.Help;
                    }
                    else if(kState.IsKeyDown(Keys.C))
                    {
                        state = GameState.Credits;
                    }
                    if (mState.Position == new Point(0,0)) //change pos, for credits
                    {
                        state = GameState.Credits;
                    }
                    if (mState.Position == new Point(0, 0)) //change pos for help
                    {
                        state = GameState.Help; 
                    }
                    break;
                case GameState.PickDeck:

                    if (currDeck > (deckFiles.Count - 1)) currDeck = 0;
                    if (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter)) currDeck += 6;
                    for(int i=0; i<deckButtons.Length; i++)
                    {
                        if ((i+currDeck)< deckFiles.Count && deckButtonPos[i].Contains(mState.Position) && mState.LeftButton == ButtonState.Pressed)
                        {
                            NewGame(deckFiles[i+currDeck]);
                            state = GameState.Game;
                        }
                    }
                    break;
                case GameState.Help:
                    if (kState.IsKeyDown(Keys.Back)) //press back to return to start screen
                    {
                        state = GameState.Start;
                    }
                    break;
                case GameState.Credits:
                    if (kState.IsKeyDown(Keys.Back)) //press back to return to start screen
                    {
                        state = GameState.Start;
                    }
                    break;
                case GameState.GameOver:
                    if ((mStatePrev.LeftButton == ButtonState.Released && mState.LeftButton == ButtonState.Pressed) || (kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))) //press enter to go back to start screen
                    {
                        state = GameState.Start;
                    }
                    break;
                case GameState.Game:
                    switch (currPhase)
                    {
                        case Phase.Player1:
                            resultCalculated = false;
                            //toasterNib position
                            toastNib1Y = System.Convert.ToInt32(328 + ((tHDif / Player.PLAYER_MAX_HEALTH) * (100 - player1.Health)));
                            toastNib2Y = System.Convert.ToInt32(78 + ((tHDif / Player.PLAYER_MAX_HEALTH) * (100 - player2.Health)));
                            
                            for (int i = 0; i < player1.Hand.Count; i++)
                            {
                                if (player1.Hand[i] != null)
                                {
                                    //assigning card positions
                                    player1.Hand[i].Posit = cardPos[i];

                                    if (cardPos[i].Contains(mState.Position) && mStatePrev.LeftButton== ButtonState.Released && mState.LeftButton == ButtonState.Pressed)
                                    {
                                        cardsInPlay[0] = player1.Hand[i];
                                        player1.PlayTurn(cardsInPlay, i);
                                        player1.Hand.Add(deck.Next());
                                        prevPhase = currPhase;

                                        if (player2.IsAI)
                                        {
                                            cardsInPlay[1] = player2.Hand[1];
                                            player2.PlayTurn(cardsInPlay, 0);
                                            player2.Hand.Add(deck.Next());
                                            prevPhase = Phase.Player2;
                                            currPhase = Phase.Pause;
                                        }
                                        
                                        currPhase = Phase.Pause;
                                        break;
                                    }
                                }
                            }

                            
                            break;
                        case Phase.Player2:
                            //toaster nib position
                            toastNib1Y = System.Convert.ToInt32(78 + ((tHDif / Player.PLAYER_MAX_HEALTH) * (100 - player1.Health)));
                            toastNib2Y = System.Convert.ToInt32(328 + ((tHDif / Player.PLAYER_MAX_HEALTH) * ( 100 - player2.Health)));

                            for (int i = 0; i < player2.Hand.Count; i++)
                            {
                                if (player2.Hand[i] != null)
                                {
                                    //assigning card positions
                                    player2.Hand[i].Posit = cardPos[i];

                                    if (cardPos[i].Contains(mState.Position) && mStatePrev.LeftButton == ButtonState.Released && mState.LeftButton == ButtonState.Pressed)
                                    {
                                        cardsInPlay[1] = player2.Hand[i];
                                        player2.PlayTurn(cardsInPlay, i);
                                        player2.Hand.Add(deck.Next());
                                        prevPhase = currPhase;
                                        currPhase = Phase.Pause;
                                        break;
                                    }
                                }
                            }
                            break;
                        case Phase.Pause:
                            if(!(mState.LeftButton == ButtonState.Pressed && mStatePrev.LeftButton ==ButtonState.Released) && (!(kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter))) ) break;
                            //press enter to continue to next phase
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
                            //calculate victor of round and other effects
                            if (!resultCalculated)
                            {
                                winPlayer = round.CompareCards(cardsInPlay);
                                if (winPlayer != 0)
                                    round.EditHealth(winPlayer, players);
                                round.SpecialCards(cardsInPlay[0], 1, players);
                                round.SpecialCards(cardsInPlay[1], 2, players);
                                player1.Update(player2);
                                player2.Update(player1);
                                cardsInPlay[0].IsBurned = false;
                                cardsInPlay[1].IsBurned = false;
                                resultCalculated = true;
                            }
                            if ((mState.LeftButton ==ButtonState.Pressed && mStatePrev.LeftButton == ButtonState.Released) || kState.IsKeyDown(Keys.Enter) && kStatePrev.IsKeyUp(Keys.Enter)) //press enter to continue to next phase
                            {
                                if(player2.Health<=0 || player1.Health>Player.PLAYER_MAX_HEALTH )
                                {
                                    winPlayer = 1;
                                    state = GameState.GameOver;
                                }
                                else if (player1.Health <= 0 || player2.Health > Player.PLAYER_MAX_HEALTH)
                                {
                                    winPlayer = 2;
                                    state = GameState.GameOver;
                                }
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
            
            spriteBatch.Begin();

            //test code to get screen size
            //no font---  spriteBatch.DrawString(, "Viewport Width:" + GraphicsDevice.Viewport.Width, new Vector2(10,10), Color.Black);

            background.DrawStatic(spriteBatch);
            
            switch (state)
            {
                case GameState.Start:
                    introTest.DrawStatic(spriteBatch);
                    for(int i=0; i<2; i++)
                    {
                        numPlayButtons[i].DrawStatic(spriteBatch);
                        spriteBatch.DrawString(font, i == 0 ? "Single Player": "2 Players", new Vector2(numPlayButtonPos[i].X + 10, numPlayButtonPos[i].Y + 10), Color.Black);
                    }
                    //figuring out spritesheet problems
                    //for (int i = 0; i < numbers.SpriteLocations.Count; i++)
                    //{
                    //    numbers.DrawStatic(spriteBatch);
                    //}
                    break;
                case GameState.PickDeck:
                    spriteBatch.DrawString(font, "Choose a Deck (ENTER to view more):", new Vector2 (80, 10), Color.Black);
                    for(int i=0; i<6; i++)
                    {
                        if ((i + currDeck) < deckFiles.Count)
                        {
                            deckButtons[i].DrawStatic(spriteBatch);
                            spriteBatch.DrawString(font, deckFiles[i+ currDeck].Substring(52, deckFiles[i + currDeck].Length-56), new Vector2(deckButtonPos[i].X +10, deckButtonPos[i].Y+10), Color.Black );
                        }
                    }
                    break;
                case GameState.Help:
                    {
                        help.DrawStatic(spriteBatch);
                    }
                    break;
                case GameState.Credits:
                    {
                        credits.DrawStatic(spriteBatch);
                    }
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Game:
                    switch (currPhase)
                    {
                        case Phase.Player1:
                            //toaster
                            toasterNib1.Posit = new Rectangle(24, toastNib1Y, 30, 15);
                            toaster1.DrawStatic(spriteBatch, player1.IsPoisoned);

                            //toaster2
                            toasterNib2.Posit = new Rectangle(24, toastNib2Y, 30, 15);
                            toaster2.DrawStatic(spriteBatch, player1.IsPoisoned);

                            //nibs
                            toasterNib1.DrawStatic(spriteBatch, player1.IsPoisoned);
                            toasterNib2.DrawStatic(spriteBatch, player1.IsPoisoned);


                            //draw all cards in a loop
                            for (int i = 0; i < player1.Hand.Count; i++)
                            {
                                if (player1.Hand[i] != null) player1.Hand[i].DrawStatic(spriteBatch, font);
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                backCard.Posit = backCardPos[i];
                                backCard.DrawStatic(spriteBatch, player1.IsPoisoned);
                            }
                            break;
                        case Phase.Player2:
                            //toaster
                            toasterNib1.Posit = new Rectangle(24, toastNib1Y, 30, 15);
                            toaster1.DrawStatic(spriteBatch, player2.IsPoisoned);

                            //toaster2
                            toasterNib2.Posit = new Rectangle(24, toastNib2Y, 30, 15);
                            toaster2.DrawStatic(spriteBatch, player2.IsPoisoned);

                            //nibs
                            toasterNib2.DrawStatic(spriteBatch, player2.IsPoisoned);
                            toasterNib1.DrawStatic(spriteBatch, player2.IsPoisoned);

                            //draw all cards in a loop
                            for (int i = 0; i < player2.Hand.Count; i++)
                            {
                                if (player2.Hand[i] != null) player2.Hand[i].DrawStatic(spriteBatch, font);
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                backCard.Posit = backCardPos[i];
                                backCard.DrawStatic(spriteBatch, player2.IsPoisoned);
                            }
                            break;
                        case Phase.Pause:
                            switch (prevPhase)
                            {
                                case Phase.Player1:
                                    pause2.DrawStatic(spriteBatch);
                                    break;
                                case Phase.Player2:
                                    pause.DrawStatic(spriteBatch);
                                    break;
                                case Phase.Results:
                                    pause1.DrawStatic(spriteBatch);
                                    break;
                            }

                            break;
                        case Phase.Results:
                            for (int i = 0; i < cardsInPlay.Length; i++)
                            {
                                cardsInPlay[i].Posit = resultCardPos[i]; //thief and stealing the card that just got played like
                                cardsInPlay[i].DrawStatic(spriteBatch, font);
                            }
                            vs.DrawStatic(spriteBatch);
                            if (winPlayer == 1)
                            {
                                player1wins.DrawStatic(spriteBatch);
                            }
                            if (winPlayer == 2)
                            {
                                player2wins.DrawStatic(spriteBatch);
                            }
                            if (winPlayer == 0)
                            {
                                tie1.DrawStatic(spriteBatch);
                                tie2.DrawStatic(spriteBatch);
                            }
                            player1.DrawString(spriteBatch);
                            player2.DrawString(spriteBatch);
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
            deck.Shuffle();
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
