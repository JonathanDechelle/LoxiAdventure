using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyGameLibrairy;

namespace Loxi
{
    class cMovie2:GameScreen
    {
        Animation Fou = new Animation(GameResources.FouAnime, 60, 0.5f,3f, true);
        Animation DragInNiv2 = new Animation(GameResources.DragInNiv2, 110, 0.25f, 2, false);
        AnimationPlayer AnimationPlayer = new AnimationPlayer();
        AnimationPlayer AnimationPlayer2 = new AnimationPlayer();
        int Compteur=0;
        string Parole="";
        Vector2 ParolePosition = new Vector2(30, 130);
        Rectangle BullePosition = new Rectangle(150, 30, (int)(GameResources.BulleParole.Width * 1.5), (int)(GameResources.BulleParole.Height * 1.5));
       //Position Bulle Mechant BullePosition = new Rectangle(580, 55, (int)(Ressources.BulleParole.Width * 1.5), (int)(Ressources.BulleParole.Height * 1.5));
        //Position Parole Mechant  ParolePosition = new Vector2(460, 150);
        
        Color CouleurParole = Color.Blue;

         public cMovie2(IServiceProvider serviceProvider,GraphicsDeviceManager graphics)
            : base(serviceProvider,graphics)
        {
           
        }

         public override void Load()
         {
             MediaPlayer.Play(GameResources.SongCinematique2);
         }

         public override void Update(GameTime gameTime)
         {
             switch (Compteur)
             {
                 case 0: Parole = "Alors c vrai,\nvous voulez \n vraiment \ndétruire la\n planète! \nESPECE DE FOU!!!!";
                     break;

                 case 1: Parole = "Mais comment\navez vous fait\n pour rentrer !?\noui c'est mon plan\n et personne ne\n pourra l' \n   empecher !!!!!";// \n je te laisse une chance de partir";
                     CouleurParole = Color.Red;
                     BullePosition = new Rectangle(580, 55, (int)(GameResources.BulleParole.Width * 1.5), (int)(GameResources.BulleParole.Height * 1.5));
                     ParolePosition = new Vector2(460, 150);
                     break;
                 case 2: Parole = " Je te laisse \n une chance de \n partir et de tout \n oublier.. \n\n Qu'en dis tu ?";
                     break;

                 case 3: Parole = "JE NE TE\nLAISSERAI PAS\nFAiRE !!!!!!!!\nJE SUIS EN \nVACANCES \n J'AIMERAIS EN\n  PROFITER ENCORE\n            !!!!!!";
                     CouleurParole = Color.Blue;
                     ParolePosition = new Vector2(30, 130);
                     BullePosition = new Rectangle(150, 30, (int)(GameResources.BulleParole.Width * 1.5), (int)(GameResources.BulleParole.Height * 1.5));
                     break;

                 case 4: Parole = "Alors tu l'\nauras voulu. \nje vais te donner\n un avant gout \ndes créatures que\n je vais mettre \n  sur ma nouvelle \n       planete !";
                     CouleurParole = Color.Red;
                     BullePosition = new Rectangle(580, 55, (int)(GameResources.BulleParole.Width * 1.5), (int)(GameResources.BulleParole.Height * 1.5));
                     ParolePosition = new Vector2(460, 150);
                     break;
             }
             if (KeyboardHelper.KeyPressed(Keys.Space))
                 Compteur++;

             if(Compteur==5)
             AnimationPlayer.PlayAnimation(DragInNiv2);
             else if (Compteur == 6)
             {
                 GameScreen.AddScreen(new cNivTortueNinja(m_ServiceProvider, m_GraphicsDeviceManager));
                 GameScreen.RemoveScreen(this);
             }

             AnimationPlayer2.PlayAnimation(Fou);
             
         }

         public override void Draw(GameTime gametime, SpriteBatch g)
         {
             g.Draw(GameResources.Machine2, new Rectangle(500, -10, 400, 400), Color.White);
             g.Draw(GameResources.Machine, new Rectangle(400, 50, 400, 400), Color.White);
             
             if (Compteur == 5)
             {
                 AnimationPlayer.Draw(gametime, g, new Vector2(200, 400), SpriteEffects.None);
                 if (AnimationPlayer.m_FrameIndex == 13)
                 {
                     g.Draw(GameResources.BulleParole, BullePosition, null, Color.White, 20, new Vector2(), SpriteEffects.None, 0);
                     g.DrawString(GameResources.Texte2, "Bon .. Une \nchose de faite. \nAu cas où que tu\nt'en sorte vivant \nje te réserve une \nbonne suprise à \n    ton retour\n      Mouahaha!", ParolePosition, CouleurParole);
                     g.DrawString(GameResources.Texte2, "Appuyer sur espace", new Vector2(ParolePosition.X, ParolePosition.Y + 300), CouleurParole);
                     AnimationPlayer2.Draw(gametime, g, new Vector2(700, 420), SpriteEffects.FlipHorizontally);
                 }
             }
             else
             {
                 g.Draw(GameResources.Donald, new Vector2(200, 200), Color.White);
                 g.Draw(GameResources.BulleParole, BullePosition, null, Color.White, 20, new Vector2(), SpriteEffects.None, 0);
                 g.DrawString(GameResources.Texte2, Parole, ParolePosition, CouleurParole);
                 g.DrawString(GameResources.Texte2, "Appuyer sur espace", new Vector2(ParolePosition.X, ParolePosition.Y + 300), CouleurParole);
                 AnimationPlayer2.Draw(gametime, g, new Vector2(700, 420), SpriteEffects.FlipHorizontally);
             }

            
         }
    }
}
