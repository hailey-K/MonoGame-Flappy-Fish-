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
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        //declare all the scenes here
        private StartScene startScene;
        private ActionScene actionScene;
        private HelpScene helpScene;
        private HighScoreScene highScoreScene;
        private AboutScene aboutScene;
        public SpriteFont spriteFont;
        private bool ispressedESC=false;
        private KeyboardState previousState = Keyboard.GetState();
        private Song song;
       
          
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1500;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 900;   // set this value to the desired height of your window
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            this.song = Content.Load<Song>("Music/mainMenu");
            MediaPlayer.Play(song);


            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            //initialize other Shared class members

            base.Initialize();
        }
        /// <summary>
        /// MediaPlayer_MediaStateChanged : Gradually music play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MediaPlayer_MediaStateChanged(object sender, System.
                                    EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
        }
        private void hideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            //create other scenes here and add to component list
            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            highScoreScene = new HighScoreScene(this);
            this.Components.Add(highScoreScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;

            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;

                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter) && !previousState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    actionScene.ReStartGame();
                    actionScene.show();
                    ChangeSong("Music/GameMusic");
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    highScoreScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScene.show();
                }
                //handle other menu options
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (actionScene.Enabled || helpScene.Enabled || highScoreScene.Enabled || aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    if (actionScene.Enabled)
                    {
                        ChangeSong("Music/mainMenu");
                    }
                    hideAllScenes();
                    startScene.show();
                }
                if (ispressedESC)
                {
                    ispressedESC = false;
                    if (actionScene.Enabled)
                    {
                        ChangeSong("Music/mainMenu");
                    }
                    hideAllScenes();
                    startScene.show();
                }
            }
            previousState = ks;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        /// <summary>
        /// ChangeSong : Change song, setting different song path
        /// </summary>
        /// <param name="path"></param>
        public void ChangeSong(string path)
        {
            this.song = Content.Load<Song>(path);
            MediaPlayer.Play(song);
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }
        /// <summary>
        /// setPressedESC : Make ESC Key pressed
        /// </summary>
        /// <param name="ispressedESC"></param>
        public void setPressedESC(bool ispressedESC)
        {
            this.ispressedESC = ispressedESC;
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
