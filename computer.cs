using System;
namespace connect4Assignment
{

	public class computer
	{

		char difficulty;
		bool computerTurn = false;
		
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

					Random rand = new Random();
					
					return(rand.Next(7));

				

				//medium difficulty
				case 'm':


				break;

				//hard difficulty
				case 'h':


				break;

            }



			return 0;

            }



        }
		

	}





