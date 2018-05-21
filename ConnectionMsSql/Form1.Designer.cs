namespace ConnectionMsSql
{
    partial class Form1
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
            this.bConnect = new System.Windows.Forms.Button();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.bSelectAll = new System.Windows.Forms.Button();
            this.lbData = new System.Windows.Forms.ListBox();
            this.bSelectById = new System.Windows.Forms.Button();
            this.tbIdSelect = new System.Windows.Forms.TextBox();
            this.bAvgPrice = new System.Windows.Forms.Button();
            this.tbAvgPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(12, 12);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(350, 23);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bDisconnect
            // 
            this.bDisconnect.Enabled = false;
            this.bDisconnect.Location = new System.Drawing.Point(12, 41);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(350, 23);
            this.bDisconnect.TabIndex = 1;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // bSelectAll
            // 
            this.bSelectAll.Enabled = false;
            this.bSelectAll.Location = new System.Drawing.Point(13, 71);
            this.bSelectAll.Name = "bSelectAll";
            this.bSelectAll.Size = new System.Drawing.Size(349, 23);
            this.bSelectAll.TabIndex = 2;
            this.bSelectAll.Text = "Select All";
            this.bSelectAll.UseVisualStyleBackColor = true;
            this.bSelectAll.Click += new System.EventHandler(this.bSelectAll_Click);
            // 
            // lbData
            // 
            this.lbData.FormattingEnabled = true;
            this.lbData.Location = new System.Drawing.Point(11, 221);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(349, 134);
            this.lbData.TabIndex = 3;
            // 
            // bSelectById
            // 
            this.bSelectById.Enabled = false;
            this.bSelectById.Location = new System.Drawing.Point(12, 100);
            this.bSelectById.Name = "bSelectById";
            this.bSelectById.Size = new System.Drawing.Size(348, 23);
            this.bSelectById.TabIndex = 4;
            this.bSelectById.Text = "Select by Id";
            this.bSelectById.UseVisualStyleBackColor = true;
            this.bSelectById.Click += new System.EventHandler(this.bSelectById_Click);
            // 
            // tbIdSelect
            // 
            this.tbIdSelect.Location = new System.Drawing.Point(12, 130);
            this.tbIdSelect.Multiline = true;
            this.tbIdSelect.Name = "tbIdSelect";
            this.tbIdSelect.ReadOnly = true;
            this.tbIdSelect.Size = new System.Drawing.Size(348, 20);
            this.tbIdSelect.TabIndex = 5;
            // 
            // bAvgPrice
            // 
            this.bAvgPrice.Enabled = false;
            this.bAvgPrice.Location = new System.Drawing.Point(13, 157);
            this.bAvgPrice.Name = "bAvgPrice";
            this.bAvgPrice.Size = new System.Drawing.Size(347, 23);
            this.bAvgPrice.TabIndex = 6;
            this.bAvgPrice.Text = "AVG Price";
            this.bAvgPrice.UseVisualStyleBackColor = true;
            this.bAvgPrice.Click += new System.EventHandler(this.bAvgPrice_Click);
            // 
            // tbAvgPrice
            // 
            this.tbAvgPrice.Enabled = false;
            this.tbAvgPrice.Location = new System.Drawing.Point(13, 187);
            this.tbAvgPrice.Name = "tbAvgPrice";
            this.tbAvgPrice.Size = new System.Drawing.Size(347, 20);
            this.tbAvgPrice.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 415);
            this.Controls.Add(this.tbAvgPrice);
            this.Controls.Add(this.bAvgPrice);
            this.Controls.Add(this.tbIdSelect);
            this.Controls.Add(this.bSelectById);
            this.Controls.Add(this.lbData);
            this.Controls.Add(this.bSelectAll);
            this.Controls.Add(this.bDisconnect);
            this.Controls.Add(this.bConnect);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bDisconnect;
        private System.Windows.Forms.Button bSelectAll;
        private System.Windows.Forms.ListBox lbData;
        private System.Windows.Forms.Button bSelectById;
        private System.Windows.Forms.TextBox tbIdSelect;
        private System.Windows.Forms.Button bAvgPrice;
        private System.Windows.Forms.TextBox tbAvgPrice;
    }
}

