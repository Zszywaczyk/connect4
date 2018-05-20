using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory2
{
	class KeyAction 
	{
		private int position;
		private ConsoleKeyInfo cki;
        private int gridsize;

		public KeyAction(int gridsize)
		{
			this.position = 0;
            this.gridsize = gridsize;
		}

		public int getColNum()
		{
            while (true)
            {
                string spacesString = new string(' ', position * 2 + 1);

                StringBuilder pointerString = new StringBuilder();
                pointerString.Append(spacesString + "^");

                Console.Write("\r");
                Console.Write(pointerString.ToString());

                cki = Console.ReadKey();
                if (cki.Key.ToString() == "LeftArrow")
                {
                    if (this.position > 0)
                    {
                        this.position -= 1;
                    }
                    else
                    {
                        this.position = gridsize - 1;
                    }
                }

                if (cki.Key.ToString() == "RightArrow")
                {
                    this.position = ++this.position % gridsize;
                }

                if (cki.Key.ToString() == "Enter")
                {
                    break;
                }

                string cleaner = '\r' + new string(' ', 30);
                Console.Write(cleaner); // nie pytaj xD
            }
            return position;
		}
        
	}
}
