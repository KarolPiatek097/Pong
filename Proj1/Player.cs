using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Proj1
{
    public class Player
    {
        public RectangleShape player = new RectangleShape(new Vector2f(25,100));
        public int playerNr;
        public Vector2f velocity = new Vector2f(0, 0);
        
        

        public Player(int _playerNr)
        {
            MyGlobals.playerCount++;
            playerNr = _playerNr;
            player.FillColor = Color.White;

            if (MyGlobals.playerCount == 1)
                player.Position = new Vector2f(51, MyGlobals.height / 2);
            else
                player.Position = new Vector2f(MyGlobals.width - 51 - 25, MyGlobals.height / 2);

        }
        
        public bool checkUp()
        {
            bool doesCollide = false;

            if (player.Position.Y <= 50)
            {
                velocity = new Vector2f(0, 0);
                doesCollide = true;
            }
            return doesCollide;
        }

        public bool checkDown()
        {
            bool doesCollide = false;

            if (player.Position.Y >= 930)
            {
                velocity = new Vector2f(0, 0);
                doesCollide = true;
            }
            return doesCollide;
        }

    }
}
