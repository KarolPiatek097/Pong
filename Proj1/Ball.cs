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
    public class Ball
    {
        public float ballSize = 20f;
        public Vector2f velocity;
        Random r = new Random(DateTime.Now.Millisecond);


        public CircleShape ball = new CircleShape();

        public Ball()
        {
            ball.FillColor = Color.Red;
            ball.Radius = ballSize;
            ball.Origin = new Vector2f(ballSize, ballSize);
            ball.Position = new Vector2f(MyGlobals.width / 2, MyGlobals.height / 2);

            velocity = new Vector2f(10 * generateRandomDirection(), generateRandomAngle());

        }

        int generateRandomDirection()
        {
            int rand;
            do
            {
                rand = r.Next(-1, 2);
            } while (rand == 0);
            Console.Write(rand);
            return rand;
        }

        int generateRandomAngle()
        {
            int rand;
            rand = r.Next(-10, 10);
            return rand;
        }

        public void checkHorizontalCollision()
        {
            if (ball.Position.Y - ball.Radius <= 50)
                velocity.Y *= -1;
            if (ball.Position.Y + ball.Radius >= MyGlobals.height - 50)
                velocity.Y *= -1;
        }

        public bool checkPlayerCollision(Player _p1, Player _p2)
        {
            bool doesCollide = false;
            float collisionPoint;

            if ((ball.Position.X - ball.Radius <= _p1.player.Position.X + 25 &&
                ball.Position.Y >= _p1.player.Position.Y &&
                ball.Position.Y <= _p1.player.Position.Y + 100))
            {
                doesCollide = true;
                collisionPoint = ball.Position.Y -_p1.player.Position.Y;
                changeBallAngle(collisionPoint);
            }

            if(ball.Position.X + ball.Radius >= _p2.player.Position.X &&
                ball.Position.Y >= _p2.player.Position.Y &&
                ball.Position.Y <= _p2.player.Position.Y + 100)
            {
                doesCollide = true;
                collisionPoint = ball.Position.Y - _p2.player.Position.Y;
                changeBallAngle(collisionPoint);
            }
            return doesCollide;
        }

        public void checkVerticalCollision()
        {

            if (ball.Position.X - ball.Radius <= 50)
            {
                MyGlobals.p2Score++;
                ball.Position = new Vector2f(MyGlobals.width / 2 + ball.Radius/2, MyGlobals.height / 2);
                MyGlobals.time = 0;
                velocity = new Vector2f(-10, generateRandomAngle());

            }
            if (ball.Position.X + ball.Radius >= MyGlobals.width - 50)
            {
                MyGlobals.p1Score++;
                ball.Position = new Vector2f(MyGlobals.width / 2 - ball.Radius/2, MyGlobals.height / 2);
                MyGlobals.time = 0;
                velocity = new Vector2f(10, generateRandomAngle());
            }


        }

        public void move()
        {
            ball.Position += velocity;
        }

        public void changeBallAngle(float _collisionPoint)
        {
            if (_collisionPoint < 50)
                velocity.Y =  (_collisionPoint - 50) * 0.3f;
            if (_collisionPoint == 50)
                velocity.Y = 0;
            if (_collisionPoint > 50)
                velocity.Y = (_collisionPoint - 50) * 0.3f;
        }

    }
}
