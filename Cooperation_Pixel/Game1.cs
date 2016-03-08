using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cooperation_Pixel
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Background_img;
        Rectangle Background;

        Texture2D jogador_img;
        Rectangle jogador;

        private personagem humano = new personagem(150, 100);


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Background = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            jogador = new Rectangle(humano.x, humano.y, 50, 40);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Background_img = Content.Load<Texture2D>("img_pixel");
            jogador_img = Content.Load<Texture2D>("norton");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            foreach(Keys k in keys)
            {
                if (k.Equals(Keys.Up) && (humano.y > 0))
                {
                    humano.moverY(-2);
                }
                if (k.Equals(Keys.Down) && (humano.y < Window.ClientBounds.Height-210))
                {
                    humano.moverY(2);
                }
                if (k.Equals(Keys.Right) && (humano.x < Window.ClientBounds.Width-130))
                {
                    humano.moverX(2);
                }
                if (k.Equals(Keys.Left) && (humano.x >= 0))
                {
                    humano.moverX(-2);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Background_img, Background, Color.White);
            spriteBatch.Draw(jogador_img, humano.getVector(), Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
