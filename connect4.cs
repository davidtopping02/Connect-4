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
        //initialising piece spaces
        Label[,] lbl = new Label[7, 6];
        Button[] Btn = new Button[7];
        
        /// <summary>
        /// default constructor
        /// </summary>
        public connect4()
        {
            InitializeComponent();

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
            Controls.Add(Btn[i]);
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
    }
}
