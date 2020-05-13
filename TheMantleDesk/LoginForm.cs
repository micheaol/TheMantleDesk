using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMantleDesk
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if(txtUsername.Text == "micheaol@gmail.com" && txtPassword.Text == "PassWord2020")
            {
                
                Dashboard page = new Dashboard();
                page.Show();
                this.Hide();
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                MessageBox.Show("Wrong Username OR Password!");
            }
        }

        private void btnCloseLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
