using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyGameLibrairy;

namespace Loxi
{
    /// <summary>
    /// testing class before adding to game definitively
    /// </summary>
    class cTest: GameScreen
    {
        public cTest(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
         
        }

        public override void Load()
        {
            
        }

        public override void Update(GameTime gameTime)
        { }



        public override void Draw(GameTime gametime, SpriteBatch g)
        {}
    }

}

