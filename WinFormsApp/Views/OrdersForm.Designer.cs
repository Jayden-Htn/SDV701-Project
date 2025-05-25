namespace WinFormsApp.Views
{
    partial class OrdersForm
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
            OrdersPanel = new FlowLayoutPanel();
            CloseButton = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            TotalValueLabel = new Label();
            SuspendLayout();
            // 
            // OrdersPanel
            // 
            OrdersPanel.AutoScroll = true;
            OrdersPanel.BackColor = SystemColors.ControlLight;
            OrdersPanel.FlowDirection = FlowDirection.TopDown;
            OrdersPanel.Location = new Point(29, 167);
            OrdersPanel.Name = "OrdersPanel";
            OrdersPanel.Size = new Size(921, 356);
            OrdersPanel.TabIndex = 11;
            OrdersPanel.WrapContents = false;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(848, 44);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(102, 31);
            CloseButton.TabIndex = 8;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12.1846151F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 95);
            label2.Name = "label2";
            label2.Size = new Size(80, 30);
            label2.TabIndex = 7;
            label2.Text = "Orders";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8461533F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 38);
            label1.Name = "label1";
            label1.Size = new Size(338, 35);
            label1.TabIndex = 6;
            label1.Text = "GrassMaster's Admin Client";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(47, 143);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 12;
            label3.Text = "Item";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(253, 143);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 13;
            label4.Text = "Pricing";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(466, 143);
            label5.Name = "label5";
            label5.Size = new Size(115, 21);
            label5.TabIndex = 14;
            label5.Text = "Customer Info";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(695, 143);
            label6.Name = "label6";
            label6.Size = new Size(112, 21);
            label6.TabIndex = 15;
            label6.Text = "Time Ordered";
            // 
            // TotalValueLabel
            // 
            TotalValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TotalValueLabel.AutoSize = true;
            TotalValueLabel.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalValueLabel.ImageAlign = ContentAlignment.TopRight;
            TotalValueLabel.Location = new Point(862, 104);
            TotalValueLabel.Name = "TotalValueLabel";
            TotalValueLabel.Size = new Size(88, 21);
            TotalValueLabel.TabIndex = 18;
            TotalValueLabel.Text = "Total Value";
            TotalValueLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 546);
            Controls.Add(TotalValueLabel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(OrdersPanel);
            Controls.Add(CloseButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OrdersForm";
            Text = "OrdersForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OrdersPanel;
        private Button CloseButton;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label TotalValueLabel;
    }
}