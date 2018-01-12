using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HKFinalProject
{
    /// <summary>
    /// GameScene
    /// </summary>
    public abstract class GameScene : DrawableGameComponent
    {
        public List<GameComponent> Components { get; set; }
        /// <summary>
        /// show
        /// </summary>
        public virtual void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        /// <summary>
        /// hide
        /// </summary>
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        /// <summary>
        /// GameScene
        /// </summary>
        /// <param name="game"></param>
        public GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            hide();
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in Components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }



            base.Update(gameTime);
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in Components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }
    }
}
