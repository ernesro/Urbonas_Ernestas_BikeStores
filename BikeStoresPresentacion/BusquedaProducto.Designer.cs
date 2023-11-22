namespace BikeStoresPresentacion {
    partial class BusquedaProducto {
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
            label2 = new Label();
            categoriaCb = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            productoTb = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Banner", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(336, 19);
            label2.Name = "label2";
            label2.Size = new Size(154, 30);
            label2.TabIndex = 1;
            label2.Text = "Buscar Producto";
            // 
            // categoriaCb
            // 
            categoriaCb.FormattingEnabled = true;
            categoriaCb.Location = new Point(85, 77);
            categoriaCb.Name = "categoriaCb";
            categoriaCb.Size = new Size(178, 23);
            categoriaCb.TabIndex = 2;
            categoriaCb.SelectedIndexChanged += categoriaCb_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 80);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 3;
            label1.Text = "Categoria : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 80);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 4;
            label3.Text = "Producto : ";
            // 
            // productoTb
            // 
            productoTb.Location = new Point(363, 77);
            productoTb.Name = "productoTb";
            productoTb.Size = new Size(465, 23);
            productoTb.TabIndex = 5;
            productoTb.TextChanged += productoTb_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 116);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(816, 408);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(702, 543);
            button1.Name = "button1";
            button1.Size = new Size(126, 59);
            button1.TabIndex = 7;
            button1.Text = "Seleccionar Producto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BusquedaProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 614);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(productoTb);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(categoriaCb);
            Controls.Add(label2);
            Name = "BusquedaProducto";
            Text = "BusquedaProducto";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox categoriaCb;
        private Label label1;
        private Label label3;
        private TextBox productoTb;
        private DataGridView dataGridView1;
        private Button button1;
    }
}