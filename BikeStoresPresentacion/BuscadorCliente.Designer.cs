namespace BikeStoresPresentacion {
    partial class BuscadorCliente {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            buscadorTv = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            okBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buscadorTv
            // 
            buscadorTv.Location = new Point(46, 78);
            buscadorTv.Name = "buscadorTv";
            buscadorTv.PlaceholderText = "Id, nombre, apellido, telefono, email.";
            buscadorTv.Size = new Size(747, 23);
            buscadorTv.TabIndex = 0;
            buscadorTv.TextChanged += busquedaLb_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.lupa;
            pictureBox1.Location = new Point(12, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(324, 27);
            label1.Name = "label1";
            label1.Size = new Size(143, 27);
            label1.TabIndex = 2;
            label1.Text = "Buscar Cliente";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(781, 388);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellContentDoubleClick;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(670, 513);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(123, 41);
            okBtn.TabIndex = 4;
            okBtn.Text = "Seleccionar";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // BuscadorCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(805, 577);
            Controls.Add(okBtn);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(buscadorTv);
            Name = "BuscadorCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscadorCliente";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscadorTv;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button okBtn;
    }
}