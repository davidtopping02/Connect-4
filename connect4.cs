using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect4Assignment
{
    public partial class connect4 : Form
    {
        //init global variables/objects
        Label[,] lbl = new Label[7, 5];
        Button[] Btn = new Button[7];
        char playerTurn = 'r';
        
        /// <summary>
        /// default constructor
        /// </summary>
        public connect4()
        {
            InitializeComponent();

            selectRandomPlayer();
            //setting the player turn label
            if (playerTurn == 'y')
            {
                TxtPlayerTurnInfo.ForeColor = Color.Yellow;
                TxtPlayerTurnInfo.Text = "Yellow's Turn.";
            }
            else if(playerTurn == 'r')
            {
                TxtPlayerTurnInfo.ForeColor = Color.Red;
                TxtPlayerTurnInfo.Text = "Red's Turn.";
            }

            //init each label and position
            for (int i = 0; i < 7; i++)
            {

                //Initializing the buttons
                initialize_Btn(i);

                for (int j = 0; j < 5; j++)
                {
                    //init each label
                    lbl[i, j] = new Label();

                    //setting position and colour
                    lbl[i, j].SetBounds(100+(75*i) , 195+(75*j), 60, 60);
                    lbl[i, j].BackColor = Color.White;

                    //making labels circular
                    var path2 = new System.Drawing.Drawing2D.GraphicsPath();
                    path2.AddEllipse(0, 0, lbl[i, j].Width, lbl[i, j].Height);
                    this.lbl[i, j].Region = new Region(path2);

                    //adding to the controls
                    Controls.Add(lbl[i, j]);
                }

            }

        }
        
        /// <summary>
        /// Selects a random player yellow or red
        /// </summary>
        private void selectRandomPlayer()
        {
            //init local variables
            char[] options = {'y', 'r'};
            var randomNum = new Random();

            //getting random option r or y
            char op = options[randomNum.Next(options.Length)];

            //setting the player turn to the random option
            playerTurn = op;
        }

        private void initialize_Btn(int i)
        {
            Btn[i] = new Button();
            Btn[i].SetBounds(100 + (75 * i), 120, 60, 60);
            Btn[i].BackColor = Color.White;
            Btn[i].FlatAppearance.BorderSize = 0;
            Btn[i].TabStop = false;
            Btn[i].FlatStyle = FlatStyle.Flat;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Btn[i].Width, Btn[i].Height);
            this.Btn[i].Region = new Region(path);

            //changing the colour of the buttons when they are hovered over
            //Btn[i].MouseHover += new EventHandler(Connect4_MouseHover);
           // Btn[i].MouseLeave += new EventHandler(Connect4_MouseLeave);

            //click
            Btn[i].Click += delegate (object sender, EventArgs e) { Connect4_ButtonClick(sender, e, i); };

            Controls.Add(Btn[i]);
        }

        private void Connect4_ButtonClick(object sender, EventArgs e, int col)
        {
            //button clicked
            Button buttonClicked = (Button)sender;

            //adding a tile to the row as long as there is an empty slot
            int row = 0;

            //This is for the labels (NOT the top row butons)
            if (lbl[col, 0].BackColor == Color.White)
            {
                while (lbl[col, row].BackColor == Color.White)
                {

                    if (row == 4)
                    {
                        break;
                    }
                    else if (lbl[col, row + 1].BackColor != Color.White)
                    {
                        break;
                    }

                    //increment row if it doesn't meet other conditions
                    row++;
                }

                //changing the colour of the tile
                if (playerTurn == 'y')
                {
                    lbl[col, row].BackColor = Color.Yellow;
                    //changePlayer();
                    row = 0;
                }
                else if (playerTurn == 'r')
                {
                    lbl[col, row].BackColor = Color.Red;
                    //changePlayer();
                    row = 0;
                }

                
            }
            //This is for the top row of buttons
            else if (lbl[col, row].BackColor != Color.White && buttonClicked.BackColor == Color.White)
            {

                //changing the colour of the tile
                if (playerTurn == 'y')
                {
                    buttonClicked.BackColor = Color.Yellow;
                    //changePlayer();
                    row = 0;
                }
                else if (playerTurn == 'r')
                {
                    buttonClicked.BackColor = Color.Red;
                    //changePlayer();
                    row = 0;
                }
            }

            //check for 4 in a row
            fourInRowChecker(col, row);
            changePlayer();
        }

        private void fourInRowChecker(int col, int row)
        {
            int inARow = 0;
            string player = "";

            //determine which player to count for
            if (playerTurn == 'y')
            {
                player = "Yellow";
            }
            else if (playerTurn == 'r')
            {
                player = "Red";
            }


            //counting the vertical
            
            for (int i = 0; i < 5; i++) {
                if(lbl[col, i].BackColor == Color.FromName(player))
                {
                    inARow++;
                } else
                {
                    inARow = 0;
                }
                txtBoxWin.Text = Convert.ToString(inARow);
                if (inARow >= 4)
                {
                    txtBoxWin.Text = "Winner";
                    break;
                }
            }
            
            //counting the horizontal
            for (int i = 0; i < 7; i++)
            {
                if (lbl[i, row].BackColor == Color.FromName(player))
                {
                    inARow++;
                }
                else
                {
                    //inARow = 0;
                }
                txtBoxWin.Text = Convert.ToString(inARow);
                if (inARow >= 4)
                {
                    txtBoxWin.Text = "Winner";
                    break;
                }
            }

            //counting diagonals

        }

        /// <summary>
        /// Helper function to change the player's turn
        /// </summary>
        private void changePlayer()
        {
            if (playerTurn == 'r')
            {
                playerTurn = 'y';
                TxtPlayerTurnInfo.ForeColor = Color.Yellow;
                TxtPlayerTurnInfo.Text = "Yellow's Turn.";
            }
            else if (playerTurn == 'y')
            {
                playerTurn = 'r';
                TxtPlayerTurnInfo.ForeColor = Color.Red;
                TxtPlayerTurnInfo.Text = "Red's Turn.";
            }
        }

        /// <summary>
        /// Changing the colour of the top buttons on the mouse hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connect4_MouseHover(object sender, EventArgs e)
        {

            Button button = (Button)sender;
                
            if (playerTurn == 'y')
            {
                button.BackColor = Color.Yellow;
            }
            else if (playerTurn == 'r')
            {
               button.BackColor = Color.Red;
            }
        }

        private void Connect4_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            button.BackColor = Color.White;
        }


        private void connect4_Load(object sender, EventArgs e)
        {
         
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Message = "Connect 4 Made by Caleb Harmon, David Topping, and Stacy Onyango";
            MessageBox.Show(Message, "About");
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gamesver.com/the-rules-of-connect-4-according-to-m-bradley-hasbro/");
        }

        private void TxtPlayerTurnInfo_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Changes the colour of the tile depending on the players turn
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="e"></param>
        private void BtnRow_MouseHover(Button btn, EventArgs e)
        {
            if(playerTurn == 'y')
            {
                btn.BackColor = Color.Yellow;
            }else if(playerTurn == 'r')
            {
                btn.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Clears the board of all tiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 7; i++)
            {
                Btn[i].BackColor = Color.White;
                for (int j = 0; j < 5; j++)
                {
                    lbl[i,j].BackColor = Color.White;
                }
            }
        }
    }
}
