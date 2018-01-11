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
        private SpriteFont title, regular,writtingName;
        private List<Shark> sharks = new List<Shark>();
        private Background background;
        private Score score;
        private Random rd = new Random();
        private Game1 g;
        private ContentManager Content;
        private bool hasChangeBackground = false;
        private float intervalTimer = 1;
        private bool isFishAlive = true;
        private bool hasFishDropped = false;
        private Rectangle scoreBoard;
        private Rectangle eidtBar;
        private Texture2D SaveScoreTex;
        private int editBarChange = 1;
        private bool hasEditBarIntervalChange = false;
        private string putName = "";
        private Vector2 editBarPosition = new Vector2(303, 478);
        private KeyboardState previousState;
        public ActionScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            Initialize();
            this.Components.Add(fish);
        }
        public override void Initialize()
        {
            Content = g.Content;
            fish = new Fish(g, spriteBatch, Content);
            background = new Background(g, spriteBatch, Content, "Images/background");
            score = new Score(g, spriteBatch, Content);
            title = Content.Load<SpriteFont>("Fonts/title");
            regular = Content.Load<SpriteFont>("Fonts/regularFont");
            writtingName = Content.Load<SpriteFont>("Fonts/writtingFont");
            
            scoreBoard = new Rectangle(100, 150, GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height - 300);
            eidtBar = new Rectangle(100, 150, 2, 30); ;
            SaveScoreTex = Content.Load<Texture2D>("Images/SaveScore");
            previousState = Keyboard.GetState();
            ReStartGame();
            base.Initialize();
        }
        float interval = 0;
        public override void Update(GameTime gameTime)
        {
            interval += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //fish die
            if (fish.fish.Y >= GraphicsDevice.Viewport.Height)
            {
                isFishAlive = false;
                hasFishDropped = true;
                fish.setFishDead(true);
            }
            foreach (Shark shark in sharks)
            {
                if ((fish.fish.X >= shark.sharkPositionX - fish.fish.Width && fish.fish.X <= shark.sharkPositionX + shark.sharkWidth) && (fish.fish.Y >= shark.sharkPositionY - fish.fish.Height && fish.fish.Y <= shark.sharkPositionY + shark.sharkHeight))
                {
                    isFishAlive = false;
                    fish.setFishDead(true);
            }
            }

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
            else
            {
                if (!hasEditBarIntervalChange)
                {
                    intervalTimer = 0.5f;
                    hasEditBarIntervalChange = true;
                }
                IntervalForEditBar();
            }
            base.Update(gameTime);
        }
    
        public void ReStartGame()
        {
            for (int i = 0; i < sharks.Count; i++)
            {
                sharks.RemoveAt(i);
                i--;
            }
            isFishAlive = true;
            fish.fish.X = 50;
            fish.fish.Y = 50;
            fish.setFishDead(false);
            score.score = 0;
            hasFishDropped = false;
        }
        public void IntervalForEditBar()
        {

            if (interval >= intervalTimer)
            {
                interval = 0;
                editBarChange *= -1;
            }
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
            if (hasFishDropped)
            {
                spriteBatch.Begin();
                scoreBoard = new Rectangle(100, 150, GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height - 300);
                spriteBatch.Draw(SaveScoreTex,scoreBoard, Color.White);
                spriteBatch.DrawString(title, "Game Over", new Vector2((GraphicsDevice.Viewport.Width - title.MeasureString("Game Over").X)/2, 150), Color.Red);
                spriteBatch.DrawString(regular, "Please enter your name less than 5 long and hit enter.", new Vector2(200, 380), Color.Black);
               if (editBarChange == 1)
                { 
                Texture2D editBar = Content.Load<Texture2D>("Images/editBar");
                spriteBatch.Draw(editBar, editBarPosition, Color.White);
                }
                putName = score.enterName();
                if (putName.Contains("#"))
                {
                    score.setPutName("");
                    g.setPressedESC(true);
                }
                else
                {
                    spriteBatch.DrawString(writtingName, putName, new Vector2(303, 478), Color.Black);
                    editBarPosition.X = 303 + writtingName.MeasureString(putName).X;
                }
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
