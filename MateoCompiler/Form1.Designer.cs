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
            this.rtbEntrada = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Compilar = new System.Windows.Forms.Button();
            this.dgInstrucciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbEntrada
            // 
            this.rtbEntrada.Location = new System.Drawing.Point(23, 27);
            this.rtbEntrada.Name = "rtbEntrada";
            this.rtbEntrada.Size = new System.Drawing.Size(566, 211);
            this.rtbEntrada.TabIndex = 0;
            this.rtbEntrada.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(789, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(704, 228);
            this.dataGridView1.TabIndex = 1;
            // 
            // Compilar
            // 
            this.Compilar.Location = new System.Drawing.Point(23, 254);
            this.Compilar.Name = "Compilar";
            this.Compilar.Size = new System.Drawing.Size(566, 47);
            this.Compilar.TabIndex = 2;
            this.Compilar.Text = "Compilar";
            this.Compilar.UseVisualStyleBackColor = true;
            this.Compilar.Click += new System.EventHandler(this.Compilar_Click);
            // 
            // dgInstrucciones
            // 
            this.dgInstrucciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInstrucciones.Location = new System.Drawing.Point(23, 353);
            this.dgInstrucciones.Name = "dgInstrucciones";
            this.dgInstrucciones.RowHeadersWidth = 62;
            this.dgInstrucciones.RowTemplate.Height = 28;
            this.dgInstrucciones.Size = new System.Drawing.Size(1336, 268);
            this.dgInstrucciones.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 659);
            this.Controls.Add(this.dgInstrucciones);
            this.Controls.Add(this.Compilar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rtbEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbEntrada;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Compilar;
        private System.Windows.Forms.DataGridView dgInstrucciones;
    }
}

