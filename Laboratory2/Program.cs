using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory2 {
    class Program {
		public static bool computerMax; //1 zaczyna komputer; 0 czlowiek

		static void Main(string[] args) {
			//Losowy start jak skoñczê heurystykê
			//computerMax = false; //true jesli komputer zaczyna (pozniej zostanie zmienione)
                                //Console.SetWindowSize(50,20);//wysokosc i szerokosc konsoli w razie czego zmienic lub usunac

            const int GRIDSIZE = 8;
			Connect4State startState = new Connect4State(GRIDSIZE, Connect4State.Player.MIN);
            KeyAction keyAction = new KeyAction(GRIDSIZE);

			int i;
			if (keyAction.computerStarts == false)
			{
				i = 0;
				computerMax = false;
			}
			else
			{
				i = 1;
				computerMax = true;
			}

			//defoult jest player first, o dla player
			while (true)
			{
                Console.Clear();
                if (i % 2 == 0) 
                {
					
                    Console.Write("Punkty: " + startState.ComputeHeuristicGrade() + "\n");
					
                    //Console.Write("Player mark: " + playersMark[i] + "\n");

                    startState.Print();
					if (double.IsPositiveInfinity(startState.ComputeHeuristicGrade()))
					{
						Console.WriteLine("We have a winner!\nPress any key...");
						Console.ReadKey();
						weHaveAWinner(startState);
					}
					else if (double.IsNegativeInfinity(startState.ComputeHeuristicGrade()))
					{
						Console.WriteLine("We have a winner!\nPress any key...");
						Console.ReadKey();
						weHaveAWinner(startState);
					}
					int choosenColumn = keyAction.getColNum();

                    startState = new Connect4State(startState, choosenColumn, true);
					//Console.Clear();
					//startState.Print();
					//Console.ReadKey();
					
				}
                else
                {
                    Connect4Search search = new Connect4Search(startState, computerMax, keyAction.depth);
                    search.DoSearch();


                    //Console.Write("Length: " + search.MovesMiniMaxes.Count + '\n');

                    double alpha = 0;
                    if (computerMax)
                    {
                        alpha = double.NegativeInfinity;
                    }
                    else if (!computerMax)
                    {
                        alpha = double.PositiveInfinity;
                    }


                    string key = startState.ID;
                    foreach (KeyValuePair<string, double> kvp in search.MovesMiniMaxes)
                    {
                        //Console.Write(kvp.Key.Length + "<- le ");
                        //Console.Write(kvp.Key + " " + kvp.Value + '\n');

                        if (computerMax && kvp.Value > alpha)
                        {
                            alpha = kvp.Value;
                            key = kvp.Key;
                        }

                        if (!computerMax && kvp.Value < alpha)
                        {
                            alpha = kvp.Value;
                            key = kvp.Key;
                        }

                    }
                    startState = new Connect4State(startState, key);


                    //Console.ReadKey();
                }

                if (startState.isFullState())
                {
                    Console.Clear();
                    Console.Write("!!!REMIS!!!");
                    return;
                }
                else
                {
                    i = (++i) % 2;
                }
            }


			//cki = Console.ReadKey();
			//Console.WriteLine(cki.Key.ToString());
			//if (cki.Key.ToString() == "LeftArrow")
			//{
			//	Console.WriteLine("dupa");
			//}

			Console.ReadKey();


		}
		public static void weHaveAWinner(Connect4State startState)
		{
			if(computerMax==true && double.IsPositiveInfinity(startState.ComputeHeuristicGrade()))
			{
				Console.Clear();
				nextStep("Computer wins!\n\n");
			}
			else if(computerMax == false && double.IsNegativeInfinity(startState.ComputeHeuristicGrade()))
			{
				Console.Clear();
				nextStep("Human wins!\n\n");
			}
			else if (computerMax == true && double.IsNegativeInfinity(startState.ComputeHeuristicGrade()))
			{
				Console.Clear();
				nextStep("Human wins!\n\n");
			}
			else if (computerMax == false && double.IsPositiveInfinity(startState.ComputeHeuristicGrade()))
			{
				Console.Clear();
				nextStep("Computer wins!\n\n");
			}
		}

		public static void nextStep(String whoWon) {
			bool decision = false;
            bool playAgain = false;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            while (decision == false)
			{
                Console.WriteLine(whoWon);

                Console.WriteLine("Exit\tPlay again");
				//cki = Console.ReadKey();
				if (cki.Key.ToString() == "RightArrow")
				{
					Console.WriteLine("\t     ^");
					playAgain = true;
				}
				else if (cki.Key.ToString() == "LeftArrow")
				{
					Console.WriteLine(" ^");
					playAgain = false;
				}

				cki = Console.ReadKey();
				Console.Clear();
				if (cki.Key.ToString() == "Enter")
				{
					if (playAgain == false) //wybrane z lewej
					{
						System.Environment.Exit(1);
					}
					else if (playAgain == true) //wybrane z prawej
					{
						string[] kolko= { };
						Main(kolko);
					}
                    decision = true;
				}
			}
		}
    }
}
