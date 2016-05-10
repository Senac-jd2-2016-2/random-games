using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        private void InitializeDwarf(Rectangle position, int life, int velocity)
        {
            Dwarf = new Dwarf();
            Dwarf.Position = position;
            Dwarf.life = life;
            Dwarf.velocity = velocity;
        }

        private void InitializeViking(Rectangle position, int life, int velocity)
        {
            Viking = new Viking();
            Viking.Position = position;
            Viking.life = life;
            Viking.velocity = velocity;
        }

        private void InitializeStage(string source, int size)
        {
            stage = new Stage();
            stage.Initialize(source, size);
        }

        private void InitializeEnemyes(Rectangle[] positions, int[]life, int[]velocity, int qtde)
        {
            qtdeenemyes = qtde;
            enemyes = new List<Enemy>();
            for (int i = 0; i < qtdeenemyes; i++)
            {
                enemyes.Add(new Enemy());
                enemyes[i].Initialize(positions[i], life[i], velocity[i]);

            }
        }

        public void Initialize(Rectangle positionD, int lifeD, int velocityD, Rectangle positionV, int lifeV, int velocityV, string source, int size, Rectangle[]positionE, int[] lifeE, int[] velocityE, int qtde)
        {
            InitializeDwarf(positionD, lifeD, velocityD);
            InitializeViking(positionV, lifeV, velocityV);
            InitializeStage(source, size);
            InitializeEnemyes(positionE, lifeE, velocityE, qtde);
        }

        public void LoadContent(ContentManager Content, string valueD,string valueV, string[]valuesF, string value)
        {
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
            Dwarf.Update(gametime);
            Viking.Update(gametime);

            bool validaD, validaV;
            if (Dwarf.State_Dwarf == StatePlayer.RUNLEFT)
            {
                validaD = colliderDwarf(Dwarf, stage);
                if (!validaD)
                    Dwarf.Position.X -= Dwarf.velocity;
            }
            else if (Dwarf.State_Dwarf == StatePlayer.RUNRIGHT)
            {
                validaD = colliderDwarf(Dwarf, stage);
                if (!validaD)
                    Dwarf.Position.X += Dwarf.velocity;
            }

            if (Viking.State_Viking == StatePlayer.RUNLEFT)
            {
                validaV = ColliderViking(Viking, stage);
                if (!validaV)
                    Viking.Position.X -= Viking.velocity;
            }
            else if (Viking.State_Viking == StatePlayer.RUNRIGHT)
            {
                validaV = ColliderViking(Viking, stage);
                if (!validaV)
                    Viking.Position.X += Viking.velocity;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stage.Draw(spriteBatch);
            for (int i = 0; i < qtdeenemyes; i++)
            {
                enemyes[i].Draw(spriteBatch);
            }
            Dwarf.Draw(spriteBatch);
            Viking.Draw(spriteBatch);
        }

        public bool colliderDwarf(Dwarf dwarf, Stage stage)
        {
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (dwarf.Position.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.PASSABLE)
                    return false;
            }
            return true;
        }
        public bool ColliderViking(Viking viking, Stage stage)
        {
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (viking.Position.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.PASSABLE)
                    return false;
            }
            return true;
        }

    }
}
