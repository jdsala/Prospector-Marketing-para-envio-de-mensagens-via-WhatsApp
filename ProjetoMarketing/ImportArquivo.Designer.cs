
namespace ProjetoMarketing
{
    partial class FrmImportArquivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportArquivo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bntImport = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNumeros = new System.Windows.Forms.Label();
            this.lblTotalImport = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListas = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmSair = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsmImport = new System.Windows.Forms.MenuStrip();
            this.tsmImportArquivos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsmImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bntImport);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.lblNumeros);
            this.panel1.Controls.Add(this.lblTotalImport);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 677);
            this.panel1.TabIndex = 0;
            // 
            // bntImport
            // 
            this.bntImport.BackColor = System.Drawing.SystemColors.Control;
            this.bntImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntImport.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bntImport.Location = new System.Drawing.Point(554, 636);
            this.bntImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntImport.Name = "bntImport";
            this.bntImport.Size = new System.Drawing.Size(109, 40);
            this.bntImport.TabIndex = 7;
            this.bntImport.Text = "Importar";
            this.bntImport.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCancelar.Location = new System.Drawing.Point(346, 636);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNumeros
            // 
            this.lblNumeros.AutoSize = true;
            this.lblNumeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeros.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNumeros.Location = new System.Drawing.Point(142, 648);
            this.lblNumeros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeros.Name = "lblNumeros";
            this.lblNumeros.Size = new System.Drawing.Size(16, 16);
            this.lblNumeros.TabIndex = 5;
            this.lblNumeros.Text = "0";
            // 
            // lblTotalImport
            // 
            this.lblTotalImport.AutoSize = true;
            this.lblTotalImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalImport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTotalImport.Location = new System.Drawing.Point(4, 648);
            this.lblTotalImport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalImport.Name = "lblTotalImport";
            this.lblTotalImport.Size = new System.Drawing.Size(130, 16);
            this.lblTotalImport.TabIndex = 4;
            this.lblTotalImport.Text = "Total Importados:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(667, 543);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listas";
            // 
            // dgvListas
            // 
            this.dgvListas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListas.Location = new System.Drawing.Point(4, 18);
            this.dgvListas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvListas.Name = "dgvListas";
            this.dgvListas.Size = new System.Drawing.Size(659, 521);
            this.dgvListas.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(667, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmSair
            // 
            this.tsmSair.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmSair.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tsmSair.Name = "tsmSair";
            this.tsmSair.Size = new System.Drawing.Size(42, 21);
            this.tsmSair.Text = "Sair";
            this.tsmSair.Click += new System.EventHandler(this.tsmSair_Click);
            // 
            // txtCaminho
            // 
            this.txtCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminho.Location = new System.Drawing.Point(4, 20);
            this.txtCaminho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCaminho.Multiline = true;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(597, 32);
            this.txtCaminho.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.txtCaminho);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(3, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(666, 61);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Importar Listas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tsmImport);
            this.panel2.Location = new System.Drawing.Point(604, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(59, 32);
            this.panel2.TabIndex = 2;
            // 
            // tsmImport
            // 
            this.tsmImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsmImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsmImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmImportArquivos});
            this.tsmImport.Location = new System.Drawing.Point(0, 0);
            this.tsmImport.Name = "tsmImport";
            this.tsmImport.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsmImport.Size = new System.Drawing.Size(57, 30);
            this.tsmImport.TabIndex = 0;
            this.tsmImport.Text = "Incluir";
            // 
            // tsmImportArquivos
            // 
            this.tsmImportArquivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCSV,
            this.tsmExcel});
            this.tsmImportArquivos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmImportArquivos.Image = ((System.Drawing.Image)(resources.GetObject("tsmImportArquivos.Image")));
            this.tsmImportArquivos.Name = "tsmImportArquivos";
            this.tsmImportArquivos.Size = new System.Drawing.Size(50, 26);
            this.tsmImportArquivos.Text = ".....";
            // 
            // tsmCSV
            // 
            this.tsmCSV.Name = "tsmCSV";
            this.tsmCSV.Size = new System.Drawing.Size(180, 22);
            this.tsmCSV.Text = "Importar CSV";
            // 
            // tsmExcel
            // 
            this.tsmExcel.Name = "tsmExcel";
            this.tsmExcel.Size = new System.Drawing.Size(180, 22);
            this.tsmExcel.Text = "Importar Excel";
            // 
            // FrmImportArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(671, 679);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportArquivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Arquivo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsmImport.ResumeLayout(false);
            this.tsmImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Button bntImport;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNumeros;
        private System.Windows.Forms.Label lblTotalImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmSair;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip tsmImport;
        private System.Windows.Forms.ToolStripMenuItem tsmImportArquivos;
        private System.Windows.Forms.ToolStripMenuItem tsmCSV;
        private System.Windows.Forms.ToolStripMenuItem tsmExcel;
    }
}