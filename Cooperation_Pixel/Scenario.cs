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
    public class Scenario
    {
        public List<Tile> list;
        public Texture2D background;
        //public abstract Rectangle ClientBounds { get; }
        int linelist, columlist;
        StreamReader reader;


        Rectangle back;

        public void Initialize(string source, int size, int backWidth, int backHeigth)
        {
            list = new List<Tile>();

            back = new Rectangle(0, 0, backWidth, backHeigth);

            reader = new StreamReader(source);
            string line;
            Tile novo;
            linelist = 0;
            while ((line = reader.ReadLine()) != null)
            {
                columlist = 0;
                foreach (char item in line)
                {
                    novo = new Tile();
                    switch (item)
                    {
                        case '0':
                            novo.type = TileType.PASSABLE;
                            break;
                        case '1':
                            novo.type = TileType.NOT_PASSABLE;
                            break;
                    }
                    novo.Position = new Rectangle(columlist * size, linelist * size, size, size);
                    columlist++;
                    list.Add(novo);
                }
                linelist++;
            }
        }

        public void LoadContent(ContentManager Content, string[] values)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].type == TileType.PASSABLE)
                    list[i].img = Content.Load<Texture2D>(values[0]);
                else
                    list[i].img = Content.Load<Texture2D>(values[1]);
            }
            background = Content.Load<Texture2D>(values[2]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(background, back, Color.White);
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].type == TileType.NOT_PASSABLE)
                    spriteBatch.Draw(list[i].img, list[i].Position, Color.White);
            }
        }

    }
}
