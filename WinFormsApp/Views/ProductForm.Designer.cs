namespace WinFormsApp.Views
{
    partial class ProductForm
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
            label2 = new Label();
            label1 = new Label();
            SaveButton = new Button();
            CloseButton = new Button();
            NameInput = new TextBox();
            FuelDetailsInput = new TextBox();
            label3 = new Label();
            LastUpdatedLabel = new Label();
            TypeSpecificLabel = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            StockNumeric = new NumericUpDown();
            BrandCombo = new ComboBox();
            label4 = new Label();
            DescriptionInput = new TextBox();
            pictureBox1 = new PictureBox();
            AddImageButton = new Button();
            DeleteImageButton = new Button();
            PriceNumeric = new NumericUpDown();
            TypeInput = new TextBox();
            TypeSpecificNumeric = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)StockNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PriceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TypeSpecificNumeric).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12.1846151F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 82);
            label2.Name = "label2";
            label2.Size = new Size(135, 30);
            label2.TabIndex = 3;
            label2.Text = "Edit Product";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8461533F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(338, 35);
            label1.TabIndex = 2;
            label1.Text = "GrassMaster's Admin Client";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(803, 62);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(102, 31);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += OnSaveButtonClick;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(803, 25);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(102, 31);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += OnCloseButtonClick;
            // 
            // NameInput
            // 
            NameInput.Location = new Point(25, 152);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(279, 29);
            NameInput.TabIndex = 6;
            // 
            // FuelDetailsInput
            // 
            FuelDetailsInput.Location = new Point(25, 335);
            FuelDetailsInput.Name = "FuelDetailsInput";
            FuelDetailsInput.Size = new Size(281, 29);
            FuelDetailsInput.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 130);
            label3.Name = "label3";
            label3.Size = new Size(45, 19);
            label3.TabIndex = 13;
            label3.Text = "Name";
            // 
            // LastUpdatedLabel
            // 
            LastUpdatedLabel.AutoSize = true;
            LastUpdatedLabel.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LastUpdatedLabel.Location = new Point(25, 573);
            LastUpdatedLabel.Name = "LastUpdatedLabel";
            LastUpdatedLabel.Size = new Size(91, 19);
            LastUpdatedLabel.TabIndex = 14;
            LastUpdatedLabel.Text = "Last Updated";
            // 
            // TypeSpecificLabel
            // 
            TypeSpecificLabel.AutoSize = true;
            TypeSpecificLabel.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TypeSpecificLabel.Location = new Point(25, 497);
            TypeSpecificLabel.Name = "TypeSpecificLabel";
            TypeSpecificLabel.Size = new Size(97, 19);
            TypeSpecificLabel.TabIndex = 15;
            TypeSpecificLabel.Text = "TypeFieldLabel";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 313);
            label6.Name = "label6";
            label6.Size = new Size(79, 19);
            label6.TabIndex = 16;
            label6.Text = "Fuel Details";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 435);
            label7.Name = "label7";
            label7.Size = new Size(37, 19);
            label7.TabIndex = 17;
            label7.Text = "Type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(25, 374);
            label8.Name = "label8";
            label8.Size = new Size(45, 19);
            label8.TabIndex = 18;
            label8.Text = "Brand";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(25, 252);
            label9.Name = "label9";
            label9.Size = new Size(100, 19);
            label9.TabIndex = 19;
            label9.Text = "Stock Available";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(25, 191);
            label10.Name = "label10";
            label10.Size = new Size(38, 19);
            label10.TabIndex = 20;
            label10.Text = "Price";
            // 
            // StockNumeric
            // 
            StockNumeric.Location = new Point(25, 274);
            StockNumeric.Name = "StockNumeric";
            StockNumeric.Size = new Size(133, 29);
            StockNumeric.TabIndex = 21;
            // 
            // BrandCombo
            // 
            BrandCombo.FormattingEnabled = true;
            BrandCombo.Location = new Point(23, 396);
            BrandCombo.Name = "BrandCombo";
            BrandCombo.Size = new Size(279, 29);
            BrandCombo.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.753846F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(530, 130);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 24;
            label4.Text = "Description";
            // 
            // DescriptionInput
            // 
            DescriptionInput.Location = new Point(530, 152);
            DescriptionInput.Multiline = true;
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.Size = new Size(375, 212);
            DescriptionInput.TabIndex = 25;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDarkDark;
            pictureBox1.Location = new Point(738, 386);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(164, 164);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // AddImageButton
            // 
            AddImageButton.Location = new Point(616, 423);
            AddImageButton.Name = "AddImageButton";
            AddImageButton.Size = new Size(102, 31);
            AddImageButton.TabIndex = 28;
            AddImageButton.Text = "Add";
            AddImageButton.UseVisualStyleBackColor = true;
            // 
            // DeleteImageButton
            // 
            DeleteImageButton.Location = new Point(616, 386);
            DeleteImageButton.Name = "DeleteImageButton";
            DeleteImageButton.Size = new Size(102, 31);
            DeleteImageButton.TabIndex = 27;
            DeleteImageButton.Text = "Remove";
            DeleteImageButton.UseVisualStyleBackColor = true;
            // 
            // PriceNumeric
            // 
            PriceNumeric.DecimalPlaces = 2;
            PriceNumeric.Location = new Point(25, 213);
            PriceNumeric.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PriceNumeric.Name = "PriceNumeric";
            PriceNumeric.Size = new Size(133, 29);
            PriceNumeric.TabIndex = 29;
            // 
            // TypeInput
            // 
            TypeInput.Location = new Point(23, 457);
            TypeInput.Name = "TypeInput";
            TypeInput.ReadOnly = true;
            TypeInput.Size = new Size(281, 29);
            TypeInput.TabIndex = 30;
            TypeInput.UseWaitCursor = true;
            // 
            // TypeSpecificNumeric
            // 
            TypeSpecificNumeric.Location = new Point(25, 521);
            TypeSpecificNumeric.Name = "TypeSpecificNumeric";
            TypeSpecificNumeric.Size = new Size(133, 29);
            TypeSpecificNumeric.TabIndex = 31;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 616);
            Controls.Add(TypeSpecificNumeric);
            Controls.Add(TypeInput);
            Controls.Add(PriceNumeric);
            Controls.Add(AddImageButton);
            Controls.Add(DeleteImageButton);
            Controls.Add(pictureBox1);
            Controls.Add(DescriptionInput);
            Controls.Add(label4);
            Controls.Add(BrandCombo);
            Controls.Add(StockNumeric);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(TypeSpecificLabel);
            Controls.Add(LastUpdatedLabel);
            Controls.Add(label3);
            Controls.Add(FuelDetailsInput);
            Controls.Add(NameInput);
            Controls.Add(SaveButton);
            Controls.Add(CloseButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProductForm";
            Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)StockNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PriceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)TypeSpecificNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Button SaveButton;
        private Button CloseButton;
        private TextBox NameInput;
        private TextBox FuelDetailsInput;
        private Label label3;
        private Label LastUpdatedLabel;
        private Label TypeSpecificLabel;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private NumericUpDown StockNumeric;
        private ComboBox BrandCombo;
        private Label label4;
        private TextBox DescriptionInput;
        private PictureBox pictureBox1;
        private Button AddImageButton;
        private Button DeleteImageButton;
        private NumericUpDown PriceNumeric;
        private TextBox TypeInput;
        private NumericUpDown TypeSpecificNumeric;
    }
}