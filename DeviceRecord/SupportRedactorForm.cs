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
    public partial class SupportRedactorForm : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TechStore.mdf";

        public SupportRedactorForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            TsEntity db = new TsEntity();
            
            var name = nameTextBox.Text;
            var serialNumber = Convert.ToInt32(serialNumberTextBox.Text);
            var guaranteeEnd = Convert.ToDateTime(guaranteeTextBox.Text);
            var seller = sellerComboBox.Text;
            var type = typeComboBox.Text;
            var globalType = globalTypeComboBox.Text;
            var entryDate = Convert.ToDateTime(entryDateTextBox.Text);
            var price = priceTextBox.Text;
            var placement = placementComboBox.Text;
            var responsible = responsibleComboBox.Text;
            var id = 0;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    var command = new SqlCommand();
            //    command.CommandType = CommandType.Text;
            //    command.CommandText = string.Format(@"insert into dbo.devices(deviceName, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible)
            //                         values (N'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
            //                            name, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible);
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //db.SaveChanges();
            switch (Text)
            {
                case "Добавить устройство":
                    if (type == "ПК" || type == "Ноутбук" || type == "Моноблок" || globalType == "Устройство")
                    {
                        db.devices.Add(new devices()
                        {
                            deviceName = name,
                            serialNumber = serialNumber,
                            guaranteeEnd = guaranteeEnd,
                            seller = seller,
                            type = type,
                            entryDate = entryDate,
                            price = price,
                            placement = placement,
                            responsible = responsible
                        });
                        db.SaveChanges();
                    }
                    if (type == "Мышь" || type == "Клавиатура" || type == "Геймпад" || type == "Аудио-система" || globalType == "Комплектующее")
                    {
                        db.device_accessories.Add(new device_accessories()
                        {
                            accessoryName = name,
                            serialNumber = serialNumber,
                            guaranteeEnd = guaranteeEnd,
                            seller = seller,
                            type = type,
                            entryDate = entryDate,
                            price = price,
                            placement = placement,
                            responsible = responsible
                        });
                        db.SaveChanges();
                    }
                        break;
                case "Редактировать устройство":
                    id = Convert.ToInt32(db.devices.Where(it => it.deviceName == name).FirstOrDefault().id);
                    db.UpdateDeviceForSupport(id, name, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible);
                    break;
                case "Редактировать комплекктующее к устройству":
                    id = Convert.ToInt32(db.device_accessories.Where(it => it.accessoryName == name).FirstOrDefault().id);
                    db.UpdateAccessoryForSupport(id, name, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible);
                    break;
                default:
                    return;

            }
            this.Close();
        }

        private void typeComboBox_Validated(object sender, EventArgs e)
        {
            if (typeComboBox.Items.Contains(typeComboBox.Text))
            {
                var type = typeComboBox.Text;
                if (type == "Мышь" || type == "Клавиатура" || type == "Геймпад" || type == "Аудио-система")
                    globalTypeComboBox.Text = "Комплектующее";
                if (type == "ПК" || type == "Ноутбук" || type == "Моноблок")
                    globalTypeComboBox.Text = "Устройство";
            }
        }
    }
}
