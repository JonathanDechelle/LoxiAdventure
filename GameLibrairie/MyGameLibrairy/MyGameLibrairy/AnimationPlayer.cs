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
        public float Rotation;

        Animation animation;
        public Animation Animation
        {
            get { return animation; }
        }

        int frameIndex;
        public int FrameIndex
        {
            get { return frameIndex; }
            set { frameIndex = value; }
        }

        private float timer;

       
        public Vector2 Origin
        {
            get { return new Vector2(animation.m_FrameWidth / 2, animation.m_FrameHeight); }
        }

        public void PlayAnimation(Animation newAnimation)
        {
            if (animation == newAnimation)
                return;

            animation = newAnimation;
            frameIndex = 0;
            timer = 0;
        }

        public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet)
        {
            if (Animation == null)
            {
                //throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (timer >= animation.m_FrameTime)
                {
                    timer -= animation.m_FrameTime;
                    if (animation.m_IsLooping)
                        try
                        {
                            frameIndex = (frameIndex + 1) % animation.m_FrameCount;
                        }
                        catch
                        {
                            frameIndex = 0;
                        }
                    else frameIndex = Math.Min(frameIndex + 1, animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(frameIndex * Animation.m_FrameWidth,
                                                 0, Animation.m_FrameWidth, Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.m_FrameWidth * Animation.m_Resize),
                (int)(Animation.m_FrameHeight * Animation.m_Resize));

                // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
                g.Draw(Animation.m_Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet,Color Couleur)
        {
            if (Animation == null)
            {
                //throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (timer >= animation.m_FrameTime)
                {
                    timer -= animation.m_FrameTime;
                    if (animation.m_IsLooping)
                        try
                        {
                            frameIndex = (frameIndex + 1) % animation.m_FrameCount;
                        }
                        catch
                        {
                            frameIndex = 0;
                        }
                    else frameIndex = Math.Min(frameIndex + 1, animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(frameIndex * Animation.m_FrameWidth,
                                                 0, Animation.m_FrameWidth, Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.m_FrameWidth * Animation.m_Resize),
                (int)(Animation.m_FrameHeight * Animation.m_Resize));

                // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
                g.Draw(Animation.m_Texture, RecResize, Rectangle, Couleur, Rotation, Origin, spriteEffet, 0);
            }
        }
        public void Draw(GameTime gametime, SpriteBatch g, Rectangle RecPosition, SpriteEffects spriteEffet)
        {
            if (Animation == null)
            {
              // throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (timer >= animation.m_FrameTime)
                {
                    timer -= animation.m_FrameTime;
                    if (animation.m_IsLooping)
                        try
                        {
                            frameIndex = (frameIndex + 1) % animation.m_FrameCount;
                        }
                        catch
                        {
                            frameIndex = 0;
                        }
                    else frameIndex = Math.Min(frameIndex + 1, animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(frameIndex * Animation.m_FrameWidth,
                                                 0, Animation.m_FrameWidth, Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle(RecPosition.X, RecPosition.Y, (int)animation.m_FrameWidth * (RecPosition.Height / animation.m_FrameWidth), (int)animation.m_FrameWidth * (RecPosition.Height / animation.m_FrameWidth));//new Rectangle((int)Position.X, (int)Position.Y, Animation.FrameWidth * (int)Animation.Resize,
                //Animation.FrameHeight * (int)Animation.Resize);

                // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
                //g.Draw(Animation.Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);

                ///Seulement pour sonic
                g.Draw(Animation.m_Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet,float Rotation)
        {
            if (Animation == null)
            {
                //throw new NotSupportedException("Yo,is no animation selected");
            }
            else
            {
                timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                while (timer >= animation.m_FrameTime)
                {
                    timer -= animation.m_FrameTime;
                    if (animation.m_IsLooping)
                        try
                        {
                            frameIndex = (frameIndex + 1) % animation.m_FrameCount;
                        }
                        catch
                        {
                            frameIndex = 0;
                        }
                    else frameIndex = Math.Min(frameIndex + 1, animation.m_FrameCount - 1);
                }

                Rectangle Rectangle = new Rectangle(frameIndex * Animation.m_FrameWidth,
                                                 0, Animation.m_FrameWidth, Animation.m_FrameHeight);

                Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.m_FrameWidth * Animation.m_Resize),
                (int)(Animation.m_FrameHeight * Animation.m_Resize));

                // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
                g.Draw(Animation.m_Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
            }
        }
        }
    }

