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
            Connect4State state = parent as Connect4State;

            for (int i = 0; i < state.getGridSize(); i++)
            {

                Connect4State child = new Connect4State(state, i);
                parent.Children.Add(child);
            }
		}
        
	}
}
