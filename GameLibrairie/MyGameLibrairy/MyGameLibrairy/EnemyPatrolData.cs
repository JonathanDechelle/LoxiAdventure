 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MyGameLibrairy
{
    public class EnemyPatrolData
    {
        public Animation m_PatrolAnimation;
        public float m_PatrolDistance;
        public float m_PatrolSpeed;

        public EnemyPatrolData(float aPatrolDistance, float aPatrolSpeed, Animation aPatrolAnimation)
        {
            m_PatrolDistance = aPatrolDistance;
            m_PatrolSpeed = aPatrolSpeed;
            m_PatrolAnimation = aPatrolAnimation;
        }
    }
}
