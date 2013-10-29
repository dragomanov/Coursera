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
    /// Provides a class for a deck of cards
    /// </summary>
    public class Deck
    {
        #region Fields

        List<Card> cards = new List<Card>();

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a deck centered on the given x and y
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        public Deck(ContentManager contentManager, int x, int y)
        {
            // fill the deck with cards
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(contentManager, rank, suit, x, y));
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of cards in the deck
        /// </summary>
        public int Count
        {
            get { return cards.Count; }
        }

        /// <summary>
        /// Gets whether the deck is empty
        /// </summary>
        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the deck, which is really just drawing the top card on the deck
        /// </summary>
        /// <param name="spriteBatch">the sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Empty)
            {
                cards[cards.Count - 1].Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Cuts the deck of cards at the given location
        /// </summary>
        /// <param name="location">the location at which to cut the deck</param>
        public void Cut(int location)
        {
            Card[] newCards = new Card[cards.Count];
            cards.CopyTo(location, newCards, 0, cards.Count - location);
            cards.CopyTo(0, newCards, location, location);
            cards.InsertRange(0, newCards);
        }

        /// <summary>
        /// Shuffles the deck
        /// 
        /// Reference: http://download.oracle.com/javase/1.5.0/docs/api/java/util/Collections.html#shuffle%28java.util.List%29
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int randomIndex = rand.Next(i + 1);
                Card tempCard = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = tempCard;
            }
        }

        /// <summary>
        /// Takes the top card from the deck. If the deck is empty, returns null
        /// </summary>
        /// <returns>the top card</returns>
        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
