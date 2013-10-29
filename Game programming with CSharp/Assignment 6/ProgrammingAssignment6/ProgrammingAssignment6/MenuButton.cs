using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProgrammingAssignment6
{
    /// <summary>
    /// A menu button
    /// </summary>
    class MenuButton
    {
        #region Fields

        // fields for button image
        Texture2D sprite;
        const int IMAGES_PER_ROW = 2;
        int buttonWidth;

        // fields for drawing
        bool visible = true;
        Rectangle drawRectangle = new Rectangle();
        Rectangle sourceRectangle;
        
        // click processing
        GameState clickState;
        bool clickStarted = false;
        bool buttonReleased = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs menu button centered on the given x and y location
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="spriteName">the sprite name for the button</param>
        /// <param name="x">the x location of the upper left corner of the button</param>
        /// <param name="y">the y location of the upper left corner of the button</param>
        /// <param name="clickState">the game state to change to when the button is clicked</param>
        public MenuButton(ContentManager contentManager, string spriteName, int x, int y, GameState clickState)
        {
            this.clickState = clickState;
            LoadContent(contentManager, spriteName);

            // set draw rectangle location
            drawRectangle.X = x - drawRectangle.Width / 2;
            drawRectangle.Y = y - drawRectangle.Height / 2;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets whether the menu button is visible
        /// </summary>
        public bool Visible
        {
            set { visible = value; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the menu button. May highlight the button or detect button click
        /// </summary>
        /// <param name="mouse">the current mouse state</param>
        public void Update(MouseState mouse)
        {
            // only updates if button is visible
            if (visible)
            {
                // check for mouse over button
                if (drawRectangle.Contains(mouse.X, mouse.Y))
                {
                    // highlight button
                    sourceRectangle.X = buttonWidth;

                    // check for click started on button
                    if (mouse.LeftButton == ButtonState.Pressed &&
                        buttonReleased)
                    {
                        clickStarted = true;
                    }
                    else if (mouse.LeftButton == ButtonState.Released)
                    {
                        buttonReleased = true;

                        // if click finished on button, change game state
                        if (clickStarted)
                        {
                            Game1.ChangeState(clickState);

                            // click is no longer started on button
                            clickStarted = false;
                        }
                    }
                }
                else
                {
                    sourceRectangle.X = 0;

                    // no clicking on this button
                    clickStarted = false;
                    buttonReleased = false;
                }
            }
        }

        /// <summary>
        /// Draws the menu button
        /// </summary>
        /// <param name="spriteBatch">Reference to a spritebatch object</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // only draws if visible
            if (visible)
            {
                spriteBatch.Draw(sprite, drawRectangle, sourceRectangle, Color.White);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the menu button
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="spriteName">the name of the sprite to load</param>
        private void LoadContent(ContentManager contentManager, string spriteName)
        {
            // load the sprite
            sprite = contentManager.Load<Texture2D>(spriteName);

            // calculate button width
            buttonWidth = sprite.Width / IMAGES_PER_ROW;

            // set initial draw and source rectangles
            drawRectangle.Width = buttonWidth;
            drawRectangle.Height = sprite.Height;
            sourceRectangle = new Rectangle(0, 0, buttonWidth, sprite.Height);
        }

        #endregion
    }
}
