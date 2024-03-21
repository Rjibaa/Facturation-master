namespace Facturation.PL
{
    partial class All_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(All_Client));
            this.dgvAllClient = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllClient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllClient
            // 
            this.dgvAllClient.AllowUserToAddRows = false;
            this.dgvAllClient.AllowUserToDeleteRows = false;
            this.dgvAllClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllClient.Location = new System.Drawing.Point(0, 0);
            this.dgvAllClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAllClient.MultiSelect = false;
            this.dgvAllClient.Name = "dgvAllClient";
            this.dgvAllClient.ReadOnly = true;
            this.dgvAllClient.RowHeadersWidth = 51;
            this.dgvAllClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllClient.Size = new System.Drawing.Size(821, 490);
            this.dgvAllClient.TabIndex = 0;
            this.dgvAllClient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllClient_CellContentClick);
            this.dgvAllClient.DoubleClick += new System.EventHandler(this.dgvAllClient_DoubleClick);
            // 
            // All_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 490);
            this.Controls.Add(this.dgvAllClient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "All_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All_Client";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvAllClient;
    }
}