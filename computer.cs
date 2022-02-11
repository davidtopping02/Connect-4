using System;
using System.Collections.Generic;
namespace connect4Assignment
{

	public class computer
	{

		char difficulty;
		bool computerTurn = false;
		int bestMove;
		int highestCount;
		List<int> validMoves = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
		Random rand = new Random();
		

		public computer()
		{
		}

		public computer(char d)
		{
			difficulty = d;
		}

		public bool getTurn()
		{
			return computerTurn;
		}

		public void flipTurn()
		{
			computerTurn = !computerTurn;
		}

		public int computerMove()
		{

			switch (difficulty)
			{

				//easy difficulty
				case 'e':

					return validMoves[rand.Next(validMoves.Count)];

				//medium difficulty
				case 'm':

					if(highestCount < 2)
                    {
						return validMoves[rand.Next(validMoves.Count)];
					}
                    else
                    {
						return bestMove;
					}

					

				//hard difficulty
				case 'h':


					break;

			}

			return 0;

		}

		public int getBestCoordinate()
		{
			return bestMove;
		}

		public void setBestCoordinate(int move, int highest)
		{
			//check if a move had +100 added to it, signaling it needs to be removed from valids
			if(move > 7)
            {
				move = move - 100;
				//need to make this remove value, not index
				validMoves.Remove(move);
				move = validMoves[rand.Next(validMoves.Count)];
				bestMove = move;

			}
            else
            {
				bestMove = move;
			}
			
			highestCount = highest;

		}



	}

	

	}





