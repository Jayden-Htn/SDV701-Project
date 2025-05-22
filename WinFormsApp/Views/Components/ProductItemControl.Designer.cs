namespace WinFormsApp.Views
{
    partial class ProductItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameLabel = new Label();
            DescriptionLabel = new Label();
            PriceLabel = new Label();
            StockLabel = new Label();
            BrandLabel = new Label();
            TypeLabel = new Label();
            ImageBox = new PictureBox();
            EditButton = new Button();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI Semibold", 9.969231F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(33, 22);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(105, 25);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "NameLabel";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.Location = new Point(33, 59);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(416, 95);
            DescriptionLabel.TabIndex = 1;
            DescriptionLabel.Text = "DescriptionLabel";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceLabel.Location = new Point(33, 165);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(46, 21);
            PriceLabel.TabIndex = 2;
            PriceLabel.Text = "Price";
            // 
            // StockLabel
            // 
            StockLabel.AutoSize = true;
            StockLabel.Location = new Point(145, 165);
            StockLabel.Name = "StockLabel";
            StockLabel.Size = new Size(47, 21);
            StockLabel.TabIndex = 3;
            StockLabel.Text = "Stock";
            // 
            // BrandLabel
            // 
            BrandLabel.AutoSize = true;
            BrandLabel.Location = new Point(251, 165);
            BrandLabel.Name = "BrandLabel";
            BrandLabel.Size = new Size(51, 21);
            BrandLabel.TabIndex = 4;
            BrandLabel.Text = "Brand";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(373, 165);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(42, 21);
            TypeLabel.TabIndex = 5;
            TypeLabel.Text = "Type";
            // 
            // ImageBox
            // 
            ImageBox.BackColor = SystemColors.ControlDarkDark;
            ImageBox.Location = new Point(469, 22);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(164, 164);
            ImageBox.TabIndex = 6;
            ImageBox.TabStop = false;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(655, 22);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(102, 31);
            EditButton.TabIndex = 7;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(655, 74);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(102, 31);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // ProductItemControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(ImageBox);
            Controls.Add(TypeLabel);
            Controls.Add(BrandLabel);
            Controls.Add(StockLabel);
            Controls.Add(PriceLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(NameLabel);
            Name = "ProductItemControl";
            Size = new Size(778, 208);
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label DescriptionLabel;
        private Label PriceLabel;
        private Label StockLabel;
        private Label BrandLabel;
        private Label TypeLabel;
        private PictureBox ImageBox;
        private Button EditButton;
        private Button DeleteButton;
    }
}
