namespace WinFormsApp.Views.Components
{
    partial class OrderItemControl
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
            IdLabel = new Label();
            ProductLabel = new Label();
            PriceLabel = new Label();
            QuantityLabel = new Label();
            TotalPriceLabel = new Label();
            CustomerNameLabel = new Label();
            CustomerEmailLabel = new Label();
            CustomerPhoneLabel = new Label();
            DateOrderedLabel = new Label();
            CompleteCheckbox = new CheckBox();
            DeleteButton = new Button();
            BrandLabel = new Label();
            SuspendLayout();
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(15, 15);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(25, 21);
            IdLabel.TabIndex = 0;
            IdLabel.Text = "ID";
            // 
            // ProductLabel
            // 
            ProductLabel.AutoSize = true;
            ProductLabel.Location = new Point(65, 15);
            ProductLabel.Name = "ProductLabel";
            ProductLabel.Size = new Size(64, 21);
            ProductLabel.TabIndex = 1;
            ProductLabel.Text = "Product";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(220, 15);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(106, 21);
            PriceLabel.TabIndex = 2;
            PriceLabel.Text = "Price per item";
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(220, 46);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(61, 21);
            QuantityLabel.TabIndex = 3;
            QuantityLabel.Text = "X items";
            // 
            // TotalPriceLabel
            // 
            TotalPriceLabel.AutoSize = true;
            TotalPriceLabel.Location = new Point(220, 79);
            TotalPriceLabel.Name = "TotalPriceLabel";
            TotalPriceLabel.Size = new Size(45, 21);
            TotalPriceLabel.TabIndex = 4;
            TotalPriceLabel.Text = "Total:";
            // 
            // CustomerNameLabel
            // 
            CustomerNameLabel.AutoSize = true;
            CustomerNameLabel.Location = new Point(434, 15);
            CustomerNameLabel.Name = "CustomerNameLabel";
            CustomerNameLabel.Size = new Size(124, 21);
            CustomerNameLabel.TabIndex = 5;
            CustomerNameLabel.Text = "Customer Name";
            // 
            // CustomerEmailLabel
            // 
            CustomerEmailLabel.AutoSize = true;
            CustomerEmailLabel.Location = new Point(434, 46);
            CustomerEmailLabel.Name = "CustomerEmailLabel";
            CustomerEmailLabel.Size = new Size(120, 21);
            CustomerEmailLabel.TabIndex = 6;
            CustomerEmailLabel.Text = "Customer Email";
            // 
            // CustomerPhoneLabel
            // 
            CustomerPhoneLabel.AutoSize = true;
            CustomerPhoneLabel.Location = new Point(434, 79);
            CustomerPhoneLabel.Name = "CustomerPhoneLabel";
            CustomerPhoneLabel.Size = new Size(126, 21);
            CustomerPhoneLabel.TabIndex = 7;
            CustomerPhoneLabel.Text = "Customer Phone";
            // 
            // DateOrderedLabel
            // 
            DateOrderedLabel.AutoSize = true;
            DateOrderedLabel.Location = new Point(666, 15);
            DateOrderedLabel.Name = "DateOrderedLabel";
            DateOrderedLabel.Size = new Size(76, 21);
            DateOrderedLabel.TabIndex = 8;
            DateOrderedLabel.Text = "DateTime";
            // 
            // CompleteCheckbox
            // 
            CompleteCheckbox.AutoSize = true;
            CompleteCheckbox.Location = new Point(666, 46);
            CompleteCheckbox.Name = "CompleteCheckbox";
            CompleteCheckbox.Size = new Size(108, 25);
            CompleteCheckbox.TabIndex = 9;
            CompleteCheckbox.Text = "Completed";
            CompleteCheckbox.UseVisualStyleBackColor = true;
            CompleteCheckbox.CheckedChanged += CompleteCheckbox_CheckedChanged;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(666, 77);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(102, 31);
            DeleteButton.TabIndex = 10;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // BrandLabel
            // 
            BrandLabel.AutoSize = true;
            BrandLabel.Location = new Point(65, 46);
            BrandLabel.Name = "BrandLabel";
            BrandLabel.Size = new Size(51, 21);
            BrandLabel.TabIndex = 11;
            BrandLabel.Text = "Brand";
            // 
            // OrderItemControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BrandLabel);
            Controls.Add(DeleteButton);
            Controls.Add(CompleteCheckbox);
            Controls.Add(DateOrderedLabel);
            Controls.Add(CustomerPhoneLabel);
            Controls.Add(CustomerEmailLabel);
            Controls.Add(CustomerNameLabel);
            Controls.Add(TotalPriceLabel);
            Controls.Add(QuantityLabel);
            Controls.Add(PriceLabel);
            Controls.Add(ProductLabel);
            Controls.Add(IdLabel);
            Name = "OrderItemControl";
            Size = new Size(842, 118);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdLabel;
        private Label ProductLabel;
        private Label PriceLabel;
        private Label QuantityLabel;
        private Label TotalPriceLabel;
        private Label CustomerNameLabel;
        private Label CustomerEmailLabel;
        private Label CustomerPhoneLabel;
        private Label DateOrderedLabel;
        private CheckBox CompleteCheckbox;
        private Button DeleteButton;
        private Label BrandLabel;
    }
}
