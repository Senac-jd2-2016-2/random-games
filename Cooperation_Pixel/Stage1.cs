﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Stage1
    {
        public bool ativa;      //indica se a fase está ativa
        public Control controlador;   //criando um controle para a fase
        int qtd = 4;    //quantidade de inimigos na fase
        int size = 30;      //tamanho dos tiles

        // Para salvar a posição do personagem
        //StreamReader reader;
        //string line;
        //string[] num;
        //int[] aux;


        public void Initialize(GraphicsDeviceManager graphics)
        {
            controlador = new Control();
            Rectangle posD;
            Rectangle posV;

            //Para salvar a posição do personagem
            // Para salvar a posição do personagem
            //reader = new StreamReader("save.txt");
            //while ((line = reader.ReadLine()) != null)
            //{
                //num = line.Split('|');
                //aux = new int[4];
                //for (int i = 0; i < num.Length; i++)
                //{
                //    aux[i] = int.Parse(num[i]);
                //}
            //}
            //reader.Close();

            //INICIAR ANÃO
            //posD = new Rectangle(aux[0], aux[1], 40, 40);
            posD = new Rectangle(636, 170, 35, 35);

            //INICIAR VIKING
            //posV = new Rectangle(aux[2], aux[3], 40, 80);
            posV = new Rectangle(76, 130, 40, 60);

            //Anão
            int velD = 4;
            int lifeD = 1;
            //Viking
            int velV = 4;
            int lifeV = 1;

            //INICIAR INIMIGOS
            string source = "fase1.txt";        //arquivo onde estará descrita a matriz da fase
            qtd = 2;        //quantidade de inimigos
            Rectangle[] positionsE = new Rectangle[qtd];
            positionsE[0] = new Rectangle(400, 175, 35, 35);
            positionsE[1] = new Rectangle(380, 535, 35, 35);

            int[] velocityE = new int[qtd];
            velocityE[0] = 5;
            velocityE[1] = 5;

            int[] lifeE = new int[qtd];
            for (int i = 0; i < lifeE.Length; i++)
            {
                lifeE[i] = 2;
            }

            //fase ativa 
            ativa = true;

            //Chamar o método de inicialização da fase
            controlador.Initialize(posD, lifeD, velD, posV, lifeV, velV, source, size, positionsE, lifeE, velocityE, qtd, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }
        public void Load(ContentManager Content)
        {
            //CARREGAR ANÃO
            string[] valueD = new string[2];
            valueD[0] = "Anão_1";
            valueD[1] = "colid";

            //CARREGAR VIKING
            string[] valueV = new string[2];
            valueV[0] = "Viking";
            valueV[1] = "colid";

            //CARREGAR CENARIO
            string[] valuesFase = new string[4];
            valuesFase[0] = "tile";
            valuesFase[1] = "tile";
            valuesFase[2] = "BackGround";
            valuesFase[3] = "Gota";

            //CARREGAR INIMIGO
            string valueEnemye = "Gota";

            //chamar o método responsável por carregar os arquivos da fase
            controlador.Load(Content, valueD, valueV, valuesFase, valueEnemye);
        }
        public void Update(GameTime gameTime)
        {
            //Atualizando a fase
            if (controlador.faseativa == false)
                ativa = false;
            controlador.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBacth)
        {
            //Desenhando a fase
            controlador.Draw(spriteBacth);
        }

        
    }
}
