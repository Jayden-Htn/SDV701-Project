namespace WinFormsApp.Views
{
    partial class ProductsForm
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
            label1 = new Label();
            label2 = new Label();
            QuitButton = new Button();
            ProductsPanel = new FlowLayoutPanel();
            OrdersButton = new Button();
            FilterCombo = new ComboBox();
            AddButton = new Button();
            CreateTypeCombo = new ComboBox();
            BrandDescLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8461533F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 26);
            label1.Name = "label1";
            label1.Size = new Size(338, 35);
            label1.TabIndex = 0;
            label1.Text = "GrassMaster's Admin Client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12.1846151F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 83);
            label2.Name = "label2";
            label2.Size = new Size(100, 30);
            label2.TabIndex = 1;
            label2.Text = "Products";
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(741, 12);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(102, 31);
            QuitButton.TabIndex = 3;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            // 
            // ProductsPanel
            // 
            ProductsPanel.AutoScroll = true;
            ProductsPanel.BackColor = SystemColors.ControlLight;
            ProductsPanel.FlowDirection = FlowDirection.TopDown;
            ProductsPanel.Location = new Point(28, 138);
            ProductsPanel.Name = "ProductsPanel";
            ProductsPanel.Size = new Size(815, 427);
            ProductsPanel.TabIndex = 5;
            ProductsPanel.WrapContents = false;
            // 
            // OrdersButton
            // 
            OrdersButton.Location = new Point(741, 49);
            OrdersButton.Name = "OrdersButton";
            OrdersButton.Size = new Size(102, 31);
            OrdersButton.TabIndex = 4;
            OrdersButton.Text = "Orders";
            OrdersButton.UseVisualStyleBackColor = true;
            OrdersButton.Click += OrdersButton_Click;
            // 
            // FilterCombo
            // 
            FilterCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterCombo.FormattingEnabled = true;
            FilterCombo.Location = new Point(149, 87);
            FilterCombo.Name = "FilterCombo";
            FilterCombo.Size = new Size(164, 29);
            FilterCombo.TabIndex = 1;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(741, 85);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(102, 31);
            AddButton.TabIndex = 5;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // CreateTypeCombo
            // 
            CreateTypeCombo.FormattingEnabled = true;
            CreateTypeCombo.Location = new Point(619, 87);
            CreateTypeCombo.Name = "CreateTypeCombo";
            CreateTypeCombo.Size = new Size(116, 29);
            CreateTypeCombo.TabIndex = 2;
            // 
            // BrandDescLabel
            // 
            BrandDescLabel.AutoSize = true;
            BrandDescLabel.Location = new Point(318, 91);
            BrandDescLabel.Name = "BrandDescLabel";
            BrandDescLabel.Size = new Size(89, 21);
            BrandDescLabel.TabIndex = 14;
            BrandDescLabel.Text = "Description";
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 593);
            Controls.Add(BrandDescLabel);
            Controls.Add(CreateTypeCombo);
            Controls.Add(AddButton);
            Controls.Add(FilterCombo);
            Controls.Add(OrdersButton);
            Controls.Add(ProductsPanel);
            Controls.Add(QuitButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProductsForm";
            Text = "ProductsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button QuitButton;
        private FlowLayoutPanel ProductsPanel;
        private Button OrdersButton;
        private ComboBox FilterCombo;
        private Button AddButton;
        private ComboBox CreateTypeCombo;
        private Label BrandDescLabel;
    }
}