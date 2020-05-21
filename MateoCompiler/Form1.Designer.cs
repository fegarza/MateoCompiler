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
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnSections = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbxDefiniciones = new System.Windows.Forms.RichTextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.rtTokens = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rtbEntrada = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnPasos = new System.Windows.Forms.Button();
            this.btnTransofmrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblCantidadLineas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgInstrucciones = new System.Windows.Forms.DataGridView();
            this.Tokens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instruccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rtbSalida = new System.Windows.Forms.RichTextBox();
            this.GenerarDDL = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgSimbolos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtbxLogsProducciones = new System.Windows.Forms.RichTextBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnSections.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel11.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSimbolos)).BeginInit();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.panel1.Location = new System.Drawing.Point(26, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 40);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(142)))));
            this.panel2.Location = new System.Drawing.Point(26, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(43, 40);
            this.panel2.TabIndex = 6;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.lblMateo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1759, 86);
            this.panel3.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(184)))), ((int)(((byte)(131)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 71);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1759, 15);
            this.panel7.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pnSections);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 86);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1759, 690);
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
            this.pnSections.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnSections.Location = new System.Drawing.Point(0, 0);
            this.pnSections.Name = "pnSections";
            this.pnSections.SelectedIndex = 0;
            this.pnSections.Size = new System.Drawing.Size(1759, 690);
            this.pnSections.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.panel15);
            this.tabPage1.Controls.Add(this.panel14);
            this.tabPage1.Controls.Add(this.panel13);
            this.tabPage1.Controls.Add(this.panel8);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(15, 15, 15, 50);
            this.tabPage1.Size = new System.Drawing.Size(1751, 655);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Compilar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label7);
            this.panel15.Controls.Add(this.label4);
            this.panel15.Controls.Add(this.dgSimbolos);
            this.panel15.Controls.Add(this.rtbxDefiniciones);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(15, 891);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1704, 331);
            this.panel15.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Instrucciones por producciones";
            // 
            // rtbxDefiniciones
            // 
            this.rtbxDefiniciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbxDefiniciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbxDefiniciones.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbxDefiniciones.ForeColor = System.Drawing.Color.White;
            this.rtbxDefiniciones.Location = new System.Drawing.Point(611, 46);
            this.rtbxDefiniciones.Margin = new System.Windows.Forms.Padding(2);
            this.rtbxDefiniciones.Name = "rtbxDefiniciones";
            this.rtbxDefiniciones.Size = new System.Drawing.Size(590, 218);
            this.rtbxDefiniciones.TabIndex = 4;
            this.rtbxDefiniciones.Text = "";
            this.rtbxDefiniciones.TextChanged += new System.EventHandler(this.rtbxDefiniciones_TextChanged);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.rtTokens);
            this.panel13.Controls.Add(this.label3);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(15, 285);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 25, 0, 25);
            this.panel13.Size = new System.Drawing.Size(1704, 283);
            this.panel13.TabIndex = 20;
            // 
            // rtTokens
            // 
            this.rtTokens.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rtTokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtTokens.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtTokens.ForeColor = System.Drawing.Color.White;
            this.rtTokens.Location = new System.Drawing.Point(0, 47);
            this.rtTokens.Margin = new System.Windows.Forms.Padding(2);
            this.rtTokens.Name = "rtTokens";
            this.rtTokens.Size = new System.Drawing.Size(1704, 211);
            this.rtTokens.TabIndex = 19;
            this.rtTokens.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "Salida de tokens";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(15, 15);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1704, 270);
            this.panel8.TabIndex = 19;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.panel12.Size = new System.Drawing.Size(1392, 270);
            this.panel12.TabIndex = 20;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel6);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.panel9.Size = new System.Drawing.Size(1372, 270);
            this.panel9.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel6.Controls.Add(this.rtbEntrada);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(50, 10, 20, 5);
            this.panel6.Size = new System.Drawing.Size(1362, 238);
            this.panel6.TabIndex = 13;
            // 
            // rtbEntrada
            // 
            this.rtbEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEntrada.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEntrada.ForeColor = System.Drawing.Color.White;
            this.rtbEntrada.Location = new System.Drawing.Point(50, 10);
            this.rtbEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.rtbEntrada.Name = "rtbEntrada";
            this.rtbEntrada.Size = new System.Drawing.Size(1292, 223);
            this.rtbEntrada.TabIndex = 3;
            this.rtbEntrada.Text = "";
            this.rtbEntrada.TextChanged += new System.EventHandler(this.rtbEntrada_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Código";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnPasos);
            this.panel10.Controls.Add(this.btnTransofmrar);
            this.panel10.Controls.Add(this.pictureBox1);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(1392, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(312, 270);
            this.panel10.TabIndex = 1;
            // 
            // btnPasos
            // 
            this.btnPasos.BackColor = System.Drawing.Color.Maroon;
            this.btnPasos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPasos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasos.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasos.ForeColor = System.Drawing.Color.White;
            this.btnPasos.Location = new System.Drawing.Point(0, 164);
            this.btnPasos.Margin = new System.Windows.Forms.Padding(0);
            this.btnPasos.Name = "btnPasos";
            this.btnPasos.Size = new System.Drawing.Size(312, 53);
            this.btnPasos.TabIndex = 17;
            this.btnPasos.Text = "OBTENER TOKENS X PASOS";
            this.btnPasos.UseVisualStyleBackColor = false;
            this.btnPasos.Click += new System.EventHandler(this.btnPasos_Click);
            // 
            // btnTransofmrar
            // 
            this.btnTransofmrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.btnTransofmrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransofmrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTransofmrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransofmrar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransofmrar.ForeColor = System.Drawing.Color.White;
            this.btnTransofmrar.Location = new System.Drawing.Point(0, 217);
            this.btnTransofmrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnTransofmrar.Name = "btnTransofmrar";
            this.btnTransofmrar.Size = new System.Drawing.Size(312, 53);
            this.btnTransofmrar.TabIndex = 16;
            this.btnTransofmrar.Text = "OBTENER TOKENS";
            this.btnTransofmrar.UseVisualStyleBackColor = false;
            this.btnTransofmrar.Click += new System.EventHandler(this.GenerarTokens_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::MateoCompiler.Properties.Resources.mateo;
            this.pictureBox1.Image = global::MateoCompiler.Properties.Resources.mateo;
            this.pictureBox1.InitialImage = global::MateoCompiler.Properties.Resources.mateo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pictureBox1.Size = new System.Drawing.Size(309, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lblCantidadLineas);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel11.Size = new System.Drawing.Size(312, 31);
            this.panel11.TabIndex = 0;
            // 
            // lblCantidadLineas
            // 
            this.lblCantidadLineas.AutoSize = true;
            this.lblCantidadLineas.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCantidadLineas.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadLineas.Location = new System.Drawing.Point(210, 0);
            this.lblCantidadLineas.Name = "lblCantidadLineas";
            this.lblCantidadLineas.Size = new System.Drawing.Size(20, 22);
            this.lblCantidadLineas.TabIndex = 18;
            this.lblCantidadLineas.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cantidad de líneas: ";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dgInstrucciones);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1276, 655);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lenguaje de programación";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(390, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cargar instrucciones.txt al SQL Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(400, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Instrucciones existentes en mi lenguaje";
            // 
            // dgInstrucciones
            // 
            this.dgInstrucciones.AllowUserToAddRows = false;
            this.dgInstrucciones.AllowUserToDeleteRows = false;
            this.dgInstrucciones.AllowUserToOrderColumns = true;
            this.dgInstrucciones.AllowUserToResizeColumns = false;
            this.dgInstrucciones.AllowUserToResizeRows = false;
            this.dgInstrucciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgInstrucciones.CausesValidation = false;
            this.dgInstrucciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgInstrucciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInstrucciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tokens,
            this.Instruccion});
            this.dgInstrucciones.Location = new System.Drawing.Point(26, 70);
            this.dgInstrucciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgInstrucciones.Name = "dgInstrucciones";
            this.dgInstrucciones.ReadOnly = true;
            this.dgInstrucciones.RowHeadersVisible = false;
            this.dgInstrucciones.RowHeadersWidth = 62;
            this.dgInstrucciones.RowTemplate.Height = 28;
            this.dgInstrucciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgInstrucciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInstrucciones.ShowCellErrors = false;
            this.dgInstrucciones.ShowCellToolTips = false;
            this.dgInstrucciones.ShowEditingIcon = false;
            this.dgInstrucciones.ShowRowErrors = false;
            this.dgInstrucciones.Size = new System.Drawing.Size(505, 247);
            this.dgInstrucciones.TabIndex = 13;
            this.dgInstrucciones.TabStop = false;
            // 
            // Tokens
            // 
            this.Tokens.HeaderText = "Tokens";
            this.Tokens.Name = "Tokens";
            this.Tokens.ReadOnly = true;
            // 
            // Instruccion
            // 
            this.Instruccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Instruccion.HeaderText = "Instruccion";
            this.Instruccion.Name = "Instruccion";
            this.Instruccion.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rtbSalida);
            this.panel5.Controls.Add(this.GenerarDDL);
            this.panel5.Location = new System.Drawing.Point(569, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(498, 247);
            this.panel5.TabIndex = 12;
            // 
            // rtbSalida
            // 
            this.rtbSalida.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbSalida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSalida.ForeColor = System.Drawing.Color.Black;
            this.rtbSalida.Location = new System.Drawing.Point(0, 47);
            this.rtbSalida.Margin = new System.Windows.Forms.Padding(2);
            this.rtbSalida.Name = "rtbSalida";
            this.rtbSalida.Size = new System.Drawing.Size(498, 200);
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
            this.GenerarDDL.Size = new System.Drawing.Size(498, 47);
            this.GenerarDDL.TabIndex = 10;
            this.GenerarDDL.Text = "GENERAR TABLAS";
            this.GenerarDDL.UseVisualStyleBackColor = false;
            this.GenerarDDL.Click += new System.EventHandler(this.GenerarDDL_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1276, 655);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgSimbolos
            // 
            this.dgSimbolos.AllowUserToAddRows = false;
            this.dgSimbolos.AllowUserToDeleteRows = false;
            this.dgSimbolos.AllowUserToOrderColumns = true;
            this.dgSimbolos.AllowUserToResizeColumns = false;
            this.dgSimbolos.AllowUserToResizeRows = false;
            this.dgSimbolos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Token,
            this.Valor});
            this.dgSimbolos.Location = new System.Drawing.Point(27, 46);
            this.dgSimbolos.Margin = new System.Windows.Forms.Padding(2);
            this.dgSimbolos.Name = "dgSimbolos";
            this.dgSimbolos.RowHeadersWidth = 62;
            this.dgSimbolos.RowTemplate.Height = 28;
            this.dgSimbolos.Size = new System.Drawing.Size(572, 218);
            this.dgSimbolos.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 22);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tabla de símbolos";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel14.Controls.Add(this.rtbxLogsProducciones);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(15, 568);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(25);
            this.panel14.Size = new System.Drawing.Size(1704, 323);
            this.panel14.TabIndex = 25;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            this.Token.ReadOnly = true;
            this.Token.Width = 200;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 300;
            // 
            // rtbxLogsProducciones
            // 
            this.rtbxLogsProducciones.BackColor = System.Drawing.Color.White;
            this.rtbxLogsProducciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbxLogsProducciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbxLogsProducciones.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbxLogsProducciones.ForeColor = System.Drawing.Color.Black;
            this.rtbxLogsProducciones.Location = new System.Drawing.Point(25, 25);
            this.rtbxLogsProducciones.Margin = new System.Windows.Forms.Padding(2);
            this.rtbxLogsProducciones.Name = "rtbxLogsProducciones";
            this.rtbxLogsProducciones.Size = new System.Drawing.Size(1654, 273);
            this.rtbxLogsProducciones.TabIndex = 20;
            this.rtbxLogsProducciones.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1759, 796);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.pnSections.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInstrucciones)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSimbolos)).EndInit();
            this.panel14.ResumeLayout(false);
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
        private System.Windows.Forms.RichTextBox rtbEntrada;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgInstrucciones;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox rtbSalida;
        private System.Windows.Forms.Button GenerarDDL;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnTransofmrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCantidadLineas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instruccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPasos;
        private System.Windows.Forms.RichTextBox rtTokens;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbxDefiniciones;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.RichTextBox rtbxLogsProducciones;
    }
}

