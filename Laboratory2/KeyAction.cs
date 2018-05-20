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

		public string computerORplayer = "player"; //przechowuje stringa zaczynajacego gracza. Mozliwy: "player" lub "computer".
		public bool computerStarts = true;
		public static char[] playersMark = { 'o', 'x' };
		public int depth = 3;

		public KeyAction(int gridsize)
		{
			whosFirst(); //wybiera kto zaczyna
			choiceMark(); //wybiera jaki gracz ma miec znak
			howDepth();

			this.position = 0;
            this.gridsize = gridsize;
		}

		private void whosFirst()
		{
			bool decision = false;
            bool playerFirst = false;
			while (decision == false)
			{

				Console.WriteLine("Whos first: ");
				Console.WriteLine("Computer\tPlayer");
				//cki = Console.ReadKey();
				if (cki.Key.ToString() == "RightArrow")
				{
					Console.WriteLine("\t\t   ^");
					playerFirst = true;
				}
				else if (cki.Key.ToString() == "LeftArrow")
				{
					Console.WriteLine("   ^");
					playerFirst = false;
				}

				cki = Console.ReadKey();
				if (cki.Key.ToString() == "Enter")
				{
					if (playerFirst == false) //wybrane z lewej
					{
						computerStarts = true;
						computerORplayer = "computer";
						decision = true;
					}
					else if (playerFirst == true) //wybrane z prawej
					{
						computerStarts = false;
						computerORplayer = "player";
						decision = true;
					}
					Console.Clear();
					Console.WriteLine(computerORplayer.ToUpper() + " starts first!");
					Console.WriteLine("Press any key...");
					Console.ReadKey();
				}
				else if (cki.Key.ToString() == "Enter")
				{
					break;
				}
				Console.Clear();
			}
			Console.Clear();
		}
		private void choiceMark()
		{

			//playersMark = new char[2];
			bool decision = false;
            bool isPlayerMarkO = false;

			while (decision == false)
			{

				Console.WriteLine("Now time to choice mark of PLAYER:");
				Console.WriteLine("x\to");
				//cki = Console.ReadKey();
				if (cki.Key.ToString() == "RightArrow")
				{
					Console.WriteLine("\t^");
                    isPlayerMarkO = true;
				}
				else if (cki.Key.ToString() == "LeftArrow")
				{
					Console.WriteLine("^");
                    isPlayerMarkO = false;
				}

				cki = Console.ReadKey();
				if (cki.Key.ToString() == "Enter")
				{
                    if (computerStarts)
                    {
                        playersMark[0] = (isPlayerMarkO ? 'x' : 'o');
                        playersMark[1] = (isPlayerMarkO ? 'o' : 'x');
                    }
                    else
                    {
                        playersMark[0] = (isPlayerMarkO ? 'o' : 'x');
                        playersMark[1] = (isPlayerMarkO ? 'x' : 'o');
                    }
                    decision = true;

					Console.Clear();
					Console.WriteLine("You chose: " + (computerStarts ? playersMark[1] : playersMark[0]));
					Console.WriteLine("Press any key...");
					Console.ReadKey();
				}
				Console.Clear();

			}
			Console.Clear();
		}

		private void howDepth()
		{
            int x = 0;

            while (x == 0)
            {
                Console.Clear();
                Console.Write("How depth: ");
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    depth = x;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
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
