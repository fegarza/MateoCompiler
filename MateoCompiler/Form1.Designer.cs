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
            this.Compilar = new System.Windows.Forms.Button();
            this.dgInstrucciones = new System.Windows.Forms.DataGridView();
            this.GenerarDDL = new System.Windows.Forms.Button();
            this.rtbEntrada = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMateo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtbSalida = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Compilar
            // 
            this.Compilar.Location = new System.Drawing.Point(847, 205);
            this.Compilar.Name = "Compilar";
            this.Compilar.Size = new System.Drawing.Size(151, 39);
            this.Compilar.TabIndex = 2;
            this.Compilar.Text = "Compilar";
            this.Compilar.UseVisualStyleBackColor = true;
            this.Compilar.Click += new System.EventHandler(this.Compilar_Click);
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
            this.dgInstrucciones.Location = new System.Drawing.Point(45, 613);
            this.dgInstrucciones.Name = "dgInstrucciones";
            this.dgInstrucciones.RowHeadersWidth = 62;
            this.dgInstrucciones.RowTemplate.Height = 28;
            this.dgInstrucciones.Size = new System.Drawing.Size(704, 242);
            this.dgInstrucciones.TabIndex = 3;
            // 
            // GenerarDDL
            // 
            this.GenerarDDL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.GenerarDDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerarDDL.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerarDDL.ForeColor = System.Drawing.Color.White;
            this.GenerarDDL.Location = new System.Drawing.Point(45, 141);
            this.GenerarDDL.Name = "GenerarDDL";
            this.GenerarDDL.Size = new System.Drawing.Size(379, 73);
            this.GenerarDDL.TabIndex = 4;
            this.GenerarDDL.Text = "GENERAR TABLAS";
            this.GenerarDDL.UseVisualStyleBackColor = false;
            this.GenerarDDL.Click += new System.EventHandler(this.GenerarDDL_Click);
            // 
            // rtbEntrada
            // 
            this.rtbEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEntrada.Location = new System.Drawing.Point(803, 540);
            this.rtbEntrada.Name = "rtbEntrada";
            this.rtbEntrada.Size = new System.Drawing.Size(704, 335);
            this.rtbEntrada.TabIndex = 0;
            this.rtbEntrada.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.panel1.Location = new System.Drawing.Point(820, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 107);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(142)))));
            this.panel2.Location = new System.Drawing.Point(1083, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 156);
            this.panel2.TabIndex = 6;
            // 
            // lblMateo
            // 
            this.lblMateo.AutoSize = true;
            this.lblMateo.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateo.ForeColor = System.Drawing.Color.White;
            this.lblMateo.Location = new System.Drawing.Point(38, 34);
            this.lblMateo.Name = "lblMateo";
            this.lblMateo.Size = new System.Drawing.Size(350, 38);
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
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1580, 111);
            this.panel3.TabIndex = 7;
            // 
            // rtbSalida
            // 
            this.rtbSalida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSalida.Location = new System.Drawing.Point(45, 239);
            this.rtbSalida.Name = "rtbSalida";
            this.rtbSalida.Size = new System.Drawing.Size(704, 335);
            this.rtbSalida.TabIndex = 8;
            this.rtbSalida.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 912);
            this.Controls.Add(this.rtbSalida);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GenerarDDL);
            this.Controls.Add(this.dgInstrucciones);
            this.Controls.Add(this.Compilar);
            this.Controls.Add(this.rtbEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Compilar;
        private System.Windows.Forms.DataGridView dgInstrucciones;
        private System.Windows.Forms.Button GenerarDDL;
        private System.Windows.Forms.RichTextBox rtbEntrada;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMateo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtbSalida;
    }
}

