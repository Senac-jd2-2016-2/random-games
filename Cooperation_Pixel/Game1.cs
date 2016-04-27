using Microsoft.Xna.Framework;
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
        //Variáveis
        List<tile> listaTile = new List<tile>();    //Lista para armazenar os tiles
        StreamReader sr;    //variável para ler arquivo
        int linha, coluna;
        Texture2D chao, fundo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Colocando o game em Tela cheia
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            //(x,y,largura,altura)

            //setando o arquivo de textos
            sr = new StreamReader("arq.txt");
            string L;
            linha = 0;
            //Identidicando os caracteres do arquivo, setando seu tipo, sua posição e armazenando na lista
            while ((L = sr.ReadLine()) != null) //se a linha do arquivo for diferente de NULL
            {
                coluna = 0;
                tile novo;
                foreach(char item in L)   //para cada caractere da linha
                {
                    novo = new tile();
                    if (item.Equals('0')){
                        novo.tipo = tipoTile.fundo;
                    }
                    if (item.Equals("1"))
                    {
                        novo.tipo = tipoTile.chao;
                    }
                    novo.position = new Rectangle(coluna * 80, linha * 80, 80, 80);
                    listaTile.Add(novo);
                    coluna++;
                }
                linha++;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Contexto.inicializar(Content);
            fundo = Content.Load<Texture2D>("tile");
            chao = Content.Load<Texture2D>("tile");

            //Carregando as imagens nos itens da lista de acordo com o seu tipo
            for (int i = 0; i < listaTile.Count; i++)
            {
                if (listaTile[i].tipo.Equals(tipoTile.fundo))
                {
                    listaTile[i].img = fundo;
                }
                else
                    listaTile[i].img = fundo;
            }

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

            //Desenhando os tiles do tipo chao
            for (int i = 0; i < listaTile.Count; i++)
            {
                if (listaTile[i].tipo.Equals(tipoTile.chao))
                {
                    spriteBatch.Draw(listaTile[i].img, listaTile[i].position, Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
