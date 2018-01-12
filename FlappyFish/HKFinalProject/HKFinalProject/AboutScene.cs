using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace HKFinalProject
{
    /// <summary>
    /// AboutScene : Show AboutScene
    /// </summary>
    class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D aboutTex;
        private Rectangle aboutBackground;
        /// <summary>
        /// AboutScene
        /// </summary>
        /// <param name="game"></param>
        public AboutScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            aboutBackground = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            aboutTex = g.Content.Load<Texture2D>("Images/about");
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
            spriteBatch.Draw(aboutTex, aboutBackground, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
