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
    class Program
    {
        static void Main(string[] args)
        {
            var window = new RenderWindow(new VideoMode((uint)MyGlobals.width, (uint)MyGlobals.height), "Pong", Styles.Default);
            window.SetFramerateLimit((uint)MyGlobals.frameRate);


            Box box = new Box(new Ball(), new Player(1), new Player(2));



            window.Closed += (s, a) => window.Close();
            window.KeyPressed += (s, a) => box.move(a.Code);
            window.KeyReleased += (s, a) =>
            {
                MyGlobals.dir1 = MyGlobals.Direction1.Default;
                MyGlobals.dir2 = MyGlobals.Direction2.Default;

                box.p1.velocity = new Vector2f(0, 0);
                box.p2.velocity = new Vector2f(0, 0);
            };

            

            while (window.IsOpen)
            {
                update();
                window.DispatchEvents();

                #region timer
                MyGlobals.frameCount++;
                if(MyGlobals.frameCount == MyGlobals.frameRate)
                {
                    MyGlobals.time++;
                    MyGlobals.frameCount = 0;
                    //Console.WriteLine(MyGlobals.time);
                }
                #endregion


                window.Clear();
                
                display();

                window.Display();
            }
           
            void display()
            {
                foreach (var obj in box.drawableList)
                    window.Draw(obj);
            }

            void update()
            {


                if (MyGlobals.time >= 1)
                {
                    box.p1Score.DisplayedString = Convert.ToString(MyGlobals.p1Score);
                    box.p2Score.DisplayedString = Convert.ToString(MyGlobals.p2Score);
                    box.ball.checkVerticalCollision();
                    box.ball.checkHorizontalCollision();
                    box.ball.move();
                    box.update();


                }

            }

            Console.ReadKey();
        }
    }
}
