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

        public static ContentManager Content { get; protected set; }

        public void Drawn(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }

    }
    class CollisionTiles : Chao
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            Texture = Content.Load<Texture2D>("tile"+i);
            this.Rectangle = new Rectangle();
        }
    }


}
