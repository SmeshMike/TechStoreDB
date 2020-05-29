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
            form.devicesDGV.Columns["id"].Visible = false;
            form.devicesDGV.Columns["device_accessories"].Visible = false;
            form.devicesDGV.Columns["deviceName"].HeaderText = "Наименование";
            form.devicesDGV.Columns["serialNumber"].HeaderText = "Серийный номер";
            form.devicesDGV.Columns["guaranteeEnd"].HeaderText = "Гарантия до";
            form.devicesDGV.Columns["seller"].HeaderText = "Продавец";
            form.devicesDGV.Columns["type"].HeaderText = "Тип";
            form.devicesDGV.Columns["entryDate"].HeaderText = "Дата поступления";
            form.devicesDGV.Columns["price"].HeaderText = "Цена";
            form.devicesDGV.Columns["placement"].HeaderText = "Размещение";
            form.devicesDGV.Columns["responsible"].HeaderText = "Ответственный";
            form.devicesDGV.Columns["device_accessories"].Visible = false;
            form.devicesDGV.Columns["ip"].HeaderText = "IP";
            form.devicesDGV.Columns["networkName"].HeaderText = "Название сети";
            form.devicesDGV.Columns["subnetMask"].HeaderText = "Маска подсети";

            form.accessoriesDGV.DataSource = accessories;
            form.accessoriesDGV.Columns["devices"].Visible = false;
            form.accessoriesDGV.Columns["id"].Visible = false;
            form.accessoriesDGV.Columns["deviceId"].Visible = false;
            form.accessoriesDGV.Columns["accessoryName"].HeaderText = "Наименование";
            form.accessoriesDGV.Columns["serialNumber"].HeaderText = "Серийный номер";
            form.accessoriesDGV.Columns["guaranteeEnd"].HeaderText = "Гарантия до";
            form.accessoriesDGV.Columns["seller"].HeaderText = "Продавец";
            form.accessoriesDGV.Columns["type"].HeaderText = "Тип";
            form.accessoriesDGV.Columns["entryDate"].HeaderText = "Дата поступления";
            form.accessoriesDGV.Columns["price"].HeaderText = "Цена";
            form.accessoriesDGV.Columns["placement"].HeaderText = "Размещение";
            form.accessoriesDGV.Columns["responsible"].HeaderText = "Ответственный";



            form.collectionDGV.DataSource = db.supportCollection().Where(it => it.placement.Equals("Склад тестировщиков")).ToList();
            form.collectionDGV.Columns["deviceName"].HeaderText = "Наименование устройства";
            form.collectionDGV.Columns["seller"].HeaderText = "Продавец";
            form.collectionDGV.Columns["type"].HeaderText = "Тип";
            form.collectionDGV.Columns["price"].HeaderText = "Цена";
            form.collectionDGV.Columns["placement"].HeaderText = "Размещение";
            form.collectionDGV.Columns["responsible"].HeaderText = "Ответственный";
            form.collectionDGV.Columns["accessoryName"].HeaderText = "Наименование аксессуара";
            form.collectionDGV.Columns["seller1"].HeaderText = "Продавец";
            form.collectionDGV.Columns["type1"].HeaderText = "Тип";
            form.collectionDGV.Columns["price1"].HeaderText = "Цена";
            form.collectionDGV.Columns["placement1"].HeaderText = "Размещение";
            form.collectionDGV.Columns["responsible1"].HeaderText = "Ответственный";

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
            form.devicesDGV.Columns["id"].Visible = false;
            form.devicesDGV.Columns["device_accessories"].Visible = false;
            form.devicesDGV.Columns["ip"].Visible = false;
            form.devicesDGV.Columns["networkName"].Visible = false;
            form.devicesDGV.Columns["subnetMask"].Visible = false;
            form.devicesDGV.Columns["deviceName"].HeaderText = "Наименование";
            form.devicesDGV.Columns["serialNumber"].HeaderText = "Серийный номер";
            form.devicesDGV.Columns["guaranteeEnd"].HeaderText = "Гарантия до";
            form.devicesDGV.Columns["seller"].HeaderText = "Продавец";
            form.devicesDGV.Columns["type"].HeaderText = "Тип";
            form.devicesDGV.Columns["entryDate"].HeaderText = "Дата поступления";
            form.devicesDGV.Columns["price"].HeaderText = "Цена";
            form.devicesDGV.Columns["placement"].HeaderText = "Размещение";
            form.devicesDGV.Columns["responsible"].HeaderText = "Ответственный";

            form.accessoriesDGV.DataSource = accessories;
            form.accessoriesDGV.Columns["devices"].Visible = false;
            form.accessoriesDGV.Columns["id"].Visible = false;
            form.accessoriesDGV.Columns["deviceId"].Visible = false;
            form.accessoriesDGV.Columns["accessoryName"].HeaderText = "Наименование";
            form.accessoriesDGV.Columns["serialNumber"].HeaderText = "Серийный номер";
            form.accessoriesDGV.Columns["guaranteeEnd"].HeaderText = "Гарантия до";
            form.accessoriesDGV.Columns["seller"].HeaderText = "Продавец";
            form.accessoriesDGV.Columns["type"].HeaderText = "Тип";
            form.accessoriesDGV.Columns["entryDate"].HeaderText = "Дата поступления";
            form.accessoriesDGV.Columns["price"].HeaderText = "Цена";
            form.accessoriesDGV.Columns["placement"].HeaderText = "Размещение";
            form.accessoriesDGV.Columns["responsible"].HeaderText = "Ответственный";


            form.collectionDGV.DataSource = db.supportCollection().Where(it => it.placement.Equals("Склад МТО")).ToList();
            form.collectionDGV.Columns["deviceName"].HeaderText = "Наименование устройства";
            form.collectionDGV.Columns["seller"].HeaderText = "Продавец";
            form.collectionDGV.Columns["type"].HeaderText = "Тип";
            form.collectionDGV.Columns["price"].HeaderText = "Цена";
            form.collectionDGV.Columns["placement"].HeaderText = "Размещение";
            form.collectionDGV.Columns["responsible"].HeaderText = "Ответственный";
            form.collectionDGV.Columns["accessoryName"].HeaderText = "Наименование аксессуара";
            form.collectionDGV.Columns["seller1"].HeaderText = "Продавец";
            form.collectionDGV.Columns["type1"].HeaderText = "Тип";
            form.collectionDGV.Columns["price1"].HeaderText = "Цена";
            form.collectionDGV.Columns["placement1"].HeaderText = "Размещение";
            form.collectionDGV.Columns["responsible1"].HeaderText = "Ответственный";

            form.FillTypeAndPlaces(devices, form);

           
            
            form.Show();
        }
    }
}
