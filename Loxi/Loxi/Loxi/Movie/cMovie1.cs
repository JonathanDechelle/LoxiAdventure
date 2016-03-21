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
        Cinematique Cinematique;

        public cMovie1(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            Diapositive[] Diapos = new Diapositive[4]{
                new Diapositive(
                    "Plage",
                    "Donald se reposait tranquillement sur\n l'île de Cuba, avec son journal quotidien.",
                    Color.White,
                    Color.BlueViolet,
                    RessourcesLoxi.Texte),

                new Diapositive(
                    "NewsPaper",
                    "Dans son journal, on parlait d'une rumeur\n qu'un méchant scientifique voudrait détruire la \n planète et en reconstruire une autre.",
                    Color.Black,
                    Color.Red,
                    RessourcesLoxi.Texte),

                new Diapositive(
                    "Bunker",
                    "Donald : Encore un autre fou !! ... \n(il continua de lire) il serait caché dans une base \n militaire non loin de l'île de Cuba \n Donald: C'est sur mon île !! .",
                    Color.DarkMagenta,
                    Color.Red,
                    RessourcesLoxi.Texte),

                new Diapositive(
                    "DebutEnquete",
                    "Il décida de mener sa petite enquête lui-même,\n sous le nom de code LOXI pour ne pas dévoiler\n                                               son identité .",
                    Color.Blue,
                    Color.Bisque,
                    RessourcesLoxi.Texte)
            };

            for (int i = 0; i < Diapos.Length; i++)
            {
                Diapos[i].LoadContent(m_Content);
            }

            Cinematique = new Cinematique(Diapos);
            Cinematique.OnCinematicFinished -= ChangeScreen; // just for be sure
            Cinematique.OnCinematicFinished += ChangeScreen;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(RessourcesLoxi.SongCinematique1);
        }

        public override void Load()
        {
            Cinematique.Play();
        }

        public override void Update(GameTime gameTime)
        {
            Cinematique.Update();
        }

        private void ChangeScreen()
        {
            Cinematique.OnCinematicFinished -= ChangeScreen;
            MediaPlayer.Pause();
            GameScreen.AddScreen(new cNivComplexeScientifique(m_ServiceProvider, m_GraphicsDeviceManager));
            GameScreen.RemoveScreen(this);
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            Cinematique.Draw(g, gametime);
        }
    }
}
