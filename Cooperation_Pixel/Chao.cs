using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    class Chao
    {
        public Texture2D Texture;
        public Rectangle Rectangle {get; protected set; }

        public static ContentManager Content { protected get; set; }

        public void Drawn(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }

    }
}
