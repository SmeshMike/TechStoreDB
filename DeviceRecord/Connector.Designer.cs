namespace DeviceRecord
{
    partial class Connector
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.supButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // supButton
            // 
            this.supButton.Location = new System.Drawing.Point(12, 103);
            this.supButton.Name = "supButton";
            this.supButton.Size = new System.Drawing.Size(101, 23);
            this.supButton.TabIndex = 0;
            this.supButton.Text = "Отдел МТО";
            this.supButton.UseVisualStyleBackColor = true;
            this.supButton.Click += new System.EventHandler(this.supButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(163, 103);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(101, 23);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Отдел тестов";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Здравствуйте, товарищ администратор.\nСлегка забыли, а вы из какого отдела?";
            // 
            // Connector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 143);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.supButton);
            this.Name = "Connector";
            this.Text = "Connector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button supButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label label1;
    }
}

