using System;
using System.ComponentModel;

namespace Facturation.PL
{
    partial class Add_Article
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Article));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAjou = new System.Windows.Forms.Button();
            this.txtDesign = new System.Windows.Forms.TextBox();
            this.txtQs = new System.Windows.Forms.TextBox();
            this.txtPu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.texttva = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGrat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(213, 354);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAjou
            // 
            this.btnAjou.Location = new System.Drawing.Point(13, 354);
            this.btnAjou.Margin = new System.Windows.Forms.Padding(4);
            this.btnAjou.Name = "btnAjou";
            this.btnAjou.Size = new System.Drawing.Size(139, 30);
            this.btnAjou.TabIndex = 3;
            this.btnAjou.Text = "Ajouter";
            this.btnAjou.UseVisualStyleBackColor = true;
            this.btnAjou.Click += new System.EventHandler(this.btnAjou_Click);
            // 
            // txtDesign
            // 
            this.txtDesign.Location = new System.Drawing.Point(152, 65);
            this.txtDesign.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesign.Name = "txtDesign";
            this.txtDesign.Size = new System.Drawing.Size(219, 25);
            this.txtDesign.TabIndex = 0;
            this.txtDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDesign.TextChanged += new System.EventHandler(this.txtDesign_TextChanged);
            // 
            // txtQs
            // 
            this.txtQs.Location = new System.Drawing.Point(152, 195);
            this.txtQs.Margin = new System.Windows.Forms.Padding(4);
            this.txtQs.Name = "txtQs";
            this.txtQs.Size = new System.Drawing.Size(219, 25);
            this.txtQs.TabIndex = 2;
            this.txtQs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQs.TextChanged += new System.EventHandler(this.txtQs_TextChanged);
            this.txtQs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQs_KeyPress);
            // 
            // txtPu
            // 
            this.txtPu.Location = new System.Drawing.Point(152, 131);
            this.txtPu.Margin = new System.Windows.Forms.Padding(4);
            this.txtPu.Name = "txtPu";
            this.txtPu.Size = new System.Drawing.Size(219, 25);
            this.txtPu.TabIndex = 1;
            this.txtPu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPu.TextChanged += new System.EventHandler(this.txtPu_TextChanged);
            this.txtPu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPu_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantité Stocker :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Prix Unitaire :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nom Produit :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Référence :";
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(152, 9);
            this.txtRef.Margin = new System.Windows.Forms.Padding(4);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(219, 25);
            this.txtRef.TabIndex = 0;
            this.txtRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRef.TextChanged += new System.EventHandler(this.txtRef_TextChanged);
            this.txtRef.Validated += new System.EventHandler(this.txtRef_Validated);
            // 
            // texttva
            // 
            this.texttva.Location = new System.Drawing.Point(153, 245);
            this.texttva.Margin = new System.Windows.Forms.Padding(4);
            this.texttva.Name = "texttva";
            this.texttva.Size = new System.Drawing.Size(219, 25);
            this.texttva.TabIndex = 7;
            this.texttva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.texttva.TextChanged += new System.EventHandler(this.texttva_TextChanged);
            this.texttva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPu_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 248);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "TVA % :";
            // 
            // txtGrat
            // 
            this.txtGrat.Location = new System.Drawing.Point(152, 295);
            this.txtGrat.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrat.Name = "txtGrat";
            this.txtGrat.Size = new System.Drawing.Size(219, 25);
            this.txtGrat.TabIndex = 7;
            this.txtGrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 298);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Gratuité :";
            // 
            // Add_Article
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 414);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGrat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.texttva);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAjou);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.txtDesign);
            this.Controls.Add(this.txtQs);
            this.Controls.Add(this.txtPu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Add_Article";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Article";
            this.Load += new System.EventHandler(this.Add_Article_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAjou;
        private System.Windows.Forms.TextBox txtDesign;
        private System.Windows.Forms.TextBox txtQs;
        private System.Windows.Forms.TextBox txtPu;
        private System.Windows.Forms.TextBox txtGrat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.TextBox texttva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        
        private Boolean isupdate;
    }
}