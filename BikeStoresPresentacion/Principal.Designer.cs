namespace BikeStoresPresentacion {
    partial class Principal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            menuStrip1 = new MenuStrip();
            staffToolStripMenuItem = new ToolStripMenuItem();
            altaEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            modificarEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            bajaDeEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            altaDeProductosToolStripMenuItem = new ToolStripMenuItem();
            modificarProductoToolStripMenuItem = new ToolStripMenuItem();
            bajaDeProductoToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            nuevaToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            estadisticasToolStripMenuItem = new ToolStripMenuItem();
            totalPedidosPorClienteToolStripMenuItem = new ToolStripMenuItem();
            productosPorCategoriaToolStripMenuItem = new ToolStripMenuItem();
            informesToolStripMenuItem = new ToolStripMenuItem();
            facturaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            pictureBox = new PictureBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumSeaGreen;
            menuStrip1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { staffToolStripMenuItem, productosToolStripMenuItem, pedidosToolStripMenuItem, estadisticasToolStripMenuItem, informesToolStripMenuItem, acercaDeToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // staffToolStripMenuItem
            // 
            staffToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaEmpleadosToolStripMenuItem, modificarEmpleadosToolStripMenuItem, bajaDeEmpleadosToolStripMenuItem });
            staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            staffToolStripMenuItem.Size = new Size(46, 21);
            staffToolStripMenuItem.Text = "Staff";
            // 
            // altaEmpleadosToolStripMenuItem
            // 
            altaEmpleadosToolStripMenuItem.Name = "altaEmpleadosToolStripMenuItem";
            altaEmpleadosToolStripMenuItem.Size = new Size(201, 22);
            altaEmpleadosToolStripMenuItem.Text = "Alta empleados";
            altaEmpleadosToolStripMenuItem.Click += altaEmpleadosToolStripMenuItem_Click;
            // 
            // modificarEmpleadosToolStripMenuItem
            // 
            modificarEmpleadosToolStripMenuItem.Name = "modificarEmpleadosToolStripMenuItem";
            modificarEmpleadosToolStripMenuItem.Size = new Size(201, 22);
            modificarEmpleadosToolStripMenuItem.Text = "Modificar empleados";
            modificarEmpleadosToolStripMenuItem.Click += modificarEmpleadosToolStripMenuItem_Click;
            // 
            // bajaDeEmpleadosToolStripMenuItem
            // 
            bajaDeEmpleadosToolStripMenuItem.Name = "bajaDeEmpleadosToolStripMenuItem";
            bajaDeEmpleadosToolStripMenuItem.Size = new Size(201, 22);
            bajaDeEmpleadosToolStripMenuItem.Text = "Baja de empleados";
            bajaDeEmpleadosToolStripMenuItem.Click += bajaDeEmpleadosToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaDeProductosToolStripMenuItem, modificarProductoToolStripMenuItem, bajaDeProductoToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(79, 21);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // altaDeProductosToolStripMenuItem
            // 
            altaDeProductosToolStripMenuItem.Name = "altaDeProductosToolStripMenuItem";
            altaDeProductosToolStripMenuItem.Size = new Size(190, 22);
            altaDeProductosToolStripMenuItem.Text = "Alta de productos";
            // 
            // modificarProductoToolStripMenuItem
            // 
            modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            modificarProductoToolStripMenuItem.Size = new Size(190, 22);
            modificarProductoToolStripMenuItem.Text = "Modificar producto";
            // 
            // bajaDeProductoToolStripMenuItem
            // 
            bajaDeProductoToolStripMenuItem.Name = "bajaDeProductoToolStripMenuItem";
            bajaDeProductoToolStripMenuItem.Size = new Size(190, 22);
            bajaDeProductoToolStripMenuItem.Text = "Baja de producto";
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaToolStripMenuItem, modificarToolStripMenuItem });
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(67, 21);
            pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // nuevaToolStripMenuItem
            // 
            nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            nuevaToolStripMenuItem.Size = new Size(180, 22);
            nuevaToolStripMenuItem.Text = "Nueva";
            nuevaToolStripMenuItem.Click += nuevaToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(180, 22);
            modificarToolStripMenuItem.Text = "Modificar";
            // 
            // estadisticasToolStripMenuItem
            // 
            estadisticasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { totalPedidosPorClienteToolStripMenuItem, productosPorCategoriaToolStripMenuItem });
            estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            estadisticasToolStripMenuItem.Size = new Size(87, 21);
            estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // totalPedidosPorClienteToolStripMenuItem
            // 
            totalPedidosPorClienteToolStripMenuItem.Name = "totalPedidosPorClienteToolStripMenuItem";
            totalPedidosPorClienteToolStripMenuItem.Size = new Size(222, 22);
            totalPedidosPorClienteToolStripMenuItem.Text = "Total pedidos por cliente";
            // 
            // productosPorCategoriaToolStripMenuItem
            // 
            productosPorCategoriaToolStripMenuItem.Name = "productosPorCategoriaToolStripMenuItem";
            productosPorCategoriaToolStripMenuItem.Size = new Size(222, 22);
            productosPorCategoriaToolStripMenuItem.Text = "Productos por categoria";
            // 
            // informesToolStripMenuItem
            // 
            informesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { facturaToolStripMenuItem });
            informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            informesToolStripMenuItem.Size = new Size(71, 21);
            informesToolStripMenuItem.Text = "Informes";
            // 
            // facturaToolStripMenuItem
            // 
            facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            facturaToolStripMenuItem.Size = new Size(118, 22);
            facturaToolStripMenuItem.Text = "Factura";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(91, 21);
            acercaDeToolStripMenuItem.Text = "Acerca de ...";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(45, 21);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripSeparator1, toolStripLabel2, toolStripSeparator2, toolStripLabel3 });
            toolStrip1.Location = new Point(0, 25);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1264, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Image = (Image)resources.GetObject("toolStripLabel1.Image");
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(98, 22);
            toolStripLabel1.Text = "Nuevo Pedido";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Image = Properties.Resources.lupa;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(110, 22);
            toolStripLabel2.Text = "Buscar Producto";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Image = Properties.Resources.imprimir;
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(132, 22);
            toolStripLabel3.Text = "Imprimir una factura";
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.MediumSeaGreen;
            pictureBox.Image = Properties.Resources.usuario;
            pictureBox.Location = new Point(1152, 64);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(100, 102);
            pictureBox.TabIndex = 4;
            pictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1152, 179);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1264, 861);
            Controls.Add(label1);
            Controls.Add(pictureBox);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Principal";
            FormClosing += Principal_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem staffToolStripMenuItem;
        private ToolStripMenuItem altaEmpleadosToolStripMenuItem;
        private ToolStripMenuItem modificarEmpleadosToolStripMenuItem;
        private ToolStripMenuItem bajaDeEmpleadosToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem altaDeProductosToolStripMenuItem;
        private ToolStripMenuItem modificarProductoToolStripMenuItem;
        private ToolStripMenuItem bajaDeProductoToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem nuevaToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem estadisticasToolStripMenuItem;
        private ToolStripMenuItem totalPedidosPorClienteToolStripMenuItem;
        private ToolStripMenuItem productosPorCategoriaToolStripMenuItem;
        private ToolStripMenuItem informesToolStripMenuItem;
        private ToolStripMenuItem facturaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel3;
        private PictureBox pictureBox;
        private Label label1;
    }
}