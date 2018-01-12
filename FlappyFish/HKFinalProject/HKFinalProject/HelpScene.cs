using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HKFinalProject
{
    /// <summary>
    /// HelpScene
    /// </summary>
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpTex;
        private Rectangle helpBackground;
        public HelpScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            helpBackground = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            helpTex = g.Content.Load<Texture2D>("Images/help");

        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpTex, helpBackground, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
