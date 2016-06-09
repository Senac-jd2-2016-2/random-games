using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Character
    {
        //atributos dos personagens
        public Rectangle Position;
        public int velocity;
        public Texture2D img;
        public int life;
        public Rectangle position_Left;
        public Rectangle position_Right;
        public Rectangle position_Top;
        public Rectangle position_Bot;
        public Texture2D img_colid;
        public Rectangle colisor;
        public int direcao;
        public int Mov_Y = 0;
        public int forca_pulo;

        public bool hasjumped;
        public Vector2 position_pulo;
        public Vector2 velocity_pulo;

        public void Update_MovimentoD(GameTime gametime)
        {
            //position_pulo += velocity_pulo;
            
            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //    velocity_pulo.X = 3f;
            //else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //    velocity_pulo.X = -3f;
            //else
            //    velocity_pulo.X = 0f;    

            //if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasjumped == false)
            //{
            //    position_pulo.Y -= 10f;
            //    velocity_pulo.Y = -5f;
            //    hasjumped = true;
            //}

            //if (hasjumped == true)
            //{
            //    int i = 1;
            //    velocity_pulo.Y += 0.10f * i;
            //}

            //if (collider == true)
            //{
            //    hasjumped = false;
            //}

            //if (hasjumped == false)
            //{
            //    velocity_pulo.Y = 0f;
            //} 
            Position.Y += Mov_Y;
        }

        public void Update_MovimentoV(GameTime gameTime)
        {
            Position.Y += Mov_Y;
        }

        public void Gravidade()
        {
            position_pulo.Y += 2;
            Position.Y += 2;
        }


    }

}
