using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocDeNotas.Forms
{
    public partial class frm : Form
    {
        public String name { get; set; }
        public frm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_Load(object sender, EventArgs e)
        {

        }

        
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (txtNameGuna.Text == String.Empty)
            {
                MessageBox.Show("Please enter the name");
            }
            else
            {
                name = txtNameGuna.Text;
                this.Close();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }
    }
}
