using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGameLibrairy
{
    /// <summary>
    /// classe servant a créer une action en animation
    /// </summary>
    public class Animation
    {
        public Texture2D m_Texture;
        public int m_FrameWidth;
        public int m_FrameHeight;
        public int m_FrameCount;
        public float m_FrameTime;
        public float m_Resize;
        public bool m_IsLooping;

        public Animation(Texture2D Texture, int FrameWidth, float FrameTime, float Resize, bool IsLooping)
        {
            this.m_Texture = Texture;
            this.m_FrameWidth = FrameWidth;
            this.m_FrameTime = FrameTime;
            this.m_Resize = Resize;
            this.m_IsLooping = IsLooping;
            this.m_FrameCount = Texture.Width / this.m_FrameWidth;
        }
    }
}
