using FireSharp.Response;
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
using FireSharp.Response;
using FireSharp.Interfaces;

namespace TheMantleDesk
{
    public partial class RegStudent : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vzblsQLEqSkOFO2cqPutcImakuMc3NQ3v9IMtz32",
            BasePath = "https://themantleapp.firebaseio.com/",

        };

        IFirebaseClient client;

        public RegStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RegStudent_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

        }

        private async void BtnRegisterStudent_Click(object sender, EventArgs e)
        {
            FirebaseResponse resp = await client.GetTaskAsync("Counter/node");
            Counter_class get = resp.ResultAs<Counter_class>();

            /*MessageBox.Show(get.cnt);*/
            
            if (!string.IsNullOrEmpty(TxtStudentName.Text) && !string.IsNullOrEmpty(TxtStudentPhoneNumber.Text) && !string.IsNullOrEmpty(TxtStudentDepartment.Text) && !string.IsNullOrEmpty(TxtStudentLocation.Text))
            {
                var data = new Data
                {
                    Id = (Convert.ToInt32(get.cnt)+1).ToString(),
                    Name = TxtStudentName.Text,
                    PhoneNo = TxtStudentPhoneNumber.Text,
                    Department = TxtStudentDepartment.Text,
                    Location = TxtStudentLocation.Text,
                };

                SetResponse response = await client.SetTaskAsync("Persons/" + data.Id, data);
                Data result = response.ResultAs<Data>();

                txtStudentID.Text = "";
                TxtStudentName.Text = "";
                TxtStudentPhoneNumber.Text = "";
                TxtStudentDepartment.Text = "";
                TxtStudentLocation.Text = "";


                MessageBox.Show("Success Registration. Your ID is: ", result.Id);


                var obj = new Counter_class
                {
                    cnt = data.Id
                };
                SetResponse response1 = await client.SetTaskAsync("Counter/node", obj);

            }
            else
            {
                MessageBox.Show("Please fill all the field!");
            }
           
        }

        private void BtnFormReset_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            TxtStudentName.Text = "";
            TxtStudentPhoneNumber.Text = "";
            TxtStudentDepartment.Text = "";
            TxtStudentLocation.Text = "";
        }
    }
}
