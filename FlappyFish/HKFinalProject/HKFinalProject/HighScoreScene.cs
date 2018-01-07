using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HKFinalProject
{
    class HighScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D aboutTex;
        private Rectangle highScoreBackground;
        SpriteFont highlightFont;
        File file;
        string fileInfo;
        Vector2 position;
        public HighScoreScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            highScoreBackground = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            highlightFont = game.Content.Load<SpriteFont>("Fonts/hilightFont");
            aboutTex = g.Content.Load<Texture2D>("Images/highScore");
            file = new File();
            fileInfo = file.readFile();
            position = new Vector2(0,0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(aboutTex, highScoreBackground, Color.White);
            for (int i = 0; i < fileInfo.Length; i++)
            spriteBatch.DrawString(highlightFont, fileInfo, position, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
