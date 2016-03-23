using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant à crée des progress bar ou bien des
    /// barres de vie
    /// </summary>
    public class HealthBars
    {
        public bool m_GameOver;

        private Texture2D m_Texture;
        private Vector2 m_Position;
        private Vector2 m_OffsetPosition;
        private Rectangle m_Rectangle;
        
        /*private String m_DeadText;
        private Color m_DeadColor;*/

        public HealthBars(Texture2D aTexture, Vector2 aOffsetPosition)
        {
            m_Texture = aTexture;
            m_Rectangle = new Rectangle(0, 0, aTexture.Width, aTexture.Height);
            m_OffsetPosition = aOffsetPosition;
            m_GameOver = false;

            //if (barEnnemy) { m_DeadText = "Win"; m_DeadColor = Color.Green; } else { m_DeadText = "Game Over"; m_DeadColor = Color.Red; }
        }

        public void Update(Vector2 aPlayerPosition)
        {
            m_Position = aPlayerPosition + m_OffsetPosition;

           if (m_Rectangle.Width <= 0)
           {
               m_GameOver = true;
           }
        }

        public void ApplyDamage(int aDamage)
        {
            m_Rectangle.Width -= aDamage;
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(m_Texture, m_Position, m_Rectangle, Color.White);
            /*
            if (m_GameOver)
            {
                g.DrawString(RessourcesLoxi.Texte, m_DeadText, m_Position, m_DeadColor);
            }*/
        }
    }
}
