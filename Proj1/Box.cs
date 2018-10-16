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
    public class Box
    {
        public RectangleShape box = new RectangleShape(new Vector2f(MyGlobals.width - 100, MyGlobals.height - 100));
        public RectangleShape middleLane = new RectangleShape(new Vector2f(3, MyGlobals.height - 100));

        public Text p1Score = new Text(Convert.ToString(MyGlobals.p1Score), new Font("Arial.ttf"), 40);
        public Text p2Score = new Text(Convert.ToString(MyGlobals.p1Score), new Font("Arial.ttf"), 40);

        public List<Drawable> drawableList = new List<Drawable>();

        public Ball ball;
        public Player p1;
        public Player p2;

        public Box(Ball _ball, Player _p1, Player _p2)
        {
            box.FillColor = Color.Transparent;
            box.OutlineColor = Color.White;
            box.OutlineThickness = 2f;
            box.Position = new Vector2f(50, 50);

            middleLane.Position = new Vector2f(MyGlobals.width / 2 - 2, 50);
            middleLane.FillColor = Color.White;

            p1Score.Position = new Vector2f(MyGlobals.width / 2 - 45, 55);
            p2Score.Position = new Vector2f(MyGlobals.width / 2 + 20, 55);

            ball = _ball;
            p1 = _p1;
            p2 = _p2;

            drawableList.Add(box);
            drawableList.Add(middleLane);
            drawableList.Add(ball.ball);
            drawableList.Add(p1.player);
            drawableList.Add(p2.player);
            drawableList.Add(p1Score);
            drawableList.Add(p2Score);
        }

        public void move(SFML.Window.Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.W:
                    if (p1.checkUp() == false)
                    {
                        MyGlobals.dir1 = MyGlobals.Direction1.Up;
                        p1.velocity = new Vector2f(0, -10);
                    }
                    break;
                case Keyboard.Key.S:
                    if (p1.checkDown() == false)
                    {
                        MyGlobals.dir1 = MyGlobals.Direction1.Down;
                        p1.velocity = new Vector2f(0, 10);
                    }
                    break;

                case Keyboard.Key.Up:
                    if (p2.checkUp() == false)
                    {
                        MyGlobals.dir2 = MyGlobals.Direction2.Up;
                        p2.velocity = new Vector2f(0, -10);
                    }
                    break;
                case Keyboard.Key.Down:
                    if (p2.checkDown() == false)
                    {
                        MyGlobals.dir2 = MyGlobals.Direction2.Down;
                        p2.velocity = new Vector2f(0, 10);
                    }
                    break;
            }

        }

        public void update()
        {

            if (ball.checkPlayerCollision(p1, p2) == true)
                ball.velocity.X *= -1;

                p1.player.Position += p1.velocity;
                p2.player.Position += p2.velocity;
        }

    }
}
