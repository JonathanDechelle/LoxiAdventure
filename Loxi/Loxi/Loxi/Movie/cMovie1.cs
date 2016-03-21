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
    class cMovie1:GameScreen
    {
        Cinematique1 Cinematique;

        public cMovie1(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            Cinematique = new Cinematique1();
             MediaPlayer.IsRepeating = true;
             MediaPlayer.Play(RessourcesLoxi.SongCinematique1);
        }

        public override void Load()
        {
            Cinematique.LoadContent(Content);
            Cinematique.Play();
        }

        public override void Update(GameTime gameTime)
        {
            Cinematique.Update();
            if (!Cinematique.display)
            {
                MediaPlayer.Pause();
                GameScreen.AddScreen(new cNivComplexeScientifique(serviceProvider, GraphicsDeviceManager));
                GameScreen.RemoveScreen(this);
            }
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            Cinematique.Draw(g, gametime);
        }
    }
}
