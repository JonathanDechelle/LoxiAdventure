using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using MyGameLibrairy;


namespace Loxi
{
    class cExplicationControle:GameScreen
    {
        Player Joueur;

         public cExplicationControle(IServiceProvider serviceProvider,GraphicsDeviceManager graphics)
            : base(serviceProvider,graphics)
        {
            Joueur = new Player(true, true);
            Joueur.Position = new Vector2(140, 140);
        }

         public override void Load()
         {
             Joueur.Load(Content);
         }

         public override void Update(GameTime gameTime)
         {
             Joueur.Update(null,null,null);  

             if(KeyboardHelper.KeyPressed(Keys.Escape))
             {
                 GameScreen.AddScreen(new cMainMenu(serviceProvider, GraphicsDeviceManager));
                 GameScreen.RemoveScreen(this);
             }

         }

         public override void Draw(GameTime gametime, SpriteBatch g)
         {
             g.GraphicsDevice.Clear(Color.DarkOrange);
             g.DrawString(RessourcesLoxi.Texte,
            " Voici donald alias LOXI, durant toute son aventure \n vous devrez le controler grâce aux contrôles \n W,A,S,D pour la direction \n Espace pour sauter (À partir du 2 ieme level) \n Shift pour courir  \n et C pour tirer (À partir du 2 ieme level)",
            new Vector2(),Color.DarkSlateGray);
             g.DrawString(RessourcesLoxi.Texte, "Escape pour revenir au menu", new Vector2(350, 300), Color.Black);                                                                                                          
                                            
             Joueur.Draw(gametime, g);
         }
    }
}
