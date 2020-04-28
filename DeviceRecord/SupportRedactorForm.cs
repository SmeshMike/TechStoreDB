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
            var entryDate = Convert.ToDateTime(entryDateTextBox.Text);
            var price = priceTextBox.Text;
            var placement = placementComboBox.Text;
            var responsible = responsibleComboBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format(@"insert into dbo.devices(deviceName, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible)
	                                    values (N'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                                        name, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

              //  db.insertForSupport(name, serialNumber, guaranteeEnd, seller, type, entryDate, price, placement, responsible);
              //db.SaveChanges();

            }
            this.Close();
        }
    }
}
