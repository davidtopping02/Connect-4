using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4_Game
{
    public partial class Form1 : Form
    {
        Button[,] button = new Button[7, 6];

        private MainMenu Connectmenu;


        public Form1()
        {
            //Still working on it but am open to make any changes
            //ignore the x and y boxes give what you think i should add
            InitializeComponent();
            Application.EnableVisualStyles();
            for (int x = 0; x < button.GetLength(0); x++)
            {
                for (int y = 0; y < button.GetLength(1); y++)
                {
                    button[x, y] = new Button();
                    button[x, y].SetBounds(55 + (55 * x), 55 + (55 * y), 60, 60);
                    /*button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Red;
                    button.FlatAppearance.BorderSize = 1;*/
                   // button.FlatAppearance.BorderColor = System.Drawing.Color.Blue;

                    Controls.Add(button[x, y]);

                }
            }

            Connectmenu = new MainMenu();
            MenuItem Information = Connectmenu.MenuItems.Add("&Information");
            Information.MenuItems.Add(new MenuItem("&Instructions", new EventHandler(this.InformationInstructions_Click)));
            Information.MenuItems.Add(new MenuItem("&Creators", new EventHandler(this.InformationCreators_Click)));
            MenuItem Options = Connectmenu.MenuItems.Add("&Option");
            Options.MenuItems.Add(new MenuItem("&New", new EventHandler(this.OptionsNew_Click)));
            // Options.MenuItems.Add(new MenuItem("&Save", new EventHandler(this.OptionsSave_Click)));
            Options.MenuItems.Add(new MenuItem("&Exit", new EventHandler(this.OptionsExit_Click)));
            this.Menu = Connectmenu;
        }

        private void OptionsNew_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Restart", "Yes/No", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.Yes:
                    Application.Restart();
                    break;
                case DialogResult.No:
                    this.Hide();
                    break;
                    /*case DialogResult.Cancel:
                        break;*/
            }

        }

        private void InformationInstructions_Click(object sender, EventArgs e)
        {

        }

        private void InformationCreators_Click(object sender, EventArgs e)
        {

        }
        private void OptionsExit_Click(object sender, EventArgs e)
        {
            switch(MessageBox.Show("Are You Sure You Want To Exit", "Yes/No", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.Yes:
                    Close();
                    break;
                case DialogResult.No:
                 
                    break;
            }
        }

        /* private void OptionsSave_Click(object sender, EventArgs e)
         {

         }*/
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}

