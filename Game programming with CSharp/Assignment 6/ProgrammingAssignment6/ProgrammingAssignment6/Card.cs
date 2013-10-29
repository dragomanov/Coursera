using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XnaCards
{
    /// <summary>
    /// A class for a playing card
    /// </summary>
    public class Card
    {
        #region Fields

        Rank rank;
        Suit suit;
        bool faceUp;

        // drawing support
        Texture2D faceUpSprite;
        Texture2D faceDownSprite;
        Rectangle drawRectangle = new Rectangle();

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a card with the given rank and suit centered on the given x and y
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="rank">the rank</param>
        /// <param name="suit">the suit</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        public Card(ContentManager contentManager, Rank rank, Suit suit, int x, int y)
        {
            this.rank = rank;
            this.suit = suit;
            faceUp = false;

            // load content and set draw rectangle location
            LoadContent(contentManager);
            drawRectangle.X = x - drawRectangle.Width / 2;
            drawRectangle.Y = y - drawRectangle.Height / 2;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets the centered x location of the card
        /// </summary>
        public int X
        {
            set { drawRectangle.X = value - drawRectangle.Width / 2; }
        }

        /// <summary>
        /// Sets the centered y location of the card
        /// </summary>
        public int Y
        {
            set { drawRectangle.Y = value - drawRectangle.Height / 2; }
        }

        /// <summary>
        /// Gets the width of the card
        /// </summary>
        public int Width
        {
            get { return drawRectangle.Width; }
        }

        /// <summary>
        /// Gets whether the card is face up
        /// </summary>
        public bool FaceUp
        {
            get { return faceUp; }
        }

        /// <summary>
        /// Gets the War value for the card
        /// </summary>
        public int WarValue
        {
            get
            {
                switch (rank)
                {
                    case XnaCards.Rank.Ace:
                        return 13;
                    case XnaCards.Rank.King:
                        return 12;
                    case XnaCards.Rank.Queen:
                        return 11;
                    case XnaCards.Rank.Jack:
                        return 10;
                    case XnaCards.Rank.Ten:
                        return 9;
                    case XnaCards.Rank.Nine:
                        return 8;
                    case XnaCards.Rank.Eight:
                        return 7;
                    case XnaCards.Rank.Seven:
                        return 6;
                    case XnaCards.Rank.Six:
                        return 5;
                    case XnaCards.Rank.Five:
                        return 4;
                    case XnaCards.Rank.Four:
                        return 3;
                    case XnaCards.Rank.Three:
                        return 2;
                    case XnaCards.Rank.Two:
                        return 1;
                    default:
                        return 0;
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the card
        /// </summary>
        /// <param name="spriteBatch">the sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (FaceUp)
            {
                spriteBatch.Draw(faceUpSprite, drawRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(faceDownSprite, drawRectangle, Color.White);
            }
        }

        /// <summary>
        /// Flips the card over
        /// </summary>
        public void FlipOver()
        {
            faceUp = !faceUp;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the card and sets draw rectangle size
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        private void LoadContent(ContentManager contentManager)
        {
            // load content and set draw rectangle size
            string spriteName = suit.ToString() + "/" + rank.ToString();
            faceUpSprite = contentManager.Load<Texture2D>(spriteName);
            drawRectangle.Width = faceUpSprite.Width;
            drawRectangle.Height = faceUpSprite.Height;
            faceDownSprite = contentManager.Load<Texture2D>("Back");
        }

        #endregion
    }
}
