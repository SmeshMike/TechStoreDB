namespace DeviceRecord
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Devices = new System.Windows.Forms.TabPage();
            this.devicesDGV = new System.Windows.Forms.DataGridView();
            this.Accessories = new System.Windows.Forms.TabPage();
            this.accessoriesDGV = new System.Windows.Forms.DataGridView();
            this.Collection = new System.Windows.Forms.TabPage();
            this.collectionDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.responsibleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.placementComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.findButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.networkNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.subnetMaskTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.Devices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesDGV)).BeginInit();
            this.Accessories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessoriesDGV)).BeginInit();
            this.Collection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collectionDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Devices);
            this.tabControl.Controls.Add(this.Accessories);
            this.tabControl.Controls.Add(this.Collection);
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1417, 359);
            this.tabControl.TabIndex = 0;
            // 
            // Devices
            // 
            this.Devices.Controls.Add(this.devicesDGV);
            this.Devices.Location = new System.Drawing.Point(4, 22);
            this.Devices.Name = "Devices";
            this.Devices.Padding = new System.Windows.Forms.Padding(3);
            this.Devices.Size = new System.Drawing.Size(1409, 333);
            this.Devices.TabIndex = 0;
            this.Devices.Text = "Компьютеры";
            this.Devices.UseVisualStyleBackColor = true;
            // 
            // devicesDGV
            // 
            this.devicesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesDGV.Location = new System.Drawing.Point(0, 0);
            this.devicesDGV.Name = "devicesDGV";
            this.devicesDGV.RowHeadersWidth = 45;
            this.devicesDGV.Size = new System.Drawing.Size(1409, 337);
            this.devicesDGV.TabIndex = 0;
            // 
            // Accessories
            // 
            this.Accessories.Controls.Add(this.accessoriesDGV);
            this.Accessories.Location = new System.Drawing.Point(4, 22);
            this.Accessories.Name = "Accessories";
            this.Accessories.Padding = new System.Windows.Forms.Padding(3);
            this.Accessories.Size = new System.Drawing.Size(1409, 333);
            this.Accessories.TabIndex = 1;
            this.Accessories.Text = "Переферия";
            this.Accessories.UseVisualStyleBackColor = true;
            // 
            // accessoriesDGV
            // 
            this.accessoriesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accessoriesDGV.Location = new System.Drawing.Point(0, 0);
            this.accessoriesDGV.Name = "accessoriesDGV";
            this.accessoriesDGV.RowHeadersWidth = 45;
            this.accessoriesDGV.Size = new System.Drawing.Size(1409, 333);
            this.accessoriesDGV.TabIndex = 0;
            // 
            // Collection
            // 
            this.Collection.Controls.Add(this.collectionDGV);
            this.Collection.Location = new System.Drawing.Point(4, 22);
            this.Collection.Name = "Collection";
            this.Collection.Size = new System.Drawing.Size(1409, 333);
            this.Collection.TabIndex = 2;
            this.Collection.Text = "Все компоненты";
            this.Collection.UseVisualStyleBackColor = true;
            // 
            // collectionDGV
            // 
            this.collectionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.collectionDGV.Location = new System.Drawing.Point(0, 0);
            this.collectionDGV.Name = "collectionDGV";
            this.collectionDGV.RowHeadersWidth = 45;
            this.collectionDGV.Size = new System.Drawing.Size(1409, 333);
            this.collectionDGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ответственный";
            // 
            // responsibleTextBox
            // 
            this.responsibleTextBox.Location = new System.Drawing.Point(20, 398);
            this.responsibleTextBox.Name = "responsibleTextBox";
            this.responsibleTextBox.Size = new System.Drawing.Size(121, 20);
            this.responsibleTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Размещение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тип";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(168, 400);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 20);
            this.nameTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Наименование";
            // 
            // placementComboBox
            // 
            this.placementComboBox.FormattingEnabled = true;
            this.placementComboBox.Location = new System.Drawing.Point(20, 441);
            this.placementComboBox.Name = "placementComboBox";
            this.placementComboBox.Size = new System.Drawing.Size(121, 21);
            this.placementComboBox.TabIndex = 9;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(168, 441);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.typeComboBox.TabIndex = 10;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(20, 521);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(269, 23);
            this.findButton.TabIndex = 11;
            this.findButton.Text = "Найти";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1264, 395);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(162, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Добавить устройство";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(1264, 424);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(162, 23);
            this.editButton.TabIndex = 13;
            this.editButton.Text = "Изменить параметры";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(1264, 453);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(162, 23);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Списать устройство";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(1264, 521);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(162, 23);
            this.Refresh.TabIndex = 15;
            this.Refresh.Text = "Обновить";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(467, 398);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(121, 20);
            this.ipTextBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "IP";
            // 
            // networkNameTextBox
            // 
            this.networkNameTextBox.Location = new System.Drawing.Point(467, 442);
            this.networkNameTextBox.Name = "networkNameTextBox";
            this.networkNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.networkNameTextBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Имя сети";
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(319, 397);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(121, 20);
            this.serialNumberTextBox.TabIndex = 21;
            // 
            // subnetMaskTextBox
            // 
            this.subnetMaskTextBox.Location = new System.Drawing.Point(319, 441);
            this.subnetMaskTextBox.Name = "subnetMaskTextBox";
            this.subnetMaskTextBox.Size = new System.Drawing.Size(121, 20);
            this.subnetMaskTextBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Маска подсети";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(316, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Серийный номер";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 556);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.subnetMaskTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.networkNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.placementComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.responsibleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.tabControl.ResumeLayout(false);
            this.Devices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.devicesDGV)).EndInit();
            this.Accessories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accessoriesDGV)).EndInit();
            this.Collection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collectionDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Devices;
        public System.Windows.Forms.DataGridView devicesDGV;
        private System.Windows.Forms.TabPage Accessories;
        public System.Windows.Forms.DataGridView accessoriesDGV;
        private System.Windows.Forms.TabPage Collection;
        public System.Windows.Forms.DataGridView collectionDGV;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox responsibleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox placementComboBox;
        public System.Windows.Forms.ComboBox typeComboBox;
        public System.Windows.Forms.Button findButton;
        public System.Windows.Forms.Button addButton;
        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.Button Refresh;
        public System.Windows.Forms.TextBox ipTextBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox networkNameTextBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox serialNumberTextBox;
        public System.Windows.Forms.TextBox subnetMaskTextBox;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
    }
}