namespace MateoCompiler
{
    partial class Detalle
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblCaracter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPalabra = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rtbEntrada = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblMateo = new System.Windows.Forms.Label();
            this.btnTransofmrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstadoResult = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "CARACTER A EVALUAR:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblCaracter
            // 
            this.lblCaracter.AutoSize = true;
            this.lblCaracter.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaracter.Location = new System.Drawing.Point(232, 102);
            this.lblCaracter.Name = "lblCaracter";
            this.lblCaracter.Size = new System.Drawing.Size(20, 22);
            this.lblCaracter.TabIndex = 19;
            this.lblCaracter.Text = "N";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "NÚMERO DE ESTADO ACTUAL:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(275, 146);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(20, 22);
            this.lblEstado.TabIndex = 21;
            this.lblEstado.Text = "0";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 22);
            this.label4.TabIndex = 22;
            this.label4.Text = "CONSULTA A REALIZAR ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 22);
            this.label5.TabIndex = 23;
            this.label5.Text = "PALABRA FORMADA HASTA EL MOMENTO:";
            // 
            // lblPalabra
            // 
            this.lblPalabra.AutoSize = true;
            this.lblPalabra.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalabra.Location = new System.Drawing.Point(372, 236);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(20, 22);
            this.lblPalabra.TabIndex = 24;
            this.lblPalabra.Text = "N";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel6.Controls.Add(this.rtbEntrada);
            this.panel6.Location = new System.Drawing.Point(30, 319);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.panel6.Size = new System.Drawing.Size(829, 90);
            this.panel6.TabIndex = 25;
            // 
            // rtbEntrada
            // 
            this.rtbEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEntrada.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEntrada.ForeColor = System.Drawing.Color.White;
            this.rtbEntrada.Location = new System.Drawing.Point(20, 10);
            this.rtbEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.rtbEntrada.Name = "rtbEntrada";
            this.rtbEntrada.Size = new System.Drawing.Size(789, 75);
            this.rtbEntrada.TabIndex = 3;
            this.rtbEntrada.TabStop = false;
            this.rtbEntrada.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::MateoCompiler.Properties.Resources.mateo;
            this.pictureBox1.Image = global::MateoCompiler.Properties.Resources.mateo;
            this.pictureBox1.InitialImage = global::MateoCompiler.Properties.Resources.mateo;
            this.pictureBox1.Location = new System.Drawing.Point(604, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pictureBox1.Size = new System.Drawing.Size(255, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.lblMateo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(895, 86);
            this.panel3.TabIndex = 26;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(184)))), ((int)(((byte)(131)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 71);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(895, 15);
            this.panel7.TabIndex = 8;
            // 
            // lblMateo
            // 
            this.lblMateo.AutoSize = true;
            this.lblMateo.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateo.ForeColor = System.Drawing.Color.White;
            this.lblMateo.Location = new System.Drawing.Point(24, 20);
            this.lblMateo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateo.Name = "lblMateo";
            this.lblMateo.Size = new System.Drawing.Size(271, 34);
            this.lblMateo.TabIndex = 7;
            this.lblMateo.Text = "COMPILADOR MATEO";
            this.lblMateo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTransofmrar
            // 
            this.btnTransofmrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.btnTransofmrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransofmrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTransofmrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransofmrar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransofmrar.ForeColor = System.Drawing.Color.White;
            this.btnTransofmrar.Location = new System.Drawing.Point(0, 439);
            this.btnTransofmrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnTransofmrar.Name = "btnTransofmrar";
            this.btnTransofmrar.Size = new System.Drawing.Size(895, 53);
            this.btnTransofmrar.TabIndex = 0;
            this.btnTransofmrar.Text = "SIGUIENTE CARACTER";
            this.btnTransofmrar.UseVisualStyleBackColor = false;
            this.btnTransofmrar.Click += new System.EventHandler(this.btnTransofmrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "SIGUIENTE ESTADO:";
            // 
            // lblEstadoResult
            // 
            this.lblEstadoResult.AutoSize = true;
            this.lblEstadoResult.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoResult.Location = new System.Drawing.Point(206, 188);
            this.lblEstadoResult.Name = "lblEstadoResult";
            this.lblEstadoResult.Size = new System.Drawing.Size(20, 22);
            this.lblEstadoResult.TabIndex = 29;
            this.lblEstadoResult.Text = "0";
            // 
            // Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 492);
            this.Controls.Add(this.lblEstadoResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTransofmrar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lblPalabra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCaracter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(911, 531);
            this.MinimumSize = new System.Drawing.Size(911, 531);
            this.Name = "Detalle";
            this.Text = "Detalle";
            this.Load += new System.EventHandler(this.Detalle_Load);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCaracter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPalabra;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RichTextBox rtbEntrada;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblMateo;
        private System.Windows.Forms.Button btnTransofmrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstadoResult;
    }
}