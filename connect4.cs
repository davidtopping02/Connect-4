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
        Label[,] lblGrid = new Label[7, 6];
        char playerTurn = 'r';

        System.Media.SoundPlayer player =
       new System.Media.SoundPlayer();
        /// <summary>
        /// default constructor
        /// </summary>
        public connect4()
        {
            InitializeComponent();
           // playMusic();

            //randomly selects a player to start
            selectRandomPlayer();

            //setting the player turn text
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

            //init each  grid label and their propertiesn
            for (int i = 0; i < 7; i++)
            {
                //initialise top labels (for the mouse hovers)
                initialiseTopLabels(i);

                for (int j = 0; j < 6; j++)
                {
                    initLabelPropery(i, j); 
                }

            }

        }

        private void initLabelPropery(int i, int j)
        {
            //init each label
            lblGrid[i, j] = new Label();

            //setting position and colour
            lblGrid[i, j].SetBounds(100 + (75 * i), 170 + (75 * j), 60, 60);
            lblGrid[i, j].BackColor = Color.White;

            //making labels circular
            var path2 = new System.Drawing.Drawing2D.GraphicsPath();
            path2.AddEllipse(0, 0, lblGrid[i, j].Width, lblGrid[i, j].Height);
            this.lblGrid[i, j].Region = new Region(path2);

            /*Event handlers*/
            //mouse overs
            lblGrid[i,j].MouseHover += delegate (object sender, EventArgs e) { gridLabelMouseHover(sender, e, i); };
            lblGrid[i,j].MouseLeave += delegate (object sender, EventArgs e) { gridLabelMouseLeave(sender, e, i); };

            //click
            lblGrid[i, j].Click += delegate (object sender, EventArgs e) { gridLabelClick(sender, e, i); };

            //adding the objects to the form
            Controls.Add(lblGrid[i, j]);

        }

        /// <summary>
        /// Top row of labels that appart on the mouse hover
        /// </summary>
        /// <param name="row"></param>
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

        /// <summary>
        /// Handles the event of the label clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="col"></param>
        private void gridLabelClick(object sender, EventArgs e, int col)
        {
            //when the top row is full
            if (lblGrid[col,0].BackColor != Color.White)
            {
                return;
            }

            // the label that is clicked
            Label labelClicked = (Label)sender;

           
            

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

            //calculating where in the grid the new peice should fall to
            if (lblGrid[col, 0].BackColor == Color.White)
            {
                int row = 0;

                while (lblGrid[col, row].BackColor == Color.White)
                {

                    if (row == 5)
                    {
                        break;
                    }
                    else if (lblGrid[col, row + 1].BackColor != Color.White)
                    {
                        break;
                    }

                    //increment row if it doesn't meet other conditions
                    row++;
                }

                //changing the colour of the tile once position calculated
                if (playerTurn == 'y')
                {
                    //dropping tile animation
                    dropAnimation(col, row);

                    //changing colour
                    lblGrid[col, row].BackColor = Color.Yellow;

                    row = 0;
                }
                else if (playerTurn == 'r')
                {
                    dropAnimation(col, row);

                    //changing colour
                    lblGrid[col, row].BackColor = Color.Red;
                    row = 0;
                }
            }

            //check for 4 in a row
            fourInRowChecker();
            
            //change player
            changePlayer();
        }

        /// <summary>
        /// Animates the peieces dropping down a column
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void dropAnimation(int col, int row)
        {
            //changing the top label
            if (lblGrid[col, 0].BackColor == Color.White)
            {
                //changing top label to colour
                lblGrid[col, 0].BackColor = Color.FromName(getColor());
                lblGrid[col, 0].Refresh();

                //wait
                Thread.Sleep(90);

                //back to white
                lblGrid[col, 0].BackColor = Color.White;
                lblGrid[col, 0].Refresh();
            }

            //animation for peice dropping labels
            for (int i = 0; i < row; i++)
            {

                //changing label to colour
                lblGrid[col, i].BackColor = Color.FromName(getColor());
                lblGrid[col, i].Refresh();

                //wait
                Thread.Sleep(90);

                //back to white
                lblGrid[col, i].BackColor = Color.White;
                lblGrid[col, i].Refresh();

            }
        }

        private void fourInRowChecker()
        {
            Boolean valid = false;

            //horizontal check

            //vertical check

            //ascending diagonal 

            //descending diagonal



            if (valid)
            {
                Console.WriteLine("WINNER");
            }
        }



        /*private void fourInRowChecker()
        {

            //this could be optimized so that if a win is optimized in vertical it doesnt check in horizontal... etc.

            checkVertical();
            checkHorizontal();
            checkDiagonal_downRight();
            checkDiagonal_downLeft();
            int open = 0;
            if (checkVertical() == false && checkHorizontal() == false && checkDiagonal_downLeft() == false && checkDiagonal_downRight() == false){

               for(int i =0 ; i < 7; i++)
                {
                   if(lblGrid[i,0].BackColor == Color.White)

                    {
                        open++;
                    }
                   
                }

               if(open == 0)
                {
                    txtBoxWin.Text = "draw";
                }

            }


        }*/


        private bool checkHorizontal()
        {

            int inARow = 0;

            //counting horizontal

            for (int i = 0; i < 6; i++)
            {
                //inARow = 0;
                for (int j = 0; j < 7; j++)
                {
                    // j is col, i is row
                    if (lblGrid[j, i].BackColor == Color.FromName(getColor()))
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
                        return true;
                    }

                }

            }
            return false;
        }

        private bool checkVertical()
        {

            int inARow = 0;

            for (int i = 0; i < 7; i++)
            {


                for (int j = 0; j < 6; j++)
                {
                    // i is col, j is row
                    if (lblGrid[i, j].BackColor == Color.FromName(getColor()))
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
                        return true;
                    }

                }

            }
            return false;
        }

        private bool checkDiagonal_downRight()
        {


            int inARow = 0;

            for (int i = 0; i < 4; i++)
            {


                for (int j = 0; j < 3; j++)
                {

                    //difference for diagonal
                    for (int d = 0; d < 4; d++)
                    {

                        // i is col, j is row
                        if (lblGrid[i + d, j + d].BackColor == Color.FromName(getColor()))
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
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        private bool checkDiagonal_downLeft()
        {


            int inARow = 0;

            for (int i = 6; i > 4; i--)
            {


                for (int j = 0; j < 3; j++)
                {

                    //difference for diagonal
                    for (int d = 0; d < 4; d++)
                    {

                        // i is col, j is row
                        if (lblGrid[i - d, j + d].BackColor == Color.FromName(getColor()))
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
                            return true;

                        }
                    }
                }

            }
            return false;
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
        private void gridLabelMouseHover(object sender, EventArgs e, int i)
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

        private void gridLabelMouseLeave(object sender, EventArgs e, int i)
        {
            lblTop[i].BackColor = Color.RoyalBlue;
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
                for (int j = 0; j < 6; j++)
                {
                    lblGrid[i, j].BackColor = Color.White;
                }
            }

            txtBoxWin.Text = "";
        }

        /// <summary>
        /// Getter for the player turn field
        /// </summary>
        /// <returns ></returns>
        private string getColor()
        {
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

            return player;

        }


        private void computerTurn()
        {
            Random rand = new Random();
            int move = rand.Next(7);
            int row = 0;

            if (playerTurn == 'r') {

                if (lblGrid[move, 0].BackColor == Color.White)
                {
                    while (lblGrid[move, row].BackColor == Color.White)
                    {

                        if (row == 5)
                        {
                            break;
                        }
                        else if (lblGrid[move, row + 1].BackColor != Color.White)
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
                        //dropAnimation(col, row);

                        //changing colour
                        lblGrid[move, row].BackColor = Color.Yellow;

                        row = 0;
                    }
                    else if (playerTurn == 'r')
                    {
                        //dropAnimation(col, row);

                        //changing colour
                        lblGrid[move, row].BackColor = Color.Red;
                        row = 0;
                    }
                }
            }

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

        private void txtBoxWin_TextChanged(object sender, EventArgs e)
        {

        }

        private void playMusic()
        {
           

            player.SoundLocation = @"connect4music.wav";
            player.Load();
            player.Play();
            
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            
            player.Stop();
          

        }
    }
}
