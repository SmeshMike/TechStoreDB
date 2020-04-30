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

        private void addButton_Click(object sender, EventArgs e)
        {
            TsEntity db = new TsEntity();

            var supportRedactorForm = new SupportRedactorForm();
            supportRedactorForm.Text = "Добавить устройство";

            var devices = db.devices.ToList();
            var accessories = db.device_accessories.ToList();

            FillSupportComboBoxes(devices, accessories, supportRedactorForm);

            supportRedactorForm.Show();
            supportRedactorForm.Text = "Добавить устройство";
            if (Text == "Администратор отдела МТО")
            {
                supportRedactorForm.label5.Visible = false;
                supportRedactorForm.label6.Visible = false;
                supportRedactorForm.label7.Visible = false;
                supportRedactorForm.ipTextBox.Visible = false;
                supportRedactorForm.networkNameTextBox.Visible = false;
                supportRedactorForm.subnetMaskTextBox.Visible = false;
            }

            supportRedactorForm.FormClosed += (sen, even) =>
            {
                this.Refresh_Click(sender, e);
            };
        }

        private void findButton_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string whereCondition = "";

            if (Text == "Администратор отдела МТО")
                whereCondition = "Склад МТО";
            else
                whereCondition = "Склад тестировщиков";

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
                        request = queryForFind("SELECT *FROM device_accessories where placement = N'" + whereCondition+"'", "accessoryName");
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
                      

        public void Refresh_Click(object sender, EventArgs e)
        {
            TsEntity db = new TsEntity();

            string whereCondition = "";

            if (Text == "Администратор отдела МТО")
                whereCondition = "Склад МТО";
            else
                whereCondition = "Склад тестировщиков";

            var devices = db.devices.Where(it => it.placement.Equals(whereCondition)).ToList();
            var accessories = db.device_accessories.Where(it => it.placement.Equals(whereCondition)).ToList();

            devicesDGV.DataSource = devices;
            devicesDGV.Columns["device_accessories"].Visible = false;

            if (Text == "Администратор отдела МТО")
            {
                devicesDGV.Columns["ip"].Visible = false;
                devicesDGV.Columns["networkName"].Visible = false;
                devicesDGV.Columns["subnetMask"].Visible = false;
            }


            accessoriesDGV.DataSource = accessories;
            accessoriesDGV.Columns["devices"].Visible = false;


            collectionDGV.DataSource = db.supportCollection().Where(it => it.placement.Equals(whereCondition)).ToList();


            placementComboBox.Items.Clear();
            typeComboBox.Items.Clear();

            FillTypeAndPlaces(devices, this);
        }


        private void editButton_Click(object sender, EventArgs e)
        {
            var supportRedactorForm = new SupportRedactorForm();

            TsEntity db = new TsEntity();

            supportRedactorForm.nameTextBox.Enabled = false;
            supportRedactorForm.serialNumberTextBox.Enabled = false;
            supportRedactorForm.entryDateTextBox.Enabled = false;
            supportRedactorForm.guaranteeTextBox.Enabled = false;
            supportRedactorForm.sellerComboBox.Enabled = false;
            supportRedactorForm.typeComboBox.Enabled = false;
            supportRedactorForm.globalTypeComboBox.Enabled = false;
            supportRedactorForm.priceTextBox.Enabled = false;
            



            if (devicesDGV.SelectedRows.Count == 0 && accessoriesDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show(" Сначала выберите строчку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (devicesDGV.SelectedRows.Count >= 1 && accessoriesDGV.SelectedRows.Count >= 1)
            {
                MessageBox.Show(" Выбрано слишком много строк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Text == "Администратор отдела МТО")
            {
                supportRedactorForm.label5.Visible = false;
                supportRedactorForm.label6.Visible = false;
                supportRedactorForm.label7.Visible = false;
                supportRedactorForm.ipTextBox.Visible = false;
                supportRedactorForm.networkNameTextBox.Visible = false;
                supportRedactorForm.subnetMaskTextBox.Visible = false;
            }


            var row = devicesDGV.SelectedRows.Count > 0 ? devicesDGV.SelectedRows[0] : accessoriesDGV.SelectedRows[0];


            if (devicesDGV.SelectedRows.Count > 0)
            {
                var devices = db.devices.ToList();
                supportRedactorForm.Text = "Редактировать устройство";
                supportRedactorForm.nameTextBox.Text = row.Cells["deviceName"].Value.ToString();
                supportRedactorForm.serialNumberTextBox.Text = row.Cells["serialNumber"].Value.ToString();
                supportRedactorForm.guaranteeTextBox.Text = row.Cells["guaranteeEnd"].Value.ToString();
                supportRedactorForm.sellerComboBox.Text = row.Cells["seller"].Value.ToString();
                supportRedactorForm.typeComboBox.Text = row.Cells["type"].Value.ToString();
                supportRedactorForm.entryDateTextBox.Text = row.Cells["entryDate"].Value.ToString();
                supportRedactorForm.priceTextBox.Text = row.Cells["price"].Value.ToString();
                supportRedactorForm.placementComboBox.Text = row.Cells["placement"].Value.ToString();
                supportRedactorForm.responsibleComboBox.Text = row.Cells["responsible"].Value.ToString();
                supportRedactorForm.globalTypeComboBox.Text = "Устройство";
                if (Text == "Администратор отдела тестировки")
                {
                    supportRedactorForm.networkNameTextBox.Text = row.Cells["networkName"].Value.ToString();
                    supportRedactorForm.ipTextBox.Text = row.Cells["ip"].Value.ToString();
                    supportRedactorForm.subnetMaskTextBox.Text = row.Cells["subnetMask"].Value.ToString();
                }
                FillSupportComboBoxes(devices, null, supportRedactorForm);
            }

            if (accessoriesDGV.SelectedRows.Count > 0)
            {
                var accessories = db.device_accessories.ToList();
                supportRedactorForm.Text = "Редактировать комплекктующее к устройству";
                supportRedactorForm.nameTextBox.Text = row.Cells["accessoryName"].Value.ToString();
                supportRedactorForm.serialNumberTextBox.Text = row.Cells["serialNumber"].Value.ToString();
                supportRedactorForm.guaranteeTextBox.Text = row.Cells["guaranteeEnd"].Value.ToString();
                supportRedactorForm.sellerComboBox.Text = row.Cells["seller"].Value.ToString();
                supportRedactorForm.typeComboBox.Text = row.Cells["type"].Value.ToString();
                supportRedactorForm.entryDateTextBox.Text = row.Cells["entryDate"].Value.ToString();
                supportRedactorForm.priceTextBox.Text = row.Cells["price"].Value.ToString();
                supportRedactorForm.placementComboBox.Text = row.Cells["placement"].Value.ToString();
                supportRedactorForm.responsibleComboBox.Text = row.Cells["responsible"].Value.ToString();
                supportRedactorForm.label5.Visible = false;
                supportRedactorForm.label6.Visible = false;
                supportRedactorForm.label7.Visible = false;
                supportRedactorForm.ipTextBox.Visible = false;
                supportRedactorForm.networkNameTextBox.Visible = false;
                supportRedactorForm.subnetMaskTextBox.Visible = false;
                supportRedactorForm.globalTypeComboBox.Text = "Комплектующее";
                FillSupportComboBoxes(null, accessories, supportRedactorForm);
            }
            supportRedactorForm.Show();

            supportRedactorForm.FormClosed += (sen, even) =>
            {
                this.Refresh_Click(sender, e);
            };

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            TsEntity db = new TsEntity();

            if (devicesDGV.SelectedRows.Count == 0 && accessoriesDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show(" Сначала выберите строчку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var row = devicesDGV.SelectedRows.Count > 0 ? devicesDGV.SelectedRows[0] : accessoriesDGV.SelectedRows[0];

            if (devicesDGV.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                db.devices.Remove(db.devices.Where(it => it.id == id).FirstOrDefault());
                db.SaveChanges();
            }

            if (accessoriesDGV.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(row.Cells["id"].Value.ToString());
            }

            this.Refresh_Click(sender, e);

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

        void FillSupportComboBoxes(List<devices> devices, List<device_accessories> accessories, SupportRedactorForm form)
        {
            List<string> temp = new List<string>();

            form.globalTypeComboBox.Items.Add("Устройство");
            form.globalTypeComboBox.Items.Add("Комплектующее");

            
            if (devices != null)
            {
                foreach (var device in devices)
                {
                    if (!temp.Contains(device.seller))
                    {
                        temp.Add(device.seller);
                        form.sellerComboBox.Items.Add(device.seller);
                    }
                    if (!temp.Contains(device.type))
                    {
                        temp.Add(device.type);
                        form.typeComboBox.Items.Add(device.type);
                    }
                    if (!temp.Contains(device.responsible))
                    {
                        temp.Add(device.responsible);
                        form.responsibleComboBox.Items.Add(device.responsible);
                    }
                    if (!temp.Contains(device.placement))
                    {
                        temp.Add(device.placement);
                        form.placementComboBox.Items.Add(device.placement);
                    }
                }
            }
            if (accessories != null)
            {
                foreach (var device in accessories)
                {
                    if (!temp.Contains(device.seller))
                    {
                        temp.Add(device.seller);
                        form.sellerComboBox.Items.Add(device.seller);
                    }
                    if (!temp.Contains(device.type))
                    {
                        temp.Add(device.type);
                        form.typeComboBox.Items.Add(device.type);
                    }
                    if (!temp.Contains(device.responsible))
                    {
                        temp.Add(device.responsible);
                        form.responsibleComboBox.Items.Add(device.responsible);
                    }
                    if (!temp.Contains(device.placement))
                    {
                        temp.Add(device.placement);
                        form.placementComboBox.Items.Add(device.placement);
                    }
                }
            }
        }


        string queryForFind(string data, string name)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) || !string.IsNullOrEmpty(placementComboBox.Text) || !string.IsNullOrEmpty(responsibleTextBox.Text) || !string.IsNullOrEmpty(serialNumberTextBox.Text)
                || !string.IsNullOrEmpty(typeComboBox.Text) || !string.IsNullOrEmpty(ipTextBox.Text) || !string.IsNullOrEmpty(networkNameTextBox.Text) || !string.IsNullOrEmpty(subnetMaskTextBox.Text))
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
                
                if (!string.IsNullOrEmpty(serialNumberTextBox.Text))
                    request += string.Format(" AND  serialNumber LIKE N'%{0}%'", serialNumberTextBox.Text);

                if (!string.IsNullOrEmpty(ipTextBox.Text))
                    request += string.Format(" AND  ip LIKE N'%{0}%'", ipTextBox.Text);

                if (!string.IsNullOrEmpty(networkNameTextBox.Text))
                    request += string.Format(" AND  networkName LIKE N'%{0}%'", networkNameTextBox.Text);

                if (!string.IsNullOrEmpty(subnetMaskTextBox.Text))
                    request += string.Format(" AND  subnetMask LIKE N'%{0}%'", subnetMaskTextBox.Text);
                return request;
            }
            else
                return string.Empty;
        }
    }
}

