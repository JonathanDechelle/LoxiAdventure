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
    class cFinal:GameScreen
    {
           public cFinal(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            
        }

        public override void Load()
        {
            MediaPlayer.Play(RessourcesLoxi.FinalSong);
            MediaPlayer.IsRepeating = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (KeyboardHelper.KeyPressed(Keys.E))
                AddScreen(new cMainMenu(m_ServiceProvider, m_GraphicsDeviceManager));
        }



        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            g.Draw(m_Content.Load<Texture2D>("plage2"), new Vector2(), Color.White);

            g.DrawString(RessourcesLoxi.Texte, "thank you for playing", new Vector2(350, 50), Color.OrangeRed);
            g.DrawString(RessourcesLoxi.Texte2, "Key E for go to MainMenu", new Vector2(400, 100), Color.Red);
        }
    }
}
