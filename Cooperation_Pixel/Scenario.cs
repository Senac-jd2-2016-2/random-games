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
        public List<Tile> list;     //cada caracter da matriz será armazenado nesta lista
        public Texture2D background;
        int linelist, columlist;         //para percorrer as linhas e colunas da matriz
        StreamReader reader;         //leitor do arquivos .txt onde está a matriz da fase
        Rectangle back;         //retângulo para armazenar a tela toda, será o retangulo do background
            
        public void Initialize(string source, int size, int backWidth, int backHeigth)
        {
            list = new List<Tile>();
            back = new Rectangle(0, 0, backWidth, backHeigth);

            //LENDO A MATRIZ DO ARQUIVO DE TEXTO
            reader = new StreamReader(source);
            string line;
            Tile novo;
            linelist = 0;
            while ((line = reader.ReadLine()) != null)      //enquanto a linha do arquivo for diferente de NULL
            {
                columlist = 0;
                foreach (char item in line)     //para cada caracter da linha
                {
                    novo = new Tile();
                    switch (item)
                    {
                        case '0':
                            novo.type = TileType.PASSABLE;      //se o caracter for 0 é um tile do tipo passável
                            break;
                        case '1':
                            novo.type = TileType.NOT_PASSABLE;      //se o caracter for 1 é um tile do tipo não passável
                            break;
                    }
                    novo.Position = new Rectangle(columlist * size, linelist * size, size, size);       //setando a posição de cada tile na tela
                    columlist++;
                    list.Add(novo);     //adicionando o tile na lista
                }
                linelist++;
            }
        }

        public void LoadContent(ContentManager Content, string[] values)
        {
            //carregando as imagens para cada tipo de tile
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].type == TileType.PASSABLE)
                    list[i].img = Content.Load<Texture2D>(values[0]);
                else
                    list[i].img = Content.Load<Texture2D>(values[1]);
            }
            //carregando a img do background
            background = Content.Load<Texture2D>(values[2]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //desenhando o background
            spriteBatch.Draw(background, back, Color.White);
            //desenhando os tiles do tipo não passável
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].type == TileType.NOT_PASSABLE)
                    spriteBatch.Draw(list[i].img, list[i].Position, Color.White);
            }
            
        }

    }
}
