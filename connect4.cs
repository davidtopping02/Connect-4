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

        computer compPlayer = new computer('m');

        System.Media.SoundPlayer player =
       new System.Media.SoundPlayer();

        /// <summary>
        /// default constructor
        /// </summary>
        public connect4(Boolean isPvp)
        {
            InitializeComponent();
            playMusic();

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
                    initLabelPropery(i, j, isPvp);
                }

            }
        }

        

        private void initLabelPropery(int i, int j, bool isPvp)
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
            lblGrid[i, j].MouseHover += delegate (object sender, EventArgs e) { gridLabelMouseHover(sender, e, i); };
            lblGrid[i, j].MouseLeave += delegate (object sender, EventArgs e) { gridLabelMouseLeave(sender, e, i); };

            //click
            lblGrid[i, j].Click += delegate (object sender, EventArgs e) { gridLabelClick(sender, e, i, isPvp); };

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
        private void gridLabelClick(object sender, EventArgs e, int col, Boolean isPvp)
        {
            if (!compPlayer.getTurn())
            {

                //when the top row is full
                if (lblGrid[col, 0].BackColor != Color.White)
                {
                    return;
                }


                //changing the top label accordingly
                if (playerTurn == 'y' && isPvp == true)
                {
                    lblTop[col].BackColor = Color.Red;
                    lblTop[col].Refresh();
                }
                else if (playerTurn == 'r' && isPvp == true)
                {
                    lblTop[col].BackColor = Color.Yellow;
                    lblTop[col].Refresh();
                }

                //placing the tile
                placeTile(col);

                //check for 4 in a row
                if (fourInRowChecker())
                {
                    DialogResult result = MessageBox.Show("\t     " + getColor() + " is the WINNER! \n\tWould you like to play again?", "WINNER!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Menu men = new Menu();

                        this.Hide();
                        men.ShowDialog();
                        this.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }

                //check if the game is drawn
                checkDraw();

                //change player
                changePlayer();

                //switch to computer turn if its pvc
                if (isPvp == false)
                {
                    compPlayer.flipTurn();
                    computerTurn();
                }
            }
        }

        private void placeTile(int col)
        {

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
        }

        private void computerTurn()
        {
            if (compPlayer.getTurn() == true)
            {
                TxtPlayerTurnInfo.Text = "Computer Playing...";
                TxtPlayerTurnInfo.Refresh();    

                int move = compPlayer.computerMove();

                placeTile(move);
                if (fourInRowChecker())
                {
                    DialogResult result = MessageBox.Show("\t     " + getColor() + " is the WINNER! \n\tWould you like to play again?", "WINNER!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Menu men = new Menu();

                        this.Hide();
                        men.ShowDialog();
                        this.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
                //check if the game is a draw
                checkDraw();
                changePlayer();
                compPlayer.flipTurn();



            }


        }

        /// <summary>
        /// Animates the peieces dropping down a column
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void dropAnimation(int col, int row)
        {
            //animation for peice dropping labels
            for (int i = 0; i < row+1; i++)
            {

                //changing label to colour
                lblGrid[col, i].BackColor = Color.FromName(getColor());
                lblGrid[col, i].Refresh();

                //wait
                Thread.Sleep(90);

                //back to white
                if (i != row)
                {
                    lblGrid[col, i].BackColor = Color.White;
                    lblGrid[col, i].Refresh();
                }

            }
        }

        private Boolean fourInRowChecker()
        {
            int highest = 0;
            int location = 0;
            //vertical check
            for (int col = 0; col < 7; col++)
            {
                int counter = 0;

                for (int row = 0; row < 6; row++)
                {
                    if (counter >= 4)
                    {
                      break;
                    }
                    else if (lblGrid[col, row].BackColor == Color.FromName(getColor()))
                    {
                        counter++;
                    }
                    else
                    {
                        //setting highest to whatever the highest counter was
                        if (counter > highest) highest = counter;
                        //location of next best move
                        location = col;
                        counter = 0;
                    }
                }

                if (counter >= 4)
                {
                    DialogResult result = MessageBox.Show("Vertical win");
                    return true;
                }
            }

            //horizontal check
            for (int row = 0; row < 6; row++)
            {
                int counter = 0;

                for (int col = 0; col < 7; col++)
                {
                    if (lblGrid[col, row].BackColor == Color.FromName(getColor()))
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > highest) highest = counter;
                        //location of next best move
                        location = col;
                        counter = 0;
                    }

                    if (counter >= 4)
                    {
                        DialogResult result = MessageBox.Show("Horizontal win");
                        return true;
                    }
                }
            }



            //descending diagonal
            for (int col = 0; col < 4; col++)
            {
                int counter = 0;

                for (int row = 0; row < 3; row++)
                {
                    counter = 0;

                    for (int offset = 0; offset < 4; offset++)
                    {
                        if (lblGrid[col + offset, row + offset].BackColor == Color.FromName(getColor()))
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter > highest) highest = counter;
                            //location of next best move
                            location = col-1;
                            counter = 0;
                        }
                        if (counter >= 4)
                        {
                            DialogResult result = MessageBox.Show("Descending diagonal win");
                            return true;
                        }
                    }
                }
            }


            //ascending diagonal 
            for (int col = 6; col > 2; col--)
            {
                int counter = 0;

                for (int row = 0; row < 3; row++)
                {
                    counter = 0;
                    //difference for diagonal
                    for (int offset = 0; offset < 4; offset++)
                    {
                        if (lblGrid[col - offset, row + offset].BackColor == Color.FromName(getColor()))
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter > highest) highest = counter;
                            //location of next best move
                            location = col+1;
                            counter = 0;
                        }
                        if (counter >= 4)
                        {
                            DialogResult result = MessageBox.Show("ascending Diagonal win");
                            return true;
                        }
                    }
                }
            }

            //if the top row is not open, i.e if a column is full
            if(lblGrid[location, 0].BackColor != Color.White){
                location = location + 100;
            }
            compPlayer.setBestCoordinate(location, highest);

            return false;

        }

        private void checkDraw()
        {
            int openCols = 0;
            for (int i = 0; i < 7; i++)
            {
                if (lblGrid[i, 0].BackColor == Color.White)
                {
                    openCols++;
                }
            }
            if (openCols == 0)
            {
                DialogResult result = MessageBox.Show("The game is a DRAW \n\tWould you like to play again?", "WINNER!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Menu men = new Menu();

                    this.Hide();
                    men.ShowDialog();
                    this.Close();
                }
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
           

            player.SoundLocation =  AppDomain.CurrentDomain.BaseDirectory + "\\connect4music.wav";
            player.Load();
            player.Play();
            
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            
            player.Stop();
          

        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            {
                Menu men = new Menu();

                this.Hide();
                men.ShowDialog();
                this.Close();
            }
        }

      
    }
}
