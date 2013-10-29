using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProgrammingAssignment6
{
    /// <summary>
    /// A winner message
    /// </summary>
    class WinnerMessage
    {
        #region Fields

        Texture2D sprite;
        bool visible = false;
        Rectangle drawRectangle = new Rectangle();

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs winner message centered on the given x and y location
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="x">the x location of the upper left corner of the button</param>
        /// <param name="y">the y location of the upper left corner of the button</param>
        public WinnerMessage(ContentManager contentManager, int x, int y)
        {
            LoadContent(contentManager);

            // set draw rectangle location
            drawRectangle.X = x - drawRectangle.Width / 2;
            drawRectangle.Y = y - drawRectangle.Height / 2;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets whether the winner message is visible
        /// </summary>
        public bool Visible
        {
            set { visible = value; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the winner message
        /// </summary>
        /// <param name="spriteBatch">Reference to a spritebatch object</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // only draws if visible
            if (visible)
            {
                spriteBatch.Draw(sprite, drawRectangle, Color.White);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the winner message
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        private void LoadContent(ContentManager contentManager)
        {
            // load the sprite
            sprite = contentManager.Load<Texture2D>("winner");

            // set draw rectangle size
            drawRectangle.Width = sprite.Width;
            drawRectangle.Height = sprite.Height;
        }

        #endregion
    }
}
