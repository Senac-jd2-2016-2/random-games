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

        Texture2D Tpersonagem, Talien, Ttiles;
        Rectangle personagem, alien;
        Rectangle tiles, tiles1, tiles2;
        bool mov, mov2;

        //salto
        float gravidade;
        bool pulando;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            personagem = new Rectangle(80, 400, 80, 80);
            alien = new Rectangle(0, 320, 80, 160);
            //(x,y,largura,altura)
            tiles = new Rectangle(400, 320, 400, 80);
            tiles1 = new Rectangle(0, 159, 250, 80);
            tiles2 = new Rectangle(600, 80, 200, 80);

            mov = true;
            mov2 = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Tpersonagem = Content.Load<Texture2D>("Anao");
            Talien = Content.Load<Texture2D>("Viking");
            Ttiles = Content.Load<Texture2D>("tiles");

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //recebendo  a gravidade
            personagem.Y += (int)gravidade;

            if ((personagem.Intersects(tiles)) || (personagem.Intersects(tiles1)) || (personagem.Intersects(tiles2)))
            {
                gravidade = -5;
            }


            // TODO: Add your update logic here

            //movimentação do humano
            if ((Keyboard.GetState().IsKeyDown(Keys.Left)) && (mov == true))
            {
                if (personagem.X > 0)
                {
                    personagem.X -= 5;
                }
                if (personagem.X == 0)
                {
                    personagem.X = 1;
                }
                if ((personagem.Intersects(tiles)) || (personagem.Intersects(tiles1)) || (personagem.Intersects(tiles2)))
                {
                    mov = false;
                    personagem.X += 5;
                    if (mov == false)
                        mov = true;
                }
                else
                    mov = true;
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.Right)) && (mov == true))
            {
                if (personagem.X < Window.ClientBounds.Width - 80)
                {
                    personagem.X += 5;
                }
                if ((personagem.Intersects(tiles)) || (personagem.Intersects(tiles1)) || (personagem.Intersects(tiles2)))
                {
                    mov = false;
                    personagem.X -= 5;
                    if (mov == false)
                        mov = true;
                }
                else
                    mov = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !pulando)
            {
                pulando = true;
                gravidade = -20;
            }
            if (pulando)
            {
                gravidade++;
            }
            //movimentação do alien
            if ((Keyboard.GetState().IsKeyDown(Keys.A)) && (mov2 == true))
            {
                if (alien.X > 0)
                {
                    alien.X -= 5;
                }
                if (alien.X == 0)
                {
                    alien.X = 1;
                }
                if ((alien.Intersects(tiles)) || (alien.Intersects(tiles1)) || (alien.Intersects(tiles2)))
                {
                    mov2 = false;
                    alien.X += 5;
                    if (mov2 == false)
                        mov2 = true;
                }
                else
                    mov2 = true;
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.D)) && (mov2 == true))
            {
                if (alien.X < Window.ClientBounds.Width - 40)
                {
                    alien.X += 5;
                }
                if ((alien.Intersects(tiles)) || (alien.Intersects(tiles1)) || (alien.Intersects(tiles2)))
                {
                    mov2 = false;
                    alien.X -= 5;
                    if (mov2 == false)
                        mov2 = true;
                }
                else
                    mov2 = true;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Ttiles, tiles, Color.White);
            spriteBatch.Draw(Ttiles, tiles1, Color.White);
            spriteBatch.Draw(Ttiles, tiles2, Color.White);

            spriteBatch.Draw(Tpersonagem, personagem, Color.White);
            spriteBatch.Draw(Talien, alien, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
