using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont buttonFont;

        MouseState prevMouseState;
        MouseState mouseState;

        Texture2D playerIdle;
        Texture2D playerAttack;
        Texture2D knightIdle;
        Texture2D button;
        Texture2D forestBG;

        int playerIdleColumns;
        int playerIdleFrame;
        int playerIdleFrames;
        int playerIdleWidth;
        int playerIdleHeight;

        int playerAttackColumns;
        int playerAttackFrame;
        int playerAttackFrames;
        int playerAttackWidth;
        int playerAttackHeight;

        int knightIdleColumns;
        int knightIdleFrame;
        int knightIdleFrames;
        int knightIdleWidth;
        int knightIdleHeight;

        float knightTime, playerTime, playerIdleFrameSpeed, playerAttackFrameSpeed, knightIdleFrameSpeed;

        Rectangle playerDraw;
        Rectangle knightIdleDraw;
        Rectangle window;
        Rectangle buttonFight;

        bool buttonFightVisible = true;
        bool playerIdleVisible = true;
        bool playerAttackVisible = false;
        bool knightIdleVisible = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            window = new Rectangle(0, 0, 800, 450);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            buttonFight = new Rectangle(0, 0, button.Width, button.Height);

            playerIdleColumns = 7;
            playerIdleHeight = playerIdle.Height;
            playerIdleWidth = playerIdle.Width / playerIdleColumns;
            playerIdleFrameSpeed = 0.12f;
            playerIdleFrames = playerIdleColumns;
            playerIdleFrame = 0;
            playerTime = 0f;
            playerDraw = new Rectangle(100, 100, playerIdleWidth * 2, playerIdleHeight * 2);

            playerAttackColumns = 5;
            playerAttackHeight = playerAttack.Height;
            playerAttackWidth = playerAttack.Width / playerAttackColumns;
            playerAttackFrameSpeed = 0.12f;
            playerAttackFrames = playerAttackColumns;
            playerAttackFrame = 0;
            

            knightIdleColumns = 4;
            knightIdleHeight = knightIdle.Height;
            knightIdleWidth = knightIdle.Width / knightIdleColumns;
            knightIdleFrameSpeed = 0.25f;
            knightIdleFrames = knightIdleColumns;
            knightIdleFrame = 2;
            knightTime = 0f;
            knightIdleDraw = new Rectangle(400, 100, knightIdleWidth * 2, knightIdleHeight * 2);




        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerIdle = Content.Load<Texture2D>("Idle");
            playerAttack = Content.Load<Texture2D>("PlayerAttack");

            knightIdle = Content.Load<Texture2D>("KnightIdle");
            forestBG = Content.Load<Texture2D>("Forest");
            button = Content.Load<Texture2D>("button");

            buttonFont = Content.Load<SpriteFont>("Font");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            

            base.Update(gameTime);

            playerTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            knightTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (buttonFight.Contains(mouseState.Position))
                {
                    int damage = DamageCalc.playerMelee(0);
                    playerIdleVisible = false;
                    playerAttackVisible = true;
                }
            }


                if (playerTime > playerIdleFrameSpeed)
            {
                playerTime = 0f;

                playerIdleFrame += 1;

                if (playerIdleFrame >= playerIdleFrames)
                    playerIdleFrame = 0;

            }


            if (knightTime > knightIdleFrameSpeed)
            {
                knightTime = 0f;

                knightIdleFrame += 1;

                if (knightIdleFrame >= knightIdleFrames)
                    knightIdleFrame = 0;

            }

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin();

            _spriteBatch.Draw(forestBG, new Rectangle(0, 0, forestBG.Width, forestBG.Height), Color.White);
            
            if (playerIdleVisible == true)
            _spriteBatch.Draw(playerIdle, playerDraw, new Rectangle(playerIdleFrame * playerIdleWidth, 0, playerIdleWidth, playerIdleHeight), Color.White);
            if (knightIdleVisible == true)
                _spriteBatch.Draw(knightIdle, knightIdleDraw, new Rectangle(knightIdleFrame * knightIdleWidth, 0, knightIdleWidth, knightIdleHeight), Color.White, 0f, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0f);
            if (buttonFightVisible == true)
            {
                _spriteBatch.Draw(button, buttonFight, buttonFight, Color.White);
                _spriteBatch.DrawString(buttonFont, "Attack", new Vector2(20, 0), Color.White);
            }

            _spriteBatch.End();
        }

      
    }


}
