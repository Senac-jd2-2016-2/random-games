using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Control
    {
        public Dwarf Dwarf;
        public Viking Viking;
        public Stage stage;
        public List<Enemy> enemyes;
        public int qtdeenemyes;
        public Collider collider;
        StreamWriter writer;

        private void InitializeDwarf(Rectangle position, int life, int velocity)
        {
            //Iniciando o Anão
            Dwarf = new Dwarf();
            Dwarf.Position = position;
            Dwarf.life = life;
            Dwarf.velocity = velocity;
        }

        private void InitializeViking(Rectangle position, int life, int velocity)
        {
            //Iniciando o Viking
            Viking = new Viking();
            Viking.Position = position;
            Viking.life = life;
            Viking.velocity = velocity;
        }

        private void InitializeStage(string source, int size, int backWidth, int backHeigth)
        {
            //Iniciando a fase
            stage = new Stage();
            stage.Initialize(source, size, backWidth, backHeigth);
        }

        private void InitializeEnemyes(Rectangle[] positions, int[]life, int[]velocity, int qtde)
        {
            //Iniciando os inimigos
            qtdeenemyes = qtde;
            enemyes = new List<Enemy>();
            for (int i = 0; i < qtdeenemyes; i++)
            {
                enemyes.Add(new Enemy());
                enemyes[i].Initialize(positions[i], life[i], velocity[i]);

            }
        }

        public void Initialize(Rectangle positionD, int lifeD, int velocityD, Rectangle positionV, int lifeV, int velocityV, string source, int size, Rectangle[] positionE, int[] lifeE, int[] velocityE, int qtde, int backWidth, int backHeigth)
        {
            //Iniciando tudo
            InitializeDwarf(positionD, lifeD, velocityD);
            InitializeViking(positionV, lifeV, velocityV);
            InitializeStage(source, size, backWidth, backHeigth);
            InitializeEnemyes(positionE, lifeE, velocityE, qtde);
        }

        public void Load(ContentManager Content, string[] valueD,string[] valueV, string[]valuesF, string value)
        {
            //carregando todos os arquivos
            Dwarf.LoadContent(Content, valueD);
            Viking.LoadContent(Content, valueV);
            stage.LoadContent(Content, valuesF);
            for (int i = 0; i < qtdeenemyes; i++)
			{
                enemyes[i].LoadContent(Content, value);
			}
        }

        public void Update(GameTime gametime)
        {
            collider = new Collider();
            //atualizando tudo
            Dwarf.Update(gametime);
            Viking.Update(gametime);

            bool validaD, validaV;      //variáveis para detectar colisão

            validaD = collider.colliderBot(Dwarf, stage);
            if (!validaD)
                Dwarf.Gravidade();

            //MOVIMENTANDO O ANÃO
            if ((Dwarf.State_Dwarf == StatePlayer.RUNLEFT))     //Movimentado para esquerda
            {
                validaD = collider.colliderLeft(Dwarf, stage);
                Dwarf.Update_Movimento(gametime, validaD);
            }
            else if (Dwarf.State_Dwarf == StatePlayer.RUNRIGHT)     //Movimentado para direita
            {
                validaD = collider.colliderBot(Dwarf, stage);
                Dwarf.Update_Movimento(gametime, validaD);
            }
            else if (Dwarf.State_Dwarf == StatePlayer.JUMP)         //Salto do anão
            {
                validaD = collider.colliderTop(Dwarf, stage);
                if (!validaD)
                    Dwarf.Update_Movimento(gametime, validaD);

            }
            else if (Dwarf.State_Dwarf == StatePlayer.IDDLE)        //Anão parado
            {
                validaD = collider.colliderBot(Dwarf, stage);
                if(!validaD)
                    Dwarf.Update_Movimento(gametime, validaD);
            }

            //MOVIMENTANDO O VIKING
            if (Viking.State_Viking == StatePlayer.RUNLEFT)
            {
                validaV = collider.colliderLeft(Viking, stage);
                if (!validaV)
                    Viking.Position.X -= Viking.velocity;

            }
            else if (Viking.State_Viking == StatePlayer.RUNRIGHT)
            {
                validaV = collider.colliderRight(Viking, stage);
                if (!validaV)
                    Viking.Position.X += Viking.velocity;

            }


            //atualizando inimigos
            for (int i = 0; i < qtdeenemyes; i++)
            {
                enemyes[i].Update(gametime);
            }

            //SAVE GAME
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                writer = new StreamWriter("save.txt");
                writer.Write(Dwarf.Position.X + "|" + Dwarf.Position.Y + "|" + Viking.Position.X + "|" + Viking.Position.Y);

                writer.Close();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //desenhando tudo
            stage.Draw(spriteBatch);
            for (int i = 0; i < qtdeenemyes; i++)
            {
                enemyes[i].Draw(spriteBatch);
            }
            Dwarf.Draw(spriteBatch);
            Viking.Draw(spriteBatch);
        }

    }
}
