using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceRecord;

namespace DeviceRecord
{

    public partial class Connector : Form
    {

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TechStore.mdf";

        public Connector()
        {
            InitializeComponent();
        }




        private void testButton_Click(object sender, EventArgs e)
        {
            var form = new UserForm();
            //this.supButton.Enabled = false;
            //this.testButton.Enabled = false;
            TsEntity db = new TsEntity();
            form.Text = "Администратор отдела тестировки";

            var devices = db.devices.Where(it => it.placement.Equals("Склад тестировщиков")).ToList();
            var accessories = db.device_accessories.Where(it => it.placement.Equals("Склад тестировщиков")).ToList();

            form.devicesDGV.DataSource = devices;
            form.devicesDGV.Columns["device_accessories"].Visible = false;
            

            form.accessoriesDGV.DataSource = accessories;
            form.accessoriesDGV.Columns["devices"].Visible = false;


            form.collectionDGV.DataSource = db.supportCollection().Where(it => it.placement.Equals("Склад тестировщиков")).ToList();

            form.FillTypeAndPlaces(devices, form);

            form.addButton.Visible = false;

            form.Show();
        }



        private void supButton_Click(object sender, EventArgs e)
        {
            var form = new UserForm();
            //this.supButton.Enabled = false;
            //this.testButton.Enabled = false;
            form.ipTextBox.Visible = false;
            form.subnetMaskTextBox.Visible = false;
            form.networkNameTextBox.Visible = false;
            form.label5.Visible = false;
            form.label6.Visible = false;
            form.label7.Visible = false;
            TsEntity db = new TsEntity();
            form.Text = "Администратор отдела МТО";


            var devices = db.devices.Where(it => it.placement.Equals("Склад МТО")).ToList(); 
            var accessories = db.device_accessories.Where(it => it.placement.Equals("Склад МТО")).ToList(); 

            form.devicesDGV.DataSource = devices;
            form.devicesDGV.Columns["device_accessories"].Visible = false;
            form.devicesDGV.Columns["ip"].Visible = false;
            form.devicesDGV.Columns["networkName"].Visible = false;
            form.devicesDGV.Columns["subnetMask"].Visible = false;


            form.accessoriesDGV.DataSource = accessories;
            form.accessoriesDGV.Columns["devices"].Visible = false;


            form.collectionDGV.DataSource = db.supportCollection().Where(it => it.placement.Equals("Склад МТО")).ToList();

            form.FillTypeAndPlaces(devices, form);

           
            
            form.Show();
        }
    }
}
