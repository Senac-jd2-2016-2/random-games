using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    class Stage2
    {
        public bool ativa;      //indica se a fase está ativa
        public Control controlador;   //criando um controle para a fase
        int qtd = 4;    //quantidade de inimigos na fase
        int size = 30;      //tamanho dos tiles

        public void Initialize(GraphicsDeviceManager graphics)
        {
            controlador = new Control();
            Rectangle posD;
            Rectangle posV;

            //INICIAR ANÃO
            posD = new Rectangle(636, 170, 35, 35);

            //INICIAR VIKING
            posV = new Rectangle(76, 130, 40, 60);

            //Anão
            int velD = 4;
            int lifeD = 1;
            //Viking
            int velV = 4;
            int lifeV = 1;

            //INICIAR INIMIGOS
            string source = "fase2.txt";        //arquivo onde estará descrita a matriz da fase
            qtd = 4;        //quantidade de inimigos
            Rectangle[] positionsE = new Rectangle[qtd];
            positionsE[0] = new Rectangle(0, 175, 35, 35);
            positionsE[1] = new Rectangle(0, 415, 35, 35);
            positionsE[2] = new Rectangle(750, 175, 35, 35);
            positionsE[3] = new Rectangle(750, 415, 35, 35);

            int[] velocityE = new int[qtd];
            velocityE[0] = 4;
            velocityE[1] = 3;
            velocityE[2] = 5;
            velocityE[3] = 7;

            int[] lifeE = new int[qtd];
            for (int i = 0; i < lifeE.Length; i++)
            {
                lifeE[i] = 2;
            }
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
