using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Windows.Forms;

namespace TheMantleDesk
{
    public partial class Form3 : Form
    {
        DataTable dt = new DataTable();

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vzblsQLEqSkOFO2cqPutcImakuMc3NQ3v9IMtz32",
            BasePath = "https://themantleapp.firebaseio.com/",

        };

        IFirebaseClient client;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            dt.Columns.Add("id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Phone No");
            dt.Columns.Add("Department");
            dt.Columns.Add("Location");

            dataGridView1.DataSource = dt;

        }

        private void BtnRetreiveData_Click(object sender, EventArgs e)
        {
            export();
        }

        private async void export()
        {
            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnt = Convert.ToInt32(obj1.cnt);

            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Persons/"+i);
                    Data obj2 = resp2.ResultAs<Data>();

                    DataRow row = dt.NewRow();
                    row["id"] = obj2.Id;
                    row["Name"] = obj2.Name;
                    row["Phone No"] = obj2.PhoneNo;
                    row["Department"] = obj2.Department;
                    row["Location"] = obj2.Location;

                    dt.Rows.Add(row);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            MessageBox.Show("Done");
        }
    }
}
