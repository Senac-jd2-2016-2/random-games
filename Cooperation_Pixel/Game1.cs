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

        Texture2D Tpersonagem, Talien, Ttiles, Tbackground;
        Rectangle anao, viking, backgorund;
        bool mov, mov2;
        Rectangle[] tiles, tiles1, tiles2;

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
            anao = new Rectangle(80, 400, 80, 80);
            viking = new Rectangle(400, 0, 80, 159);
            backgorund = new Rectangle(0, 0, Window.ClientBounds.Width+200, Window.ClientBounds.Height+100);
            //(x,y,largura,altura)
            tiles = new Rectangle[10];
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Rectangle(400+(i*100), 320, 100, 80);//Iniciando os vetores do piso inferior multiplicando sua posição X para que não sejam desenhados na mesma posição e sim um na frente do outro
            }
            tiles1 = new Rectangle[3];
            for (int i = 0; i < tiles1.Length; i++)
            {
                tiles1[i] = new Rectangle(0 + (i * 100), 159, 100, 80);
            }
            tiles2 = new Rectangle[3];
            for (int i = 0; i < tiles1.Length; i++)
            {
                tiles2[i] = new Rectangle(600 + (i * 100), 80, 100, 80);
            }

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
            Ttiles = Content.Load<Texture2D>("tile");
            Tbackground = Content.Load<Texture2D>("background");

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
            anao.Y += (int)gravidade;
            for (int i = 0; i < tiles1.Length; i++)
            {
                while ((anao.Intersects(tiles[i])) || (anao.Intersects(tiles1[i])) || (anao.Intersects(tiles2[i])) || (anao.Y > Window.ClientBounds.Height - 80))
                {
                    gravidade--;
                    anao.Y--;
                    pulando = false;
                } 
            }



            // TODO: Add your update logic here

            //movimentação do Anão
            if ((Keyboard.GetState().IsKeyDown(Keys.Left)) && (mov == true))
            {
                if (anao.X > 0)
                {
                    anao.X -= 5;
                }
                if (anao.X == 0)
                {
                    anao.X = 1;
                }
                for (int i = 0; i < tiles1.Length; i++)
                {
                    if ((anao.Intersects(tiles[i])) || (anao.Intersects(tiles1[i])) || (anao.Intersects(tiles2[i])))
                    {
                        mov = false;
                        anao.X += 5;
                        if (mov == false)
                            mov = true;
                    }
                    else
                        mov = true;
                }
            }
            else if ((Keyboard.GetState().IsKeyDown(Keys.Right)) && (mov == true))
            {
                for (int i = 0; i < tiles1.Length; i++)
                {
                    if (anao.X < Window.ClientBounds.Width - 80)
                    {
                        anao.X += 2;
                    }
                    if ((anao.Intersects(tiles[i])) || (anao.Intersects(tiles1[i])) || (anao.Intersects(tiles2[i])))
                    {
                        mov = false;
                        anao.X -= 5;
                        if (mov == false)
                            mov = true;
                    }
                    else
                        mov = true;
                }
            }
            //salto
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && !pulando)
            {
                pulando = true;
                gravidade = -20;
            }
            if (pulando)
            {
                gravidade++;
            }
            //movimentação do Viking
            if ((Keyboard.GetState().IsKeyDown(Keys.A)) && (mov2 == true))
            {
                if (viking.X > 0)
                {
                    viking.X -= 5;
                }
                if (viking.X == 0)
                {
                    viking.X = 1;
                }
                for (int i = 0; i < tiles.Length; i++)
                {
                    if ((viking.Intersects(tiles[i])))
                    {
                        mov2 = false;
                        viking.X += 5;
                        if (mov2 == false)
                            mov2 = true;
                    }
                    else
                        mov2 = true;
                }
                for (int i = 0; i < tiles1.Length; i++)
                {
                    if ((viking.Intersects(tiles1[i])) || (viking.Intersects(tiles2[i])))
                    {
                        mov2 = false;
                        viking.X += 5;
                        if (mov2 == false)
                            mov2 = true;
                    }
                    else
                        mov2 = true;
                }
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.D)) && (mov2 == true))
            {
                if (viking.X < Window.ClientBounds.Width - 40)
                {
                    viking.X += 5;
                }
                for (int i = 0; i < tiles1.Length; i++)
                {
                    if ((viking.Intersects(tiles[i])) || (viking.Intersects(tiles1[i])) || (viking.Intersects(tiles2[i])))
                    {
                        mov2 = false;
                        viking.X -= 5;
                        if (mov2 == false)
                            mov2 = true;
                    }
                    else
                        mov2 = true;
                }
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(Tbackground, backgorund, Color.DarkGray);
            for (int i = 0; i < tiles.Length; i++)
            {
                spriteBatch.Draw(Ttiles, tiles[i], Color.White);
            }
            for (int i = 0; i < tiles1.Length; i++)
            {
                spriteBatch.Draw(Ttiles, tiles1[i], Color.White);
            }
            for (int i = 0; i < tiles1.Length; i++)
            {
                spriteBatch.Draw(Ttiles, tiles2[i], Color.White);
            }

            spriteBatch.Draw(Tpersonagem, anao, Color.White);
            spriteBatch.Draw(Talien, viking, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
