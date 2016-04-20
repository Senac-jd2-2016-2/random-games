using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Cooperation_Pixel
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            //(x,y,largura,altura)

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Contexto.inicializar(Content);

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

            //Movimentação do Anão
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys k in keys)
            {
                if (k.Equals(Keys.Right))
                    Contexto.Anao.moverX(2);
                
                if (k.Equals(Keys.Left))
                    Contexto.Anao.moverX(-2);
            }
            //Movimentação do Viking
            foreach(Keys k in keys)
            {
                if (k.Equals(Keys.D))
                    Contexto.Viking.moverX(2);

                if (k.Equals(Keys.A))
                    Contexto.Viking.moverX(-2);
            }




            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Contexto.background, new Rectangle(0, 0, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height), Color.White);

            spriteBatch.Draw(Contexto.Anao.texture, Contexto.Anao.GetRectangle(), Color.White);

            spriteBatch.Draw(Contexto.Viking.texture, Contexto.Viking.GetRectangle(), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
