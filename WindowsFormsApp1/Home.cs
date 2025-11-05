using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Open the login form
            FrmLogin f = new FrmLogin("ADMIN");
            f.Show();
            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Open the login form
            FrmLogin f = new FrmLogin("USER");
            f.Show();
            this.Hide();

        }
        
        private void FrmHome_Load(object sender, EventArgs e)
        {
        }
    }
}
