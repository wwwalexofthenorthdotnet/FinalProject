using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D playerIdle;

        int playerIdleColumns;
        int playerIdleFrame;
        int playerIdleFrames;
        int playerIdleWidth;
        int playerIdleHeight;

        float time, playerIdleFrameSpeed, playerIdleOpacity;

        Rectangle playerIdleSource;
        Rectangle playerIdleDraw;
        Rectangle window;

        bool playerIdleVisible = true;

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
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            playerIdleColumns = 7;
            playerIdleHeight = playerIdle.Height;
            playerIdleWidth = playerIdle.Width / playerIdleColumns;

            time = 0.0f;
            playerIdleFrameSpeed = 0.12f;
            playerIdleFrames = playerIdleColumns;
            playerIdleFrame = 0;

            playerIdleDraw = new Rectangle(0, 0, playerIdleWidth, playerIdleHeight);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerIdle = Content.Load<Texture2D>("Idle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (time > playerIdleFrameSpeed)
            {
                time -= playerIdleFrameSpeed;
                
                playerIdleFrame += 1;

                if (playerIdleFrame >= playerIdleFrames)
                    playerIdleFrame = 0;

            }

            if (playerIdleVisible ==  false)
                playerIdleOpacity = 1.0f;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin();

            _spriteBatch.Draw(playerIdle, playerIdleDraw, new Rectangle(playerIdleFrame * playerIdleWidth, 0, playerIdleWidth, playerIdleHeight), Color.White * playerIdleOpacity);

            _spriteBatch.End();
        }
    }
}
