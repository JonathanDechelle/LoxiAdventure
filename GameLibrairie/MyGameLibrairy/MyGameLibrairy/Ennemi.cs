using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant à créer un ennemi
    /// </summary>
    public class Ennemi
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Speed;

        public bool isVisible = true;

        Random random = new Random();
        int randX, randY;

        //Bullets 
        List<Bullets> bullets = new List<Bullets>();
        Texture2D BulletsTexture;

        public Ennemi(Texture2D Texture, Vector2 Position, Texture2D BulletsTexture)
        {
            this.Texture = Texture;
            this.Position = Position;
            randY = random.Next(-4, 4);
            randX = random.Next(-4, -1);
            Speed = new Vector2(randX, randY);
            this.BulletsTexture = BulletsTexture;
        }

        float Shoot = 0;
        public void Update(GraphicsDevice graphics,GameTime gametime)
        {
            Position += Speed;
            if (Position.Y >= 0 || Position.Y <= graphics.Viewport.Height - Texture.Height)
            {
                Speed.Y = -Speed.Y;
            }

            if (Position.X < 0 - Texture.Width)
                isVisible = false;
            
            Shoot += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (Shoot < 1)
            {
                Shoot = 0;
                ShootBullets();
            }
            UpdateBullets();
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            {
                bullet.m_Position += bullet.m_Speed;
                if (bullet.m_Position.X < 0)
                    bullet.m_IsVisible = false;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].m_IsVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }

            }
        }

        public void ShootBullets()
        {
            Bullets NewBullets = new Bullets(BulletsTexture);
            NewBullets.m_Speed.X = Speed.X - 3;
            NewBullets.m_Position = new Vector2(Position.X + NewBullets.m_Speed.X,
                                            Position.Y + (Texture.Height / 2) - (Texture.Width / 2));

            NewBullets.m_IsVisible = true;
            if (bullets.Count() < 3)
            {
                bullets.Add(NewBullets);
            }
        }

        public void Draw(SpriteBatch g)
        {
              foreach (Bullets bullet in bullets)
            {
                bullet.Draw(g);
            }
            g.Draw(Texture, Position, Color.White);
        }
    }
}
