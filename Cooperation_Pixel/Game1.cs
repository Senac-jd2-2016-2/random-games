﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cooperation_Pixel
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Stage1 stage1;
        Stage2 stage2;
        Rectangle wallpaper;
        Texture2D img_wallpaper;
        bool fase1, fase2, creditos;
        SpriteFont timer;
        int contador;
        int time;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            //Colocando o game em Tela cheia
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            fase1 = false;
            creditos = false;
            fase2 = false;
            wallpaper = new Rectangle(0, 0, 800, 600);
            contador = 0;
            time = 0;
            stage1 = new Stage1();
            stage2 = new Stage2();
            stage1.Initialize(graphics);
            stage2.Initialize(graphics);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            stage1.Load(Content);
            stage2.Load(Content);
            img_wallpaper = Content.Load<Texture2D>("Wallpaper");
            timer = Content.Load<SpriteFont>("Fonte1");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }
        public void contartempo(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;

            if (time > 1000)
            {
                contador++;
                time = 0;
            }

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                fase1 = true;
            if (Keyboard.GetState().IsKeyDown(Keys.C))
                creditos = true;

            if (fase1)
            {
                stage1.Update(gameTime);
                contartempo(gameTime);
            }
            if (fase2)
            {
                stage2.Update(gameTime);
                contartempo(gameTime);
            }
            if (stage1.ativa == false)
            {
                fase1 = false;
                fase2 = true;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (!fase1)
            {
                spriteBatch.Draw(img_wallpaper, wallpaper, Color.White);
                spriteBatch.DrawString(timer, "Enter - Jogar", new Vector2(30, 50), Color.White);
                spriteBatch.DrawString(timer, "C - Creditos", new Vector2(570, 50), Color.White);
            }
            if (creditos)
            {
                spriteBatch.Draw(img_wallpaper, wallpaper, Color.White);
                spriteBatch.DrawString(timer, "Cassio Martins - Programacao, Roteiro e Level Design", new Vector2(20, 50), Color.White);
                spriteBatch.DrawString(timer, "Lucas Adriano - Roteiro e Game Design", new Vector2(120, 100), Color.White);
            }

            if (fase1)
            {
                stage1.Draw(spriteBatch);
                spriteBatch.DrawString(timer, "Fase 1", new Vector2(10, 0), Color.White);
                spriteBatch.DrawString(timer, "Time:" + contador, new Vector2(350, 0), Color.White);
            }
            if (fase2)
            {
                stage2.Draw(spriteBatch);
                spriteBatch.DrawString(timer, "Fase 2", new Vector2(10, 0), Color.White);
                spriteBatch.DrawString(timer, "Time:" + contador, new Vector2(350, 0), Color.White);
            }
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
