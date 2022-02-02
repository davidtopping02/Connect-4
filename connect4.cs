using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace connect4Assignment
{
    public partial class connect4 : Form
    {
        //init global variables/objects
        Label[] lblTop = new Label[7];
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
            else if (playerTurn == 'r')
            {
                TxtPlayerTurnInfo.ForeColor = Color.Red;
                TxtPlayerTurnInfo.Text = "Red's Turn.";
            }

            //init each label and position
            for (int i = 0; i < 7; i++)
            {
                //initialise top labels for the mouse hovers
                initialiseTopLabels(i);

                //Initializing the buttons
                initialize_Btn(i);

                for (int j = 0; j < 5; j++)
                {
                    //init each label
                    lbl[i, j] = new Label();

                    //setting position and colour
                    lbl[i, j].SetBounds(100 + (75 * i), 230 + (75 * j), 60, 60);
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

        private void initialiseTopLabels(int row)
        {
            //init each label
            lblTop[row] = new Label();

            //setting position and colour
            lblTop[row].BackColor = Color.RoyalBlue;
            lblTop[row].SetBounds(100 + (75 * row), 90, 60, 60);

            //making labels circular
            var path2 = new System.Drawing.Drawing2D.GraphicsPath();
            path2.AddEllipse(0, 0, lblTop[row].Width, lblTop[row].Height);
            this.lblTop[row].Region = new Region(path2);

            //adding to the controls
            Controls.Add(lblTop[row]);
        }

        /// <summary>
        /// Selects a random player yellow or red
        /// </summary>
        private void selectRandomPlayer()
        {
            //init local variables
            char[] options = { 'y', 'r' };
            var randomNum = new Random();

            //getting random option r or y
            char op = options[randomNum.Next(options.Length)];

            //setting the player turn to the random option
            playerTurn = op;
        }

        private void initialize_Btn(int i)
        {
            Btn[i] = new Button();
            Btn[i].SetBounds(100 + (75 * i), 160, 60, 60);
            Btn[i].BackColor = Color.White;
            Btn[i].FlatAppearance.BorderSize = 0;
            Btn[i].TabStop = false;
            Btn[i].FlatStyle = FlatStyle.Flat;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, Btn[i].Width, Btn[i].Height);
            this.Btn[i].Region = new Region(path);

            //changing the colour of the buttons when they are hovered over
            Btn[i].MouseHover += delegate (object sender, EventArgs e) { Connect4_MouseHover(sender, e, i); };
            Btn[i].MouseLeave += delegate (object sender, EventArgs e) { Connect4_MouseLeave(sender, e, i); };

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

            //changing the top label accordingly
            if (playerTurn == 'y')
            {
                lblTop[col].BackColor = Color.Red;
                lblTop[col].Refresh();
            }
            else if (playerTurn == 'r')
            {
                lblTop[col].BackColor = Color.Yellow;
                lblTop[col].Refresh();
            }

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
                    //dropping tile animation
                    dropAnimation(col, row);

                    //changing colour
                    lbl[col, row].BackColor = Color.Yellow;

                    row = 0;
                }
                else if (playerTurn == 'r')
                {
                    dropAnimation(col, row);

                    //changing colour
                    lbl[col, row].BackColor = Color.Red;
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
                    row = 0;
                }
                else if (playerTurn == 'r')
                {
                    buttonClicked.BackColor = Color.Red;
                    row = 0;
                }
            }

            //check for 4 in a row
            fourInRowChecker(col, row);
            changePlayer();
        }

        /// <summary>
        /// Animates the peieces dropping down a column
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void dropAnimation(int col, int row)
        {
            if (playerTurn == 'y')
            {
                //changing the top button
                if (Btn[col].BackColor == Color.White)
                {
                    //changing top button to yellow
                    Btn[col].BackColor = Color.Yellow;
                    Btn[col].Refresh();

                    //wait
                    Thread.Sleep(110);

                    //back to white
                    Btn[col].BackColor = Color.White;
                    Btn[col].Refresh();
                }

                //animation for peice dropping labels
                for (int i = 0; i < row; i++)
                {

                    //changing label yellow
                    lbl[col, i].BackColor = Color.Yellow;
                    lbl[col, i].Refresh();

                    //wait
                    Thread.Sleep(110);

                    //back to white
                    lbl[col, i].BackColor = Color.White;
                    lbl[col, i].Refresh();

                }
            }

            if (playerTurn == 'r')
            {
                //changing the top button
                if (Btn[col].BackColor == Color.White)
                {
                    //changing top button to yellow
                    Btn[col].BackColor = Color.Red;
                    Btn[col].Refresh();

                    //wait
                    Thread.Sleep(110);

                    //back to white
                    Btn[col].BackColor = Color.White;
                    Btn[col].Refresh();
                }

                //animation for peice dropping labels
                for (int i = 0; i < row; i++)
                {

                    //changing label yellow
                    lbl[col, i].BackColor = Color.Red;
                    lbl[col, i].Refresh();

                    //wait
                    Thread.Sleep(110);

                    //back to white
                    lbl[col, i].BackColor = Color.White;
                    lbl[col, i].Refresh();

                }
            }
        }

        private void fourInRowChecker(int col, int row)
        {

            checkVertical();
            checkHorizontal();



        }

        private void checkHorizontal()
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
            //counting horizontal

            for (int i = 0; i < 5; i++)
            {
                //inARow = 0;
                for (int j = 0; j < 7; j++)
                {
                    // j is col, i is row
                    if (lbl[j, i].BackColor == Color.FromName(player))
                    {
                        inARow++;
                    }
                    else
                    {
                        inARow = 0;
                    }
                   // txtBoxWin.Text = Convert.ToString(inARow);
                    if (inARow >= 4)
                    {
                        txtBoxWin.Text = "Winner";
                        break;
                    }

                }

            }
        }

        private void checkVertical()
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
            for (int i = 0; i < 7; i++)
            {


                inARow = 0;
                for (int j = 0; j < 5; j++)
                {
                    // i is col, j is row
                    if (lbl[i, j].BackColor == Color.FromName(player))
                    {
                        inARow++;
                    }
                    else
                    {
                        inARow = 0;
                    }
                   // txtBoxWin.Text = Convert.ToString(inARow2);
                    if (inARow >= 4)
                    {
                        txtBoxWin.Text = "Winner";
                        break;
                    }

                }

            }
        }

        private void checkDiagonal()
        {

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
        private void Connect4_MouseHover(object sender, EventArgs e, int i)
        {

            if (playerTurn == 'y')
            {
                lblTop[i].BackColor = Color.Yellow;
            }
            else if (playerTurn == 'r')
            {
                lblTop[i].BackColor = Color.Red;
            }
        }

        private void Connect4_MouseLeave(object sender, EventArgs e, int i)
        {
            lblTop[i].BackColor = Color.RoyalBlue;
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
            if (playerTurn == 'y')
            {
                btn.BackColor = Color.Yellow;
            }
            else if (playerTurn == 'r')
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
            for (int i = 0; i < 7; i++)
            {
                Btn[i].BackColor = Color.White;
                for (int j = 0; j < 5; j++)
                {
                    lbl[i, j].BackColor = Color.White;
                }
            }
        }

        private void txtBoxWin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
