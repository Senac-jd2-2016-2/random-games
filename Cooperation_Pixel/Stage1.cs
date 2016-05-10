using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Stage1
    {
        public bool ativa;
        public Control stage;
        int qtd = 4;
        int size = 64;

        public void Initialize(GraphicsDeviceManager graphics)
        {
            stage = new Control();

            //INICIAR ANÃO
            Rectangle posD = new Rectangle(500, 180, 80, 80);
            int velD = 6;
            int lifeD = 1;

            //INICIAR VIKING
            Rectangle posV = new Rectangle(700, 100, 80, 160);
            int velV = 3;
            int lifeV = 1;

            //INICIAR INIMIGOS
            string source = "fase1.txt";
            qtd = 4;
            Rectangle[] positionsE = new Rectangle[qtd];
            positionsE[0] = new Rectangle(10, 195, 65, 65);
            positionsE[1] = new Rectangle(1800, 450, 65, 65);
            positionsE[2] = new Rectangle(10, 705, 65, 65);
            positionsE[3] = new Rectangle(1800, 960, 65, 65);

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
            //INICIAR CENARIO
            stage.Initialize(posD, lifeD, velD, posV, lifeV, velV, source, size, positionsE, lifeE, velocityE, qtd, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }
        public void Load(ContentManager Content)
        {
            //CARREGAR ANÃO
            string valueD = "Anao";

            //CARREGAR VIKING
            string valueV = "Viking";

            //CARREGAR CENARIO
            string[] valuesFase = new string[3];
            valuesFase[0] = "tile";
            valuesFase[1] = "tile";
            valuesFase[2] = "BackGround";

            string valueEnemye = "Anao";

            stage.Load(Content, valueD, valueV, valuesFase, valueEnemye);
        }
        public void Update(GameTime gameTime)
        {
            stage.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBacth)
        {
            stage.Draw(spriteBacth);
        }

        
    }
}
