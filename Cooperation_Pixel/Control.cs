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

        bool validaV = false;
        bool validaVH = false;
        
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

            bool validaD;      //variáveis para detectar colisão

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
            ////aplicando gravidade
            //validaV = collider.colliderBot(Viking, stage);
            //if (!validaV)
            //    Viking.Gravidade();

            Viking.Update_MovimentoV(gametime);
            //Gravidade


            validaV = false;
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (Viking.colisor.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.NOT_PASSABLE)
                {
                    validaV = true;
                    Viking.Position = new Rectangle(Viking.Position.X, stage.scenario.list[i].Position.Y - (stage.scenario.list[i].Position.Height / 2) - Viking.Position.Height / 2 - 5, Viking.Position.Width, Viking.Position.Height);
                    Viking.Mov_Y = 0;
                    Viking.forca_pulo = 0;
                    break;
                }
            }

            if (!validaV)
            {
                Viking.Mov_Y += gravidade - Viking.forca_pulo;
                Viking.forca_pulo -= gravidade;
                //gravidade += 1;

            }

            //MOVIMENTANDO O ANÃO
            //Movimentado para esquerda
            if (Dwarf.State_Dwarf == StatePlayer.RUNLEFT)     
            {
                validaD = false;
                for (int i = 0; i < stage.scenario.list.Count; i++)
                {
                    if (Dwarf.colisor.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.NOT_PASSABLE)
                        validaD = true;
                }
                //validaV = collider.colliderBot(Viking, stage);
                if (validaD == false)
                    Dwarf.Position.X -= Dwarf.velocity;
                    
            }
            //Movimentado para direita
            else if (Dwarf.State_Dwarf == StatePlayer.RUNRIGHT)      
            {
                validaD = false;
                for (int i = 0; i < stage.scenario.list.Count; i++)
                {
                    if (Dwarf.colisor.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.NOT_PASSABLE)
                        validaD = true;
                }
                //validaV = collider.colliderBot(Viking, stage);
                if (validaD == false)
                    Dwarf.Position.X += Dwarf.velocity;
            }
            //Salto do anão
            else if (Dwarf.State_Dwarf == StatePlayer.JUMP)          
            {
                
                //Dwarf.hasjumped = true;
                //validaD = collider.colliderTop(Dwarf, stage);
                //if (!validaD)
                //    Dwarf.Update_MovimentoD(gametime, validaD);
            }
            //Anão parado
            if (Dwarf.State_Dwarf == StatePlayer.IDDLE)        
            {
                validaD = collider.colliderBot(Dwarf, stage);
                if(!validaD)
                    Dwarf.Gravidade();
            }

            //MOVIMENTANDO O VIKING
            //Movimentado para esquerda
            if (Viking.State_Viking == StatePlayer.RUNLEFT)
            {
                validaVH = false;
                for (int i = 0; i < stage.scenario.list.Count; i++)
                {
                    if (Viking.colisor.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.NOT_PASSABLE)
                        validaVH = true;
                }
                //validaVH = collider.colliderBot(Viking, stage);
                if (validaVH == false)
                    Viking.Position.X -= Viking.velocity;
            }
            //Movimentado para direita
            else if (Viking.State_Viking == StatePlayer.RUNRIGHT)
            {
                validaVH = false;
                for (int i = 0; i < stage.scenario.list.Count; i++)
                {
                    if (Viking.colisor.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.NOT_PASSABLE)
                        validaVH = true;
                }
                //validaVH = collider.colliderBot(Viking, stage);
                if (validaVH == false)
                    Viking.Position.X += Viking.velocity;
            }
            //Salto do anão
            else if (Viking.State_Viking == StatePlayer.JUMP)
            {
                Viking.forca_pulo = 2;

                //Viking.hasjumped = true;
                //validaV = collider.colliderTop(Viking, stage);
                //if (!validaV)
                //    Viking.Update_MovimentoV(validaV);
            }
            ////Anão parado
            //if (Viking.State_Viking == StatePlayer.IDDLE)
            //{
            //    validaV = collider.colliderBot(Viking, stage);
            //    if (!validaV)
            //        Viking.Gravidade();
            //}



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
            Dwarf.Draw(spriteBatch);
            Viking.Draw(spriteBatch);
        }

    }
}
