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
    public static class MyGlobals
    {
        public static int width = 1920;
        public static int height = 1080;
        public static int frameRate = 60;
        public static int frameCount = 0;
        public static int time = 0;

        public static int p1Score = 0;
        public static int p2Score = 0;

        public static int playerCount = 0;

        public enum Direction1 { Default, Up, Down };
        public static Direction1 dir1 = Direction1.Default;

        public enum Direction2 { Default, Up, Down };
        public static Direction2 dir2 = Direction2.Default;

        
    }
}
