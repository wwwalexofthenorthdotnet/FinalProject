using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        SpriteFont damageFont;

        MouseState prevMouseState;
        MouseState mouseState;

        Texture2D playerIdle;
        Texture2D playerAttack;
        Texture2D playerHurt;
        Texture2D knightIdle;
        Texture2D knightHurt;
        Texture2D knightAttack;
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

        int knightHurtColumns;
        int knightHurtFrame;
        int knightHurtFrames;
        int knightHurtWidth;
        int knightHurtHeight;

        int knightAttackColumns;
        int knightAttackFrame;
        int knightAttackFrames;
        int knightAttackWidth;
        int knightAttackHeight;
        float knightAttackFrameSpeed;
        float knightAttackTime;

        int playerHurtColumns;
        int playerHurtFrame;
        int playerHurtFrames;
        int playerHurtWidth;
        int playerHurtHeight;
        float playerHurtFrameSpeed;
        float playerHurtTime;


        int damage = 0;
        int lastDamage = 0;

        int knightHealth;
        int maxPlayerHealth;
        int currentPlayerHealth;


        float knightIdleTime, knightHurtTime, playerIdleTime, playerAttackTime, playerIdleFrameSpeed, playerAttackFrameSpeed, knightIdleFrameSpeed, knightHurtFrameSpeed;

        Rectangle playerDraw;
        Rectangle knightIdleDraw;
        Rectangle window;
        Rectangle buttonFight;

        bool buttonFightVisible = true;
        bool playerIdleVisible = true;
        bool playerAttackVisible = false;
        bool playerHurtVisible = false;
        bool knightIdleVisible = true;
        bool knightHurtVisible = false;
        bool knightAttackVisible = false;
       

        bool knightActive = true;

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
            playerIdleTime = 0f;
            playerDraw = new Rectangle(100, 100, playerIdleWidth * 2, playerIdleHeight * 2);

            playerAttackColumns = 5;
            playerAttackHeight = playerAttack.Height;
            playerAttackWidth = playerAttack.Width / playerAttackColumns;
            playerAttackFrameSpeed = 0.12f;
            playerAttackFrames = playerAttackColumns;
            playerAttackFrame = 0;
            playerAttackTime = 0f;

            playerHurtColumns = 4;
            playerHurtHeight = playerHurt.Height;
            playerHurtWidth = playerHurt.Width / playerHurtColumns;
            playerHurtFrameSpeed = 0.1f;
            playerHurtFrames = playerHurtColumns;
            playerHurtFrame = 0;
            playerHurtTime = 0f;
            

            knightIdleColumns = 4;
            knightIdleHeight = knightIdle.Height;
            knightIdleWidth = knightIdle.Width / knightIdleColumns;
            knightIdleFrameSpeed = 0.2f;
            knightIdleFrames = knightIdleColumns;
            knightIdleFrame = 2;
            knightIdleTime = 0f;
            knightIdleDraw = new Rectangle(400, 100, knightIdleWidth * 2, knightIdleHeight * 2);

            knightHurtColumns = 2;
            knightHurtHeight = knightHurt.Height;
            knightHurtWidth = knightHurt.Width / knightHurtColumns;
            knightHurtFrameSpeed = 0.25f;
            knightHurtFrames = knightHurtColumns;
            knightHurtFrame = 0;
            knightHurtTime = 0f;

            knightAttackColumns = 5;
            knightAttackFrames = knightAttackColumns;
            knightAttackFrame = 0;
            knightAttackTime = 0f;
            knightAttackHeight = knightAttack.Height;
            knightAttackWidth = knightAttack.Width / knightAttackColumns;
            knightAttackFrameSpeed = 0.1f;

            knightHealth = DamageCalc.enemyHealth;
            maxPlayerHealth = DamageCalc.playerHealth;
            currentPlayerHealth = maxPlayerHealth;


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerIdle = Content.Load<Texture2D>("Idle");
            playerAttack = Content.Load<Texture2D>("PlayerAttack");
            playerHurt = Content.Load<Texture2D>("playerHurt");

            knightIdle = Content.Load<Texture2D>("knightIdle");
            knightHurt = Content.Load<Texture2D>("knightHurt");
            knightAttack = Content.Load<Texture2D>("knightAttack");
            
            forestBG = Content.Load<Texture2D>("Forest");
            button = Content.Load<Texture2D>("button");

            buttonFont = Content.Load<SpriteFont>("Font");
            damageFont = Content.Load<SpriteFont>("damageFont");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here



            base.Update(gameTime);

            playerIdleTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            knightIdleTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (playerAttackVisible)
                playerAttackTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (knightHurtVisible)
                knightHurtTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (knightAttackVisible)
                knightAttackTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (playerHurtVisible)
                playerHurtTime += (float)gameTime.ElapsedGameTime.TotalSeconds;


            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (buttonFight.Contains(mouseState.Position) && playerIdleVisible && knightIdleVisible)
                {
                    damage = DamageCalc.PlayerMelee(0);
                    lastDamage = damage;
                    
                    playerIdleVisible = false;
                    playerAttackVisible = true;
                }
            }

            if (knightHurtVisible)
            {
                knightHealth = knightHealth - damage;
                damage = 0;
            }

            if (playerHurtVisible)
            {
                currentPlayerHealth = currentPlayerHealth - damage;
                damage = 0;
            }


            if (playerIdleTime > playerIdleFrameSpeed)
            {
                playerIdleTime = 0f;

                playerIdleFrame = (playerIdleFrame + 1) % playerIdleFrames;

            }


            if (knightIdleTime > knightIdleFrameSpeed)
            {
                knightIdleTime = 0f;

                knightIdleFrame = (knightIdleFrame + 1) % knightIdleFrames;

            }

            if (playerAttackTime > playerAttackFrameSpeed && playerAttackVisible)
            {
                playerAttackTime = 0f;

                playerAttackFrame = (playerAttackFrame + 1) % playerAttackFrames;
                
                if (playerAttackFrame == 0)
                {
                    playerIdleVisible = true;
                    playerAttackVisible = false;
                    knightHurtVisible = true;
                    knightIdleVisible = false;
                }
            }

            if (playerHurtTime > playerHurtFrameSpeed && playerHurtVisible)
            {
                playerHurtTime = 0f;

                playerHurtFrame = (playerHurtFrame + 1) % playerHurtFrames;

                if (playerHurtFrame == 0)
                {
                    playerHurtVisible = false;
                    playerIdleVisible = true;
                }
            }

            if (knightHurtTime > knightHurtFrameSpeed && knightHurtVisible)
            {
                knightHurtTime = 0f;

                knightHurtFrame = (knightHurtFrame + 1) % knightHurtFrames;

                if (knightHurtFrame == 0)
                {
                    knightHurtVisible = false;
                    knightAttackVisible = true;
                }
            }

            if (knightAttackTime > knightAttackFrameSpeed && knightAttackVisible)
            {
                damage = DamageCalc.KnightMelee(0);
                lastDamage = damage;

                knightAttackTime = 0f;

                knightAttackFrame = (knightAttackFrame + 1) % knightAttackFrames;

                if (knightAttackFrame == 0)
                {
                    knightIdleVisible = true;
                    knightAttackVisible = false;
                    playerHurtVisible = true;
                    playerIdleVisible = false;

                }


            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin();

            _spriteBatch.Draw(forestBG, new Rectangle(0, 0, forestBG.Width, forestBG.Height), Color.White);
            
            if (playerIdleVisible)
            _spriteBatch.Draw(playerIdle, playerDraw, new Rectangle(playerIdleFrame * playerIdleWidth, 0, playerIdleWidth, playerIdleHeight), Color.White);
            if (playerAttackVisible)
                _spriteBatch.Draw(playerAttack, playerDraw, new Rectangle(playerAttackFrame * playerAttackWidth, 0, playerAttackWidth, playerAttackHeight), Color.White);
            if (knightIdleVisible)
                _spriteBatch.Draw(knightIdle, knightIdleDraw, new Rectangle(knightIdleFrame * knightIdleWidth, 0, knightIdleWidth, knightIdleHeight), Color.White, 0f, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0f);
            if (knightHurtVisible)
            { 
                _spriteBatch.Draw(knightHurt, knightIdleDraw, new Rectangle(knightHurtFrame * knightHurtWidth, 0, knightHurtWidth, knightHurtHeight), Color.DarkRed, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                _spriteBatch.DrawString(damageFont, lastDamage.ToString(), new Vector2(500, 200), Color.White);
            }
            if (buttonFightVisible)
            {
                _spriteBatch.Draw(button, buttonFight, buttonFight, Color.White);
                _spriteBatch.DrawString(buttonFont, "Attack", new Vector2(20, 0), Color.White);
            }

            if (knightAttackVisible)
                _spriteBatch.Draw(knightAttack, knightIdleDraw, new Rectangle(knightAttackFrame * knightAttackWidth, 0, knightAttackWidth, knightAttackHeight), Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);

            if (playerHurtVisible)
            { 
               _spriteBatch.Draw(playerHurt, playerDraw, new Rectangle(playerHurtFrame * playerHurtWidth, 0, playerHurtWidth, playerHurtHeight), Color.DarkRed);
                _spriteBatch.DrawString(damageFont, lastDamage.ToString(), new Vector2(275, 200), Color.White);

            }

            _spriteBatch.DrawString(damageFont, knightHealth.ToString() + "/" + DamageCalc.enemyHealth.ToString(), new Vector2(550, 350), Color.White);
            _spriteBatch.DrawString(damageFont, currentPlayerHealth.ToString() + "/" + maxPlayerHealth.ToString(), new Vector2(175, 350), Color.White);




            _spriteBatch.End();
        }

      
    }


}
