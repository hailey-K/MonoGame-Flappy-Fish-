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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Fish fish;
        private SpriteFont gameOverLabel;
        private List<Shark> sharks = new List<Shark>();
        private Background background;
        private Score score;
        private Random rd = new Random();
        private Game1 g;
        private ContentManager Content;
        private bool hasChangeBackground = false;
        private float intervalTimer = 1;
        private bool isFishAlive = true;
        public ActionScene(Game game) : base(game)
        {
           g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            Content = game.Content;
            fish = new Fish(game, spriteBatch, Content);
            background = new Background(game, spriteBatch, Content, "Images/background");
            score = new Score(game, spriteBatch, Content);
            gameOverLabel = Content.Load<SpriteFont>("Fonts/hilightFont");
            this.Components.Add(fish);
        }
        float interval = 0;
        public override void Update(GameTime gameTime)
        {
            interval += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //fish die
            if (fish.fish.Y >= GraphicsDevice.Viewport.Height)
            {
                isFishAlive = false;
            }
            //foreach (Shark shark in sharks)
            //{
            //    if ((fish.fish.X+fish.fish.Width >= shark.sharkPositionX && fish.fish.X <= shark.sharkPositionX+shark.sharkWidth) && (fish.fish.Y >= shark.sharkPositionY-fish.fish.Height && fish.fish.Y+fish.fish.Height <= shark.sharkPositionY+shark.sharkHeight))
            //        isFishAlive = false;
         
            //}

            if (isFishAlive)
            {
                background.Update(gameTime);
                score.Update(gameTime);

                if (score.score >= 400 && !hasChangeBackground)
            { 
                background = new Background(g, spriteBatch, Content, "Images/backgroundLevel2");
                hasChangeBackground = true;
            }
            foreach (Shark shark in sharks)
            {
                if (hasChangeBackground)
                    shark.setSpeed(10);
                
                    shark.Update(gameTime);
            }
            LoadShark();
            }
            base.Update(gameTime);
        }
        public void LoadShark()
        {

            int sharkY = rd.Next(0, GraphicsDevice.Viewport.Height - 110);
            if (hasChangeBackground)
                intervalTimer = 0.5f;

            if (interval >= intervalTimer)
            {
                interval = 0;
                if (sharks.Count < 7)
                    sharks.Add(new Shark(g, spriteBatch, Content, sharkY));
            }

            for(int i = 0; i < sharks.Count; i++)
            {
                if (sharks[i].sharkPositionX + 110 <= 0)
                {
                    sharks.RemoveAt(i);
                    i--;
                }
            }
        }
        public override void Draw(GameTime gameTime)
        {
           

            background.Draw(gameTime);
            fish.Draw(gameTime);
            score.Draw(gameTime);
            foreach (Shark shark in sharks)
            {
                shark.Draw(gameTime);
            }
            if (!isFishAlive)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(gameOverLabel, "Game Over", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Red);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
