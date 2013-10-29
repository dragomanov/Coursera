using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using XnaCards;

namespace ProgrammingAssignment6
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int WIN_WIDTH = 800;
        const int WIN_HEIGHT = 600;
        const int STARTING_HAND_SIZE = 26;

        // keep track of game state and current winner
        static GameState gameState = GameState.Play;
        static Player winner;

        // hands and battle piles for the players
        WarHand p1Hand;
        WarHand p2Hand;
        WarBattlePile p1BattlePile;
        WarBattlePile p2BattlePile;

        // winner messages for players
        WinnerMessage p1WinnerMsg;
        WinnerMessage p2WinnerMsg;

        // menu buttons
        MenuButton flipButton;
        MenuButton collectWinningsButton;
        MenuButton quitButton;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // make mouse visible and set resolution
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = WIN_WIDTH;
            graphics.PreferredBackBufferHeight = WIN_HEIGHT;
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // create the deck object and shuffle
            Deck deck = new Deck(Content, 0, 0);
            deck.Shuffle();

            // create the player hands and fully deal the deck into the hands
            p1Hand = new WarHand(WIN_WIDTH / 2, 80);
            p2Hand = new WarHand(WIN_WIDTH / 2, WIN_HEIGHT - 80);
            for (int i = 0; i < STARTING_HAND_SIZE; i++)
            {
                p1Hand.AddCard(deck.TakeTopCard());
                p2Hand.AddCard(deck.TakeTopCard());
            }

            // create the player battle piles
            p1BattlePile = new WarBattlePile(WIN_WIDTH / 2, 200);
            p2BattlePile = new WarBattlePile(WIN_WIDTH / 2, WIN_HEIGHT - 200);

            // create the player winner messages
            p1WinnerMsg = new WinnerMessage(Content, WIN_WIDTH - 200, 80);
            p2WinnerMsg = new WinnerMessage(Content, WIN_WIDTH - 200, WIN_HEIGHT - 80);

            // create the menu buttons
            flipButton = new MenuButton(Content, "flipbutton", 160, 130, GameState.Flip);
            collectWinningsButton = new MenuButton(Content, "collectwinningsbutton", 160, WIN_HEIGHT / 2, GameState.CollectWinnings);
            collectWinningsButton.Visible = false;
            quitButton = new MenuButton(Content, "quitbutton", 160, WIN_HEIGHT - 130, GameState.Quit);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // update the menu buttons
            MouseState mouseState = Mouse.GetState();
            flipButton.Update(mouseState);
            collectWinningsButton.Update(mouseState);
            quitButton.Update(mouseState);

            // update based on game state
            switch (gameState)
            {
                case GameState.CollectWinnings:
                    collectWinningsButton.Visible = false;
                    flipButton.Visible = true;
                    p1WinnerMsg.Visible = false;
                    p2WinnerMsg.Visible = false;
                    CollectWinnings();
                    break;
                case GameState.Flip:
                    flipButton.Visible = false;
                    collectWinningsButton.Visible = true;
                    Battle();
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Play:
                    break;
                case GameState.Quit:
                    this.Exit();
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        private void CollectWinnings()
        {
            switch (winner)
            {
                case Player.None:
                    p1Hand.AddCards(p1BattlePile);
                    p2Hand.AddCards(p2BattlePile);
                    break;
                case Player.Player1:
                    p1Hand.AddCards(p1BattlePile);
                    p1Hand.AddCards(p2BattlePile);
                    break;
                case Player.Player2:
                    p2Hand.AddCards(p1BattlePile);
                    p2Hand.AddCards(p2BattlePile);
                    break;
                default:
                    break;
            }

            if (p1Hand.Empty || p2Hand.Empty)
            {
                flipButton.Visible = false;
                if (winner == Player.Player1)
                {
                    p1WinnerMsg.Visible = true;
                }
                else
                {
                    p2WinnerMsg.Visible = true;
                }
                gameState = GameState.GameOver;
            }
            else
            {
                gameState = GameState.Play;
            }
        }

        private void Battle()
        {
            Card card = p1Hand.TakeTopCard();
            card.FlipOver();
            p1BattlePile.AddCard(card);
            card = p2Hand.TakeTopCard();
            card.FlipOver();
            p2BattlePile.AddCard(card);
            if (p1BattlePile.GetTopCard().WarValue > p2BattlePile.GetTopCard().WarValue)
            {
                winner = Player.Player1;
                p1WinnerMsg.Visible = true;
            }
            else if (p1BattlePile.GetTopCard().WarValue < p2BattlePile.GetTopCard().WarValue)
            {
                winner = Player.Player2;
                p2WinnerMsg.Visible = true;
            }
            else
            {
                winner = Player.None;
            }
            gameState = GameState.Play;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Goldenrod);
            spriteBatch.Begin();

            // draw the game objects
            p1Hand.Draw(spriteBatch);
            p2Hand.Draw(spriteBatch);
            p1BattlePile.Draw(spriteBatch);
            p2BattlePile.Draw(spriteBatch);

            // draw the winner messages
            p1WinnerMsg.Draw(spriteBatch);
            p2WinnerMsg.Draw(spriteBatch);

            // draw the menu buttons
            flipButton.Draw(spriteBatch);
            collectWinningsButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Changes the state of the game
        /// </summary>
        /// <param name="newState">the new game state</param>
        public static void ChangeState(GameState newState)
        {
            gameState = newState;
        }
    }
}
