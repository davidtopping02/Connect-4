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
        Label[,] lbl = new Label[7, 6];
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

            Btn[i].MouseHover += new EventHandler(Connect4_MouseHover);
            Btn[i].MouseLeave += new EventHandler(Connect4_MouseLeave);

            Controls.Add(Btn[i]);
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
    }
}
