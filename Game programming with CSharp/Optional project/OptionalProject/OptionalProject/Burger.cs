﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OptionalProject
{
    /// <summary>
    /// A class for a burger
    /// </summary>
    public class Burger
    {
        #region Fields

        // graphic and drawing info
        Texture2D sprite;
        Rectangle drawRectangle;

        // burger stats
        int health = 100;

        // shooting support
        bool canShoot = true;
        int elapsedCooldownTime = 0;

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructs a burger
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="spriteName">the sprite name</param>
        /// <param name="x">the x location of the center of the burger</param>
        /// <param name="y">the y location of the center of the burger</param>
        public Burger(ContentManager contentManager, string spriteName, int x, int y)
        {
            LoadContent(contentManager, spriteName, x, y);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the collision rectangle for the burger
        /// </summary>
        public Rectangle CollisionRectangle
        {
            get { return drawRectangle; }
        }

        #endregion

        #region Private properties

        /// <summary>
        /// Gets and sets the x location of the center of the burger
        /// </summary>
        private int X
        {
            get { return drawRectangle.Center.X; }
            set
            {
                drawRectangle.X = value - drawRectangle.Width / 2;

                // clamp to keep in range
                if (drawRectangle.X < 0)
                {
                    drawRectangle.X = 0;
                }
                else if (drawRectangle.X > GameConstants.WINDOW_WIDTH - drawRectangle.Width)
                {
                    drawRectangle.X = GameConstants.WINDOW_WIDTH - drawRectangle.Width;
                }
            }
        }

        /// <summary>
        /// Gets and sets the y location of the center of the burger
        /// </summary>
        private int Y
        {
            get { return drawRectangle.Center.Y; }
            set
            {
                drawRectangle.Y = value - drawRectangle.Height / 2;

                // clamp to keep in range
                if (drawRectangle.Y < 0)
                {
                    drawRectangle.Y = 0;
                }
                else if (drawRectangle.Y > GameConstants.WINDOW_HEIGHT - drawRectangle.Height)
                {
                    drawRectangle.Y = GameConstants.WINDOW_HEIGHT - drawRectangle.Height;
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the burger's location based on gamepad. Also fires 
        /// french fries as appropriate
        /// </summary>
        /// <param name="gameTime">game time</param>
        /// <param name="gamepad">the current state of the gamepad</param>
        /// <param name="soundBank">the sound bank</param>
        public void Update(GameTime gameTime, GamePadState gamepad,
            SoundBank soundBank)
        {
            // burger should only respond to input if it still has health

            // move burger using thumbstick deflection

            // update shooting allowed
            // timer concept (for animations) introduced in Chapter 7

            // shoot if appropriate

        }

        /// <summary>
        /// Draws the burger
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sprite, this.drawRectangle, Color.White);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the burger
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="spriteName">the name of the sprite for the burger</param>
        /// <param name="x">the x location of the center of the burger</param>
        /// <param name="y">the y location of the center of the burger</param>
        private void LoadContent(ContentManager contentManager, string spriteName,
            int x, int y)
        {
            // load content and set remainder of draw rectangle
            sprite = contentManager.Load<Texture2D>(spriteName);
            drawRectangle = new Rectangle(x - sprite.Width / 2,
                y - sprite.Height / 2, sprite.Width,
                sprite.Height);
        }

        #endregion
    }
}
