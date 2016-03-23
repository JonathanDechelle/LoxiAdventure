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
    /// Classe servant à créer un ennemi qui patrouille
    /// </summary>
    public class EnemyPatrol
    {
        public bool m_HasDiscoverYou;
        public SpriteEffects m_SpriteEffect;
        public Vector2 m_Position;

        //public bool DroiteObject;
        //public bool GaucheObject; 

        private Rectangle m_Rectangle;
        private Vector2 m_CenterOfSprite;
        private AnimationPlayer m_Animationplayer;
        private EnemyPatrolData m_PatrolData;

        private float m_CurrentDistance;
        private float m_PlayerDistanceX;
        private float m_PlayerDistanceY;
        private bool m_OppositeDirection;

        public EnemyPatrol(Texture2D aTexture, Vector2 aPosition, EnemyPatrolData aPatrolData)
        {
            m_Position = aPosition;
            m_Rectangle = new Rectangle((int)m_Position.X - 90, (int)m_Position.Y - 90, 90, 90);
            m_CenterOfSprite = new Vector2(aTexture.Width / 2, aTexture.Height / 2);
            m_PatrolData = aPatrolData;
            m_OppositeDirection = true;
        }

        //public void Update(Player Joueur,List<ObjCollisionable>Obstacles)
        public void Update()
        {
            m_Animationplayer.PlayAnimation(m_PatrolData.m_PatrolAnimation);

            //m_Rectangle.X = (int)m_Position.X - 45;
            //m_Rectangle.Y = (int)m_Position.Y - 90;
            //DroiteObject = false; GaucheObject = false;

            float direction;
            if (m_OppositeDirection)
            {
                direction = -1f;
                m_SpriteEffect = SpriteEffects.None;
            }
            else
            {
                direction = 1f;
                m_SpriteEffect = SpriteEffects.FlipHorizontally;
            }

            m_Position += m_PatrolData.m_PatrolSpeed * Vector2.UnitX * direction;
            m_CurrentDistance += m_PatrolData.m_PatrolSpeed;
            if (m_CurrentDistance > m_PatrolData.m_PatrolDistance)
            {
                m_OppositeDirection = !m_OppositeDirection;
                m_CurrentDistance = 0f;
            }

            /*
            if (Joueur != null)
            {
                playerDistanceX =﻿ Joueur.Position.X - Position.X;
                playerDistanceY = Joueur.Position.Y - Position.Y;

                if (playerDistanceX >= -300 && playerDistanceX <= 300 && playerDistanceY>=-100 && playerDistanceY<=100)
                {
                    DiscoverYou =true;
                    if (playerDistanceX < -1)
                    {
                        Speed.X = -1f;
                        m_SpriteEffect = SpriteEffects.None;
                      
                    }
                    else if (playerDistanceX > 1)
                    {
                        Speed.X = 1f;
                        m_SpriteEffect = SpriteEffects.FlipHorizontally;
                    }
                    else if (playerDistanceX == 0)
                    Speed.X = 0f;

                }

                 else
                     DiscoverYou = false;
              
            }*/
        }

        public void Draw(GameTime aGameTime, SpriteBatch g)
        {
            m_Animationplayer.Draw(aGameTime, g, m_Position, m_SpriteEffect);
        }

    }
}

