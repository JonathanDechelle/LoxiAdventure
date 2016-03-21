using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant a lire les animations 
    /// </summary>
    public struct AnimationPlayer
    {
        public float m_Rotation;
        public int m_FrameIndex;
        public Animation m_Animation;
        private float m_Timer;

        public Vector2 Origin
        {
            get { return new Vector2(m_Animation.m_FrameWidth / 2, m_Animation.m_FrameHeight); }
        }

        public void PlayAnimation(Animation newAnimation)
        {
            if (m_Animation == newAnimation)
                return;

            m_Animation = newAnimation;
            m_FrameIndex = 0;
            m_Timer = 0;
        }

        public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet)
        {
            if (m_Animation == null)
            {
                //throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                m_Timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (m_Timer >= m_Animation.m_FrameTime)
                {
                    m_Timer -= m_Animation.m_FrameTime;
                    if (m_Animation.m_IsLooping)
                        try
                        {
                            m_FrameIndex = (m_FrameIndex + 1) % m_Animation.m_FrameCount;
                        }
                        catch
                        {
                            m_FrameIndex = 0;
                        }
                    else m_FrameIndex = Math.Min(m_FrameIndex + 1, m_Animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(m_FrameIndex * m_Animation.m_FrameWidth,
                                                 0, m_Animation.m_FrameWidth, m_Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(m_Animation.m_FrameWidth * m_Animation.m_Resize),
                (int)(m_Animation.m_FrameHeight * m_Animation.m_Resize));

                // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
                g.Draw(m_Animation.m_Texture, RecResize, Rectangle, Color.White, m_Rotation, Origin, spriteEffet, 0);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet,Color Couleur)
        {
            if (m_Animation == null)
            {
                //throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                m_Timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (m_Timer >= m_Animation.m_FrameTime)
                {
                    m_Timer -= m_Animation.m_FrameTime;
                    if (m_Animation.m_IsLooping)
                        try
                        {
                            m_FrameIndex = (m_FrameIndex + 1) % m_Animation.m_FrameCount;
                        }
                        catch
                        {
                            m_FrameIndex = 0;
                        }
                    else m_FrameIndex = Math.Min(m_FrameIndex + 1, m_Animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(m_FrameIndex * m_Animation.m_FrameWidth,
                                                 0, m_Animation.m_FrameWidth, m_Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(m_Animation.m_FrameWidth * m_Animation.m_Resize),
                (int)(m_Animation.m_FrameHeight * m_Animation.m_Resize));

                // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
                g.Draw(m_Animation.m_Texture, RecResize, Rectangle, Couleur, m_Rotation, Origin, spriteEffet, 0);
            }
        }
        public void Draw(GameTime gametime, SpriteBatch g, Rectangle RecPosition, SpriteEffects spriteEffet)
        {
            if (m_Animation == null)
            {
              // throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                m_Timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (m_Timer >= m_Animation.m_FrameTime)
                {
                    m_Timer -= m_Animation.m_FrameTime;
                    if (m_Animation.m_IsLooping)
                        try
                        {
                            m_FrameIndex = (m_FrameIndex + 1) % m_Animation.m_FrameCount;
                        }
                        catch
                        {
                            m_FrameIndex = 0;
                        }
                    else m_FrameIndex = Math.Min(m_FrameIndex + 1, m_Animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(m_FrameIndex * m_Animation.m_FrameWidth,
                                                 0, m_Animation.m_FrameWidth, m_Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle(RecPosition.X, RecPosition.Y, (int)m_Animation.m_FrameWidth * (RecPosition.Height / m_Animation.m_FrameWidth), (int)m_Animation.m_FrameWidth * (RecPosition.Height / m_Animation.m_FrameWidth));
                g.Draw(m_Animation.m_Texture, RecResize, Rectangle, Color.White, m_Rotation, Origin, spriteEffet, 0);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet,float Rotation)
        {
            if (m_Animation == null)
            {
                //throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                m_Timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (m_Timer >= m_Animation.m_FrameTime)
                {
                    m_Timer -= m_Animation.m_FrameTime;
                    if (m_Animation.m_IsLooping)
                        try
                        {
                            m_FrameIndex = (m_FrameIndex + 1) % m_Animation.m_FrameCount;
                        }
                        catch
                        {
                            m_FrameIndex = 0;
                        }
                    else m_FrameIndex = Math.Min(m_FrameIndex + 1, m_Animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(m_FrameIndex * m_Animation.m_FrameWidth,
                                                 0, m_Animation.m_FrameWidth, m_Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(m_Animation.m_FrameWidth * m_Animation.m_Resize),
                (int)(m_Animation.m_FrameHeight * m_Animation.m_Resize));

                g.Draw(m_Animation.m_Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
            }
        }
        }
    }

