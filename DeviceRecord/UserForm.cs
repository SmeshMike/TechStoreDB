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

namespace DeviceRecord
{
    public partial class UserForm : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TechStore.mdf";

        public UserForm()
        {
            InitializeComponent();
        }

        //List<string> getSellers()
        //{
        //    List<string> sellers;
        //    var request = "SELECT seller FROM Kochenyuk_abonent";
        //    var adapter = new SqlDataAdapter(request, connectionString);
        //    var contactTable = new DataTable();
        //    adapter.Fill(contactTable);
        //    contactTable.
        //    abonDVG.DataSource = contactTable;
        //    abonDVG.Columns["id"].Visible = false;
        //}

        private void addButton_Click(object sender, EventArgs e)
        {
            TsEntity db = new TsEntity();

            var supportRedactorForm = new SupportRedactorForm();
            var devices = db.devices.ToList();
            var accessories = db.device_accessories.ToList();


            List<string> temp = new List<string>();

            foreach (var device in devices)
            {
                if (!temp.Contains(device.seller))
                {
                    temp.Add(device.seller);
                    supportRedactorForm.sellerComboBox.Items.Add(device.seller);
                }
                if (!temp.Contains(device.type))
                {
                    temp.Add(device.type);
                    supportRedactorForm.typeComboBox.Items.Add(device.type);
                }
                if (!temp.Contains(device.responsible))
                {
                    temp.Add(device.responsible);
                    supportRedactorForm.responsibleComboBox.Items.Add(device.responsible);
                }
                if (!temp.Contains(device.placement))
                {
                    temp.Add(device.placement);
                    supportRedactorForm.placementComboBox.Items.Add(device.placement);
                }
            }

            foreach (var accessory in accessories)
            {
                if (!temp.Contains(accessory.seller))
                {
                    temp.Add(accessory.seller);
                    supportRedactorForm.sellerComboBox.Items.Add(accessory.seller);
                }
                if (!temp.Contains(accessory.type))
                {
                    temp.Add(accessory.type);
                    supportRedactorForm.typeComboBox.Items.Add(accessory.type);
                }
                if (!temp.Contains(accessory.responsible))
                {
                    temp.Add(accessory.responsible);
                    supportRedactorForm.responsibleComboBox.Items.Add(accessory.responsible);
                }
                if (!temp.Contains(accessory.placement))
                {
                    temp.Add(accessory.placement);
                    supportRedactorForm.placementComboBox.Items.Add(accessory.placement);
                }
            }

            supportRedactorForm.Show();

            
            
        }

        private void findButton_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            
                
                switch (tabControl.SelectedIndex)
                {

                    case 0:
                        var request = queryForFind("SELECT *FROM devices where 1=1", "deviceName");
                    if (string.IsNullOrWhiteSpace(request))
                        MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var adapter = new SqlDataAdapter(request, connectionString);
                        var table = new DataTable();
                        adapter.Fill(table);
                        devicesDGV.DataSource = table;
                    }
                        break;
                    case 1:  
                        request = queryForFind("SELECT *FROM devices_accessories where 1=1", "accessoryName");
                    if (string.IsNullOrWhiteSpace(request))
                        MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var adapter = new SqlDataAdapter(request, connectionString);
                        var table = new DataTable();
                        adapter.Fill(table);
                        accessoriesDGV.DataSource = table;
                    }
                        break;
                    case 2:
                        request = queryForFind(@"select d.deviceName , d.seller , d.type , d.price, d.placement, d.responsible, da.accessoryName , da.seller 'seller1', da.type 'type1', da.price 'price1', da.placement 'placement1', da.responsible 'responsible1'
                                                from dbo.devices as d
                                                join dbo.device_accessories as da
                                                on d.id = da.deviceId", "deviceName where 1=1");
                    if (string.IsNullOrWhiteSpace(request))
                        MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var adapter = new SqlDataAdapter(request, connectionString);
                        var table = new DataTable();
                        adapter.Fill(table);
                        devicesDGV.DataSource = table;
                    }
                    break;
                        default:
                        break;

                }



            
        }


        string queryForFind(string data, string name)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) || !string.IsNullOrEmpty(placementComboBox.Text) || !string.IsNullOrEmpty(responsibleTextBox.Text) || !string.IsNullOrEmpty(typeComboBox.Text))
            {
                string request = string.Format("{0}", data);

                if (!string.IsNullOrEmpty(nameTextBox.Text))
                    request += string.Format(" AND {0} LIKE N'%{1}%'", name, nameTextBox.Text);

                if (!string.IsNullOrEmpty(placementComboBox.Text))
                    request += string.Format(" AND placement LIKE N'%{0}%'", placementComboBox.Text);

                if (!string.IsNullOrEmpty(responsibleTextBox.Text))
                    request += string.Format(" AND  responsible LIKE N'%{0}%'", responsibleTextBox.Text);

                if (!string.IsNullOrEmpty(typeComboBox.Text))
                    request += string.Format(" AND  type LIKE N'%{0}%'", typeComboBox.Text);
                return request;
            }
            else
                return string.Empty;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            TsEntity db = new TsEntity();

            var devices = db.devices.Where(it => it.placement.Equals("Склад МТО")).ToList();
            var accessories = db.device_accessories.Where(it => it.placement.Equals("Склад МТО")).ToList();

            devicesDGV.DataSource = devices;
            devicesDGV.Columns["device_accessories"].Visible = false;
            devicesDGV.Columns["ip"].Visible = false;
            devicesDGV.Columns["networkName"].Visible = false;
            devicesDGV.Columns["subnetMask"].Visible = false;



            accessoriesDGV.DataSource = accessories;
            accessoriesDGV.Columns["devices"].Visible = false;


            collectionDGV.DataSource = db.supportCollection().Where(it => it.placement.Equals("Склад МТО")).ToList();

            FillTypeAndPlaces(devices, this);
        }

        public void FillTypeAndPlaces(List<devices> devices, UserForm form)
        {
            List<string> temp = new List<string>();

            foreach (var device in devices)
            {
                if (!temp.Contains(device.placement))
                {
                    temp.Add(device.placement);
                    form.placementComboBox.Items.Add(device.placement);
                }
                if (!temp.Contains(device.type))
                {
                    temp.Add(device.type);
                    form.typeComboBox.Items.Add(device.type);
                }
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (devicesDGV.SelectedRows.Count == 0 && accessoriesDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show(" Сначала выберите строчку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var row = devicesDGV.SelectedRows.Count > 0 ? devicesDGV.SelectedRows[0] : accessoriesDGV.SelectedRows[0];

            var serialNumber = row.Cells["serialNumber"].Value.ToString();



        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (devicesDGV.SelectedRows.Count == 0 && accessoriesDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show(" Сначала выберите строчку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var row = devicesDGV.SelectedRows.Count > 0 ? devicesDGV.SelectedRows[0] : accessoriesDGV.SelectedRows[0];

            var serialNumber = row.Cells["serialNumber"].Value.ToString();

        }
    }
}

