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
		public bool computerStarts = false;
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
			bool? leftOrRight = null;
			while (decision == false)
			{

				Console.WriteLine("Whos first: ");
				Console.WriteLine("Computer\tPlayer");
				//cki = Console.ReadKey();
				if (cki.Key.ToString() == "RightArrow")
				{
					Console.WriteLine("\t\t   ^");
					leftOrRight = true;
				}
				else if (cki.Key.ToString() == "LeftArrow")
				{
					Console.WriteLine("   ^");
					leftOrRight = false;
				}

				cki = Console.ReadKey();
				if (cki.Key.ToString() == "Enter" && leftOrRight != null)
				{
					if (leftOrRight == false) //wybrane z lewej
					{
						computerStarts = true;
						computerORplayer = "computer";
						decision = true;
					}
					else if (leftOrRight == true) //wybrane z prawej
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
				else if (cki.Key.ToString() == "Enter" && leftOrRight == null)
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
			bool? leftOrRight = null;
			while (decision == false)
			{

				Console.WriteLine("Now time to choice MARK of first player:");
				Console.WriteLine("x\to");
				//cki = Console.ReadKey();
				if (cki.Key.ToString() == "RightArrow")
				{
					Console.WriteLine("\t^");
					leftOrRight = true;
				}
				else if (cki.Key.ToString() == "LeftArrow")
				{
					Console.WriteLine("^");
					leftOrRight = false;
				}

				cki = Console.ReadKey();
				if (cki.Key.ToString() == "Enter" && leftOrRight != null)
				{
					if (leftOrRight == false) //wybrane z lewej
					{
						playersMark[0] = 'x';
						playersMark[1] = 'o';
						decision = true;
					}
					else if (leftOrRight == true) //wybrane z prawej
					{
						playersMark[0] = 'o';
						playersMark[1] = 'x';
						decision = true;
					}
					Console.Clear();
					Console.WriteLine("You chose: " + playersMark[0]);
					Console.WriteLine("Press any key...");
					Console.ReadKey();
				}
				else if(cki.Key.ToString() == "Enter" && leftOrRight == null)
				{
					break;
				}
				Console.Clear();

			}
			Console.Clear();
		}
		private void howDepth()
		{
			Console.Write("How depth: ");
			try
			{
				int x = Convert.ToInt32(Console.ReadLine());
				depth = x;
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
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
