using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TheMantleDesk
{
    public partial class Dashboard : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vzblsQLEqSkOFO2cqPutcImakuMc3NQ3v9IMtz32",
            BasePath = "https://themantleapp.firebaseio.com/",

        };

        IFirebaseClient client;
        public Dashboard()
        {
            InitializeComponent();
            customizedDesign();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Good connection!!");
            }

        }

        private void customizedDesign()
        {
            panelPlaylistSubMenu.Visible = false;
            panelDevotionalSubMenu.Visible = false;
            panelMantleCourseSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelPlaylistSubMenu.Visible == true)
                panelPlaylistSubMenu.Visible = false;

            if (panelDevotionalSubMenu.Visible == true)
                panelDevotionalSubMenu.Visible = false;

            if (panelMantleCourseSubMenu.Visible == true)
                panelMantleCourseSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }

        private void btnMantleCourse_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMantleCourseSubMenu);
        }

        private void btnRegisteration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegStudent());
            //TO DO:
            hideSubMenu();
        }

        private void btnRetrieveData_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            //TO DO:
            hideSubMenu();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private void btnDailyDevotional_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDevotionalSubMenu);
        }

        private void btnUploadDevotion_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private void btnUpdateDevotion_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private void btnDeleteDevotion_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private void btnAudioUpload_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        private void btnUploadMedia_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private void btnUpdateMedia_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private void btnDeleteMedia_Click(object sender, EventArgs e)
        {
            //TO DO:
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm Login = new LoginForm();
            Login.Show();
        }

        
    }
}
