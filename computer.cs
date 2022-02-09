using System;
namespace connect4Assignment
{

	public class computer
	{

		char difficulty;
		
		public computer()
		{
		}

		public computer(char d)
        {
			difficulty = d;
        }

		private int computerMove()
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





