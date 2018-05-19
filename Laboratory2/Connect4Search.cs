using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory2
{
	public class Connect4Search : AlphaBetaSearcher
	{
		public Connect4Search(IState startState, bool isMaximizingPlayerFirst, int maximumDepth) : base(startState, isMaximizingPlayerFirst, maximumDepth)
		{

		}

		protected override void buildChildren(IState parent)
		{
            char[] playersChars = { 'o', 'x' };

            int markIdx = (int)parent.Depth;
            if (isMaximizingPlayerFirst)
            {
                markIdx++;
            }
            markIdx = markIdx % 2;

            Connect4State state = parent as Connect4State;

            //Console.Write("buildChilden Gridsize: " + state.getGridSize() + '\n');

            for (int i = 0; i < state.getGridSize(); i++)
            {

                Connect4State child = new Connect4State(state, i);
                //Console.Write("buildChildren child: " + i + '\n');

                parent.Children.Add(child);
            }
            //Console.ReadKey();
		}
        
	}
}
