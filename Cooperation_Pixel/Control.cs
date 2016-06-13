
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
        public int gravidade = 1;
        int contador_agua = 0;
        SpriteFont fonte;
        Texture2D img_porta;
        Rectangle porta;

        //variáveis para detectar colisão
        bool validaV = false;
        bool validaD = false;

        //StreamWriter writer;

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
            porta = new Rectangle(10, 498, 50, 75);
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
            fonte = Content.Load<SpriteFont>("Fonte1");
            img_porta = Content.Load<Texture2D>("porta");
        }

        public void Update(GameTime gametime)
        {
            collider = new Collider();
            //atualizando tudo
            Dwarf.Update(gametime);
            Viking.Update(gametime);

            //Movimentando o anão apenas dentro dos limites da tela
            if (Dwarf.Position.X > 760)
                Dwarf.Position.X = 760;
            if(Dwarf.Position.X < 0)
                Dwarf.Position.X = 0;
            if (Dwarf.Position.Y > 600)
                Dwarf.Position.Y = 600;
            //Movimentando o viking apenas dentro dos limites da tela
            if (Viking.Position.X > 760)
                Viking.Position.X = 760;
            if (Viking.Position.X < 0)
                Viking.Position.X = 0;
            if (Viking.Position.Y > 600)
                Viking.Position.Y = 600;

            //aplicando gravidade
            validaD = collider.colliderBot(Dwarf, stage);
            if (!validaD)
                Dwarf.Gravidade();
            //aplicando gravidade
            validaV = collider.colliderBot(Viking, stage);
            if (!validaV)
                Viking.Gravidade();

            //MOVIMENTANDO O ANÃO
            //Movimentado para esquerda
            if (Dwarf.State_Dwarf == StatePlayer.RUNLEFT)
            {
                validaD = collider.colliderBot(Dwarf, stage);
                Dwarf.Update_MovimentoD(gametime, validaD);

            }
            //Movimentado para direita
            else if (Dwarf.State_Dwarf == StatePlayer.RUNRIGHT)
            {
                validaD = collider.colliderBot(Dwarf, stage);
                Dwarf.Update_MovimentoD(gametime, validaD);
            }
            //Salto do anão
            else if (Dwarf.State_Dwarf == StatePlayer.JUMP)
            {
                Dwarf.hasjumped = true;
                validaD = collider.colliderTop(Dwarf, stage);
                //if (!validaD)
                    Dwarf.Update_MovimentoD(gametime, validaD);
            }

            //MOVIMENTANDO O VIKING
            //Movimentado para esquerda
            if (Viking.State_Viking == StatePlayer.RUNLEFT)
            {
                validaV = collider.colliderBot(Viking, stage);
                Viking.Update_MovimentoV(gametime, validaV);
            }
            //Movimentado para direita
            else if (Viking.State_Viking == StatePlayer.RUNRIGHT)
            {
                validaV = collider.colliderBot(Viking, stage);
                Viking.Update_MovimentoV(gametime, validaV);
            }
            //Salto do anão
            else if (Viking.State_Viking == StatePlayer.JUMP)
            {
                Viking.hasjumped = true;
                validaV = collider.colliderTop(Viking, stage);
                if (!validaV)
                    Viking.Update_MovimentoV(gametime, validaV);
            }

            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (Dwarf.Position.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.WATER)
                {
                    stage.scenario.list.RemoveAt(i);
                    contador_agua += 1;
                }

                if (Viking.Position.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.WATER)
                {
                    stage.scenario.list.RemoveAt(i);
                    contador_agua += 1;
                }

            }

            //atualizando inimigos
            for (int i = 0; i < qtdeenemyes; i++)
            {
                enemyes[i].Update(gametime);
            }

            ////SAVE GAME
            //if (Keyboard.GetState().IsKeyDown(Keys.P))
            //{
            //    writer = new StreamWriter("save.txt");
            //    writer.Write(Dwarf.Position.X + "|" + Dwarf.Position.Y + "|" + Viking.Position.X + "|" + Viking.Position.Y);

            //    writer.Close();
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //desenhando tudo
            stage.Draw(spriteBatch);
            //for (int i = 0; i < qtdeenemyes; i++)
            //{
            //    enemyes[i].Draw(spriteBatch);
            //}
            spriteBatch.DrawString(fonte, "Pontos:" + contador_agua, new Vector2(590, 0), Color.White);
            spriteBatch.DrawString(fonte, "Fase 1", new Vector2(10, 0), Color.White);
            //if (contador_agua >= 3)
                spriteBatch.Draw(img_porta, porta, Color.White);
            Dwarf.Draw(spriteBatch);
            Viking.Draw(spriteBatch);
        }

    }
}
