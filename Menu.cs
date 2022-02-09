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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void playerVsPlayer_Click(object sender, EventArgs e)
        {
            connect4 game = new connect4(true);

            this.Hide();
            game.ShowDialog();
            this.Close();
        }

        private void playerVsComputer_Click(object sender, EventArgs e)
        {
            connect4 game = new connect4(false);

            this.Hide();
            game.ShowDialog();
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
