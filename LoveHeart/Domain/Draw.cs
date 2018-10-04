using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Draw
    {
        private static int origRow;
        private static int origCol;

        public Draw()
        {
            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
        }

        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }
}
