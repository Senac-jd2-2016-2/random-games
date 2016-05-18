using Microsoft.Xna.Framework;
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
        public Control stage;   //criando um controle para a fase
        int qtd = 4;    //quantidade de inimigos na fase
        int size = 30;      //tamanho dos tiles


        StreamReader reader;
        //List<Vector2> positions;
        string line;
        string[] num;
        int[] aux;
        public void Initialize(GraphicsDeviceManager graphics)
        {
            stage = new Control();
            //positions = new List<Vector2>();
            Rectangle posD;
            Rectangle posV;


            reader = new StreamReader("save.txt");
            while ((line = reader.ReadLine()) != null)
            {
                num = line.Split('|');
                aux = new int[4];
                for (int i = 0; i < num.Length; i++)
                {
                    aux[i] = int.Parse(num[i]);
                }
                //Vector2 novo = new Vector2(float.Parse(num[0]), float.Parse(num[1]));
                //positions.Add(novo);
            }
            reader.Close();

            //INICIAR ANÃO
            //Rectangle posD = new Rectangle((int)positions[0].X, (int)positions[0].Y, 40, 40);
            posD = new Rectangle(aux[0], aux[1], 40, 40);


            //INICIAR VIKING
            //Rectangle posV = new Rectangle((int)positions[1].X, (int)positions[1].Y, 40, 80);
            posV = new Rectangle(aux[2], aux[3], 40, 80);
            //Anão
            int velD = 4;
            int lifeD = 1;

            //Viking
            int velV = 2;
            int lifeV = 1;

            //INICIAR INIMIGOS
            string source = "fase1.txt";        //arquivo onde estará descrita a matriz da fase
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
            //Chamar o método de inicialização da fase
            stage.Initialize(posD, lifeD, velD, posV, lifeV, velV, source, size, positionsE, lifeE, velocityE, qtd, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }
        public void Load(ContentManager Content)
        {
            //CARREGAR ANÃO
            string[] valueD = new string[2];
            valueD[0] = "Anao";
            valueD[1] = "colid";

            //CARREGAR VIKING
            string[] valueV = new string[2];
            valueV[0] = "Viking";
            valueV[1] = "colid";

            //CARREGAR CENARIO
            string[] valuesFase = new string[3];
            valuesFase[0] = "tile";
            valuesFase[1] = "tile";
            valuesFase[2] = "BackGround";

            //CARREGAR INIMIGO
            string valueEnemye = "Anao";

            //chamar o método responsável por carregar os arquivos da fase
            stage.Load(Content, valueD, valueV, valuesFase, valueEnemye);
        }
        public void Update(GameTime gameTime)
        {
            //Atualizando a fase
            stage.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBacth)
        {
            //Desenhando a fase
            stage.Draw(spriteBacth);
        }

        
    }
}
