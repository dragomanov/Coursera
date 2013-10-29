using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaCards
{
    /// <summary>
    /// Provides a class for a battle pile of cards in War
    /// </summary>
    public class WarBattlePile
    {
        #region Fields

        List<Card> cards = new List<Card>();
        int x;
        int y;

        // for drawing cards horizontally
        const float CARD_OFFSET_PERCENT = 0.5f;
        int topCardX;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a War battle pile with the left-most card centered on the given x and y
        /// </summary>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        public WarBattlePile(int x, int y)
        {
            this.x = x;
            this.y = y;
            topCardX = x;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of cards in the pile
        /// </summary>
        public int Count
        {
            get { return cards.Count; }
        }

        /// <summary>
        /// Gets whether the pile is empty
        /// </summary>
        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the battle pile. If the battle pile has more than one card, the cards are drawn in a 
        /// horizontal line
        /// </summary>
        /// <param name="spriteBatch">the sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Card card in cards)
            {
                card.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Gets the top card from the battle pile, leaving the card on the pile. 
        /// If the pile is empty, returns null
        /// </summary>
        /// <returns>the top card</returns>
        public Card GetTopCard()
        {
            if (!Empty)
            {
                return cards[cards.Count - 1];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Takes the top card from the battle pile. If the pile is empty, returns null
        /// </summary>
        /// <returns>the top card</returns>
        public Card TakeTopCard()
        {
            if (!Empty)
            {
                // save top card and remove from list
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);

                // shift top card offset for removed card
                if (cards.Count > 0)
                {
                    topCardX -= (int)(topCard.Width * CARD_OFFSET_PERCENT);
                }

                return topCard;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a card to the top of the battle pile
        /// </summary>
        /// <param name="card">the card to add</param>
        public void AddCard(Card card)
        {
            cards.Add(card);

            // shift top card offset for added card
            if (cards.Count > 1)
            {
                topCardX += (int)(card.Width * CARD_OFFSET_PERCENT);
            }

            // move the card to the appropriate location
            card.X = topCardX;
            card.Y = y;
        }

        #endregion
    }
}
