namespace WindowsFormsApplication1
{
    partial class BibliotecarWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titluColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imprumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBiblioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titluBox = new System.Windows.Forms.TextBox();
            this.autorBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stareCombo = new System.Windows.Forms.ComboBox();
            this.Stare = new System.Windows.Forms.Label();
            this.Returneaza = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.titluColumn,
            this.autorColumn,
            this.imprumColumn,
            this.idBiblioColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(541, 260);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClickDataGridView);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "Id";
            this.idColumn.Name = "idColumn";
            // 
            // titluColumn
            // 
            this.titluColumn.HeaderText = "Titlu";
            this.titluColumn.Name = "titluColumn";
            // 
            // autorColumn
            // 
            this.autorColumn.HeaderText = "Autor";
            this.autorColumn.Name = "autorColumn";
            // 
            // imprumColumn
            // 
            this.imprumColumn.HeaderText = "Stare";
            this.imprumColumn.Name = "imprumColumn";
            // 
            // idBiblioColumn
            // 
            this.idBiblioColumn.HeaderText = "ID_Biblioteca";
            this.idBiblioColumn.Name = "idBiblioColumn";
            // 
            // titluBox
            // 
            this.titluBox.Location = new System.Drawing.Point(637, 12);
            this.titluBox.Name = "titluBox";
            this.titluBox.Size = new System.Drawing.Size(185, 20);
            this.titluBox.TabIndex = 1;
            // 
            // autorBox
            // 
            this.autorBox.Location = new System.Drawing.Point(637, 38);
            this.autorBox.Name = "autorBox";
            this.autorBox.Size = new System.Drawing.Size(185, 20);
            this.autorBox.TabIndex = 2;
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(637, 65);
            this.idBox.Name = "idBox";
            this.idBox.ReadOnly = true;
            this.idBox.Size = new System.Drawing.Size(185, 20);
            this.idBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(601, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Titlu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(585, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Autor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(604, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Id";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(574, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.saveCarte);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Modifica";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.updateCarte);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(736, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Sterge";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.deleteCarte);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(637, 148);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(185, 20);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(637, 174);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(185, 20);
            this.textBox5.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(571, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "IdCarte";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(576, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "idAbonat";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stareCombo
            // 
            this.stareCombo.FormattingEnabled = true;
            this.stareCombo.Items.AddRange(new object[] {
            "False",
            "True"});
            this.stareCombo.Location = new System.Drawing.Point(637, 92);
            this.stareCombo.Name = "stareCombo";
            this.stareCombo.Size = new System.Drawing.Size(121, 21);
            this.stareCombo.TabIndex = 14;
            // 
            // Stare
            // 
            this.Stare.AutoSize = true;
            this.Stare.Location = new System.Drawing.Point(571, 95);
            this.Stare.Name = "Stare";
            this.Stare.Size = new System.Drawing.Size(65, 13);
            this.Stare.TabIndex = 15;
            this.Stare.Text = "Imprumutata";
            this.Stare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Stare.Click += new System.EventHandler(this.Stare_Click);
            // 
            // Returneaza
            // 
            this.Returneaza.Location = new System.Drawing.Point(637, 238);
            this.Returneaza.Name = "Returneaza";
            this.Returneaza.Size = new System.Drawing.Size(75, 23);
            this.Returneaza.TabIndex = 16;
            this.Returneaza.Text = "Returneaza";
            this.Returneaza.UseVisualStyleBackColor = true;
            this.Returneaza.Click += new System.EventHandler(this.ReturneazaEvent);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Buna",
            "Medie",
            "Rupta"});
            this.comboBox1.Location = new System.Drawing.Point(637, 201);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Stare";
            // 
            // BibliotecarWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 283);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Returneaza);
            this.Controls.Add(this.Stare);
            this.Controls.Add(this.stareCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.autorBox);
            this.Controls.Add(this.titluBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BibliotecarWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox titluBox;
        private System.Windows.Forms.TextBox autorBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titluColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imprumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBiblioColumn;
        private System.Windows.Forms.ComboBox stareCombo;
        private System.Windows.Forms.Label Stare;
        private System.Windows.Forms.Button Returneaza;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
    }
}

