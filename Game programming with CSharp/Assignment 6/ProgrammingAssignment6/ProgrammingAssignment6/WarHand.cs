using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaCards
{
    /// <summary>
    /// Provides a class for a hand of cards in War
    /// </summary>
    public class WarHand
    {
        #region Fields

        List<Card> cards = new List<Card>();
        int x;
        int y;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a War hand centered on the given x and y
        /// </summary>
        /// <param name="x">the x location</param>
        /// <param name="y">the y location</param>
        public WarHand(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of cards in the hand
        /// </summary>
        public int Count
        {
            get { return cards.Count; }
        }

        /// <summary>
        /// Gets whether the hand is empty
        /// </summary>
        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        /// <summary>
        /// Gets the width of the hand or 0 if the hand is empty
        /// </summary>
        public int Width
        {
            get
            {
                if (!Empty)
                {
                    return cards[0].Width;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the hand, which is really just drawing the top card in the hand
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
        /// Takes the top card from the hand. If the deck is empty, returns null
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

        /// <summary>
        /// Adds a card to the top of the hand, making sure the card is face down
        /// </summary>
        /// <param name="card">the card to add</param>
        public void AddCard(Card card)
        {
            if (card.FaceUp)
            {
                card.FlipOver();
            }
            cards.Add(card);

            // move the card to the hand location
            card.X = x;
            card.Y = y;
        }

        /// <summary>
        /// Adds the cards from the given War battle pile to the bottom of the hand
        /// </summary>
        /// <param name="warBattlePile">the War battle pile to add</param>
        public void AddCards(WarBattlePile warBattlePile)
        {
            // add all the cards
            while (!warBattlePile.Empty)
            {
                Card card = warBattlePile.TakeTopCard();
                if (card.FaceUp)
                {
                    card.FlipOver();
                }
                cards.Insert(0, card);

                // move the card to the hand location
                card.X = x;
                card.Y = y;
            }
        }

        #endregion
    }
}
