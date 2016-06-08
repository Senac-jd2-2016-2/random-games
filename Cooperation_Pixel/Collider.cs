using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Collider
    {
        public bool colliderTop(Character Personagem, Stage stage)
        {
            //detectando colisão do personagem com a fase
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (Personagem.position_Top.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.PASSABLE)
                    return false;
            }
            return true;
        }
        public bool colliderLeft(Character Personagem, Stage stage)
        {
            //detectando colisão do personagem com a fase
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (Personagem.position_Left.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.PASSABLE)
                    return false;
            }
            return true;
        }
        public bool colliderRight(Character Personagem, Stage stage)
        {
            //detectando colisão do personagem com a fase
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (Personagem.position_Right.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.PASSABLE)
                    return false;
            }
            return true;
        }
        public bool colliderBot(Character Personagem, Stage stage)
        {
            //detectando colisão do personagem com a fase
            for (int i = 0; i < stage.scenario.list.Count; i++)
            {
                if (Personagem.position_Bot.Intersects(stage.scenario.list[i].Position) && stage.scenario.list[i].type == TileType.PASSABLE)
                    return false;
                
            }
            return true;
        }


    }
}
