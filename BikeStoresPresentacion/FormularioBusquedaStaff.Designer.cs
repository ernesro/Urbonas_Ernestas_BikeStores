namespace BikeStoresPresentacion {
    partial class FormularioBusquedaStaff {
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
            label1 = new Label();
            busquedaLb = new TextBox();
            pictureBox1 = new PictureBox();
            dataEmpleadosDgv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataEmpleadosDgv).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Banner", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(267, 18);
            label1.Name = "label1";
            label1.Size = new Size(252, 39);
            label1.TabIndex = 0;
            label1.Text = "Busqueda de empleado";
            // 
            // busquedaLb
            // 
            busquedaLb.Location = new Point(115, 76);
            busquedaLb.Name = "busquedaLb";
            busquedaLb.PlaceholderText = "First name, last name o email";
            busquedaLb.Size = new Size(568, 23);
            busquedaLb.TabIndex = 1;
            busquedaLb.TextChanged += busquedaLb_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.lupa;
            pictureBox1.Location = new Point(85, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataEmpleadosDgv
            // 
            dataEmpleadosDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataEmpleadosDgv.Location = new Point(12, 105);
            dataEmpleadosDgv.Name = "dataEmpleadosDgv";
            dataEmpleadosDgv.RowTemplate.Height = 25;
            dataEmpleadosDgv.Size = new Size(742, 510);
            dataEmpleadosDgv.TabIndex = 3;
            dataEmpleadosDgv.CellClick += dataEmpleadosDgv_CellContentClick;
            dataEmpleadosDgv.CellContentClick += dataEmpleadosDgv_CellContentClick;
            // 
            // FormularioBusquedaStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 627);
            Controls.Add(dataEmpleadosDgv);
            Controls.Add(pictureBox1);
            Controls.Add(busquedaLb);
            Controls.Add(label1);
            Name = "FormularioBusquedaStaff";
            Text = "FormularioBusquedaStaff";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataEmpleadosDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox busquedaLb;
        private PictureBox pictureBox1;
        private DataGridView dataEmpleadosDgv;
    }
}