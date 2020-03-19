namespace MateoCompiler
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMateo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnSections = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbSalida = new System.Windows.Forms.RichTextBox();
            this.GenerarDDL = new System.Windows.Forms.Button();
            this.rtbEntrada = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgInstrucciones = new System.Windows.Forms.DataGridView();
            this.rtTokens = new System.Windows.Forms.RichTextBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnSections.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.panel1.Location = new System.Drawing.Point(26, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 40);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(142)))));
            this.panel2.Location = new System.Drawing.Point(26, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(43, 40);
            this.panel2.TabIndex = 6;
            // 
            // lblMateo
            // 
            this.lblMateo.AutoSize = true;
            this.lblMateo.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateo.ForeColor = System.Drawing.Color.White;
            this.lblMateo.Location = new System.Drawing.Point(25, 22);
            this.lblMateo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateo.Name = "lblMateo";
            this.lblMateo.Size = new System.Drawing.Size(237, 26);
            this.lblMateo.TabIndex = 7;
            this.lblMateo.Text = "COMPILADOR MATEO";
            this.lblMateo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel3.Controls.Add(this.lblMateo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1179, 72);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pnSections);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 72);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1179, 521);
            this.panel4.TabIndex = 9;
            // 
            // pnSections
            // 
            this.pnSections.AccessibleDescription = "";
            this.pnSections.AccessibleName = "";
            this.pnSections.Controls.Add(this.tabPage1);
            this.pnSections.Controls.Add(this.tabPage2);
            this.pnSections.Controls.Add(this.tabPage3);
            this.pnSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSections.Location = new System.Drawing.Point(0, 0);
            this.pnSections.Name = "pnSections";
            this.pnSections.SelectedIndex = 0;
            this.pnSections.Size = new System.Drawing.Size(1179, 521);
            this.pnSections.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtTokens);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.rtbEntrada);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1171, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Compilar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.dgInstrucciones);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1171, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generar Matriz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbSalida
            // 
            this.rtbSalida.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbSalida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSalida.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbSalida.ForeColor = System.Drawing.Color.Black;
            this.rtbSalida.Location = new System.Drawing.Point(0, 47);
            this.rtbSalida.Margin = new System.Windows.Forms.Padding(2);
            this.rtbSalida.Name = "rtbSalida";
            this.rtbSalida.Size = new System.Drawing.Size(1165, 184);
            this.rtbSalida.TabIndex = 11;
            this.rtbSalida.Text = "";
            // 
            // GenerarDDL
            // 
            this.GenerarDDL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.GenerarDDL.Dock = System.Windows.Forms.DockStyle.Top;
            this.GenerarDDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerarDDL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerarDDL.ForeColor = System.Drawing.Color.White;
            this.GenerarDDL.Location = new System.Drawing.Point(0, 0);
            this.GenerarDDL.Margin = new System.Windows.Forms.Padding(2);
            this.GenerarDDL.Name = "GenerarDDL";
            this.GenerarDDL.Size = new System.Drawing.Size(1165, 47);
            this.GenerarDDL.TabIndex = 10;
            this.GenerarDDL.Text = "GENERAR TABLAS";
            this.GenerarDDL.UseVisualStyleBackColor = false;
            this.GenerarDDL.Click += new System.EventHandler(this.GenerarDDL_Click);
            // 
            // rtbEntrada
            // 
            this.rtbEntrada.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEntrada.Location = new System.Drawing.Point(14, 29);
            this.rtbEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.rtbEntrada.Name = "rtbEntrada";
            this.rtbEntrada.Size = new System.Drawing.Size(469, 159);
            this.rtbEntrada.TabIndex = 3;
            this.rtbEntrada.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(14, 211);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(469, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "COMPILAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Compilar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1171, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rtbSalida);
            this.panel5.Controls.Add(this.GenerarDDL);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1165, 233);
            this.panel5.TabIndex = 12;
            // 
            // dgInstrucciones
            // 
            this.dgInstrucciones.AllowUserToAddRows = false;
            this.dgInstrucciones.AllowUserToDeleteRows = false;
            this.dgInstrucciones.AllowUserToOrderColumns = true;
            this.dgInstrucciones.AllowUserToResizeColumns = false;
            this.dgInstrucciones.AllowUserToResizeRows = false;
            this.dgInstrucciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgInstrucciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInstrucciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgInstrucciones.Location = new System.Drawing.Point(3, 236);
            this.dgInstrucciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgInstrucciones.Name = "dgInstrucciones";
            this.dgInstrucciones.RowHeadersWidth = 62;
            this.dgInstrucciones.RowTemplate.Height = 28;
            this.dgInstrucciones.Size = new System.Drawing.Size(1165, 235);
            this.dgInstrucciones.TabIndex = 13;
            // 
            // rtTokens
            // 
            this.rtTokens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(142)))));
            this.rtTokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtTokens.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtTokens.ForeColor = System.Drawing.Color.White;
            this.rtTokens.Location = new System.Drawing.Point(582, 29);
            this.rtTokens.Margin = new System.Windows.Forms.Padding(2);
            this.rtTokens.Name = "rtTokens";
            this.rtTokens.Size = new System.Drawing.Size(469, 159);
            this.rtTokens.TabIndex = 12;
            this.rtTokens.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 593);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.pnSections.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMateo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl pnSections;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbEntrada;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgInstrucciones;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox rtbSalida;
        private System.Windows.Forms.Button GenerarDDL;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtTokens;
    }
}

