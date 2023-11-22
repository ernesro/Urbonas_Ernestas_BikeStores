using BikeStoresEntidades;
using Microsoft.IdentityModel.Tokens;
using NegocioBikeStores;
using System.Data;

namespace BikeStoresPresentacion {
    public partial class AltaPedido : Form {
        private Staff empleado;
        private Customer cliente;
        private Ventas venta = new Ventas();
        private OrderItem productoPedido;

        private DateTime order;
        private DateTime required;
        private DateTime shipped;

        private List<OrderItem> productosPedido = new List<OrderItem>();
        private List<Store> tiendas = new List<Store>();
        private List<Stock> stocks = new List<Stock>();
        private List<Stock> stockTiendaActual = new List<Stock>();

        private DataTable dataTable = new DataTable("Productos del pedido");
        private DataView dataView;

        public AltaPedido(Staff empleado, Customer cliente) {
            this.empleado = empleado;
            this.cliente = cliente;
            InitializeComponent();

            tiendas = venta.ListarStores();
            stocks = venta.ListarStock();
            foreach (var s in stocks) {
                if (s.StoreId.Equals(empleado.StoreId))
                    stockTiendaActual.Add(s);
            }
            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Producto", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(string));
            dataTable.Columns.Add("Descuento", typeof(string));
            dataTable.Columns.Add("Precio", typeof(string));

            CargarEmpleado();
            CargarCliente();
            CargarTiendas();
            CargarEstadoPedido();

            descuentoTb.Maximum = 99.99M;
            descuentoTb.DecimalPlaces = 2;

            precioSeleccionadoTb.Maximum = 99999999.99M;
            precioSeleccionadoTb.DecimalPlaces = 2;

            totalSeleccionadoTb.Maximum = 99999999999.99M;
            totalSeleccionadoTb.DecimalPlaces = 2;

            totalMasIvaTb.Maximum = 99999999999.99M;
            totalMasIvaTb.DecimalPlaces = 2;

            totalTb.Maximum = 99999999999.99M;
            totalTb.DecimalPlaces = 2;

            ivaTb.Maximum = 99999999999.99M;
            ivaTb.DecimalPlaces = 2;
        }

        private void CargarEmpleado() {
            //Cargamos los datos del empleado
            empleadoNombreTb.Text = empleado.FirstName.ToString();
            empleadoApellidoTb.Text = empleado.LastName.ToString();
            empleadoIdTb.Text = empleado.StaffId.ToString();
        }

        private void CargarCliente() {
            //Cargamos los datos del cliente
            clienteNombreTb.Text = cliente.FirstName.ToString();
            clienteApellidoTb.Text = cliente.LastName.ToString();
            clienteCorreoTb.Text = cliente.Email.ToString();
            if (!cliente.Phone.IsNullOrEmpty())
                clienteTelefonoTb.Text = cliente.Phone.ToString();
        }

        private void CargarTiendas() {
            //Combobox de store
            foreach (var t in tiendas) {
                tiendaCb.Items.Add(t.StoreName);

                if (t.StoreId.Equals(empleado.StoreId)) {
                    tiendaCb.SelectedIndex = t.StoreId - 1;
                }
            }
        }

        private void CargarEstadoPedido() {
            estadoPedidoCb.Items.Add("Creado");
            estadoPedidoCb.Items.Add("Preparado");
            estadoPedidoCb.Items.Add("Enviado");
        }

        private void shippedCkb_CheckedChanged(object sender, EventArgs e) {
            //Activamos o la seleccion de fecha en funcion del Check Box
            if (shippedCkb.Checked)
                shippedDtp.Enabled = true;
            else
                shippedDtp.Enabled = false;
        }

        private void anadirProductoBtn_Click(object sender, EventArgs e) {
            BusquedaProducto formBusqueda = new BusquedaProducto();
            formBusqueda.ShowDialog();

            Product productoSeleccionado = formBusqueda.DevolverProductoSeleccionado();
            if (VerificarStock(1, productoSeleccionado)) {
                OrderItem item = new OrderItem();
                item.Product = productoSeleccionado;
                item.Quantity = 1;
                item.ListPrice = productoSeleccionado.ListPrice;
                item.Discount = 0;
                item.ProductId = productoSeleccionado.ProductId;
                item.ItemId = productosPedido.Count + 1;
                productosPedido.Add(item);

                ActualizarGrid();
                CargarDatosProductoSeleccionado(item);
                ActualizarTotalPedido();

                stockTb.Value = (decimal)GetStock(item.Product);

            } else
                MessageBox.Show("Tienes que seleccionar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void eliminarProductoBtn_Click(object sender, EventArgs e) {
            if (productoPedido is not null) {
                productosPedido.Remove(productoPedido);
                ActualizarGrid();
                ActualizarTotalPedido();
                ClearDatosPedido();
            }

        }

        private bool VerificarStock(int cantidad, Product producto) {
            bool hayStock = false;
            int? stock = GetStock(producto);

            foreach (Stock s in stockTiendaActual) {
                if (s.ProductId.Equals(producto.ProductId)) {
                    if (s.Quantity > 0) {
                        hayStock = true;
                        s.Quantity -= cantidad;
                    }
                    break;
                }
            }
            return hayStock;
        }

        private int? GetStock(Product item) {
            int? stock = 0;
            foreach (var s in stockTiendaActual) {
                if (item.ProductId.Equals(s.ProductId)) {
                    stock = s.Quantity;
                    MessageBox.Show(stock.ToString());
                }
            }
            if (stock is null) {
                stock = 0;
            }
            return stock;
        }

        private void ActualizarGrid() {
            while (productosDgv.Rows.Count > 1) {
                productosDgv.Rows.RemoveAt(0);
            }
            foreach (var dato in productosPedido) {
                DataRow fila = dataTable.NewRow();
                fila["ID"] = dato.ItemId.ToString();
                fila["Producto"] = dato.Product.ProductName;
                fila["Cantidad"] = dato.Quantity.ToString();
                fila["Descuento"] = dato.Discount.ToString();
                fila["Precio"] = dato.ListPrice.ToString();

                dataTable.Rows.Add(fila);
                dataView = new DataView(dataTable);
            }
            productosDgv.DataSource = dataView;

            foreach (DataGridViewColumn column in productosDgv.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void CargarDatosProductoSeleccionado(OrderItem item) {
            precioSeleccionadoTb.Value = item.Product.ListPrice;
            cantidadTb.Value = item.Quantity;
            descuentoTb.Value = item.Discount;

            decimal precioSinDescuento = precioSeleccionadoTb.Value * cantidadTb.Value;
            decimal decuento = precioSinDescuento * descuentoTb.Value;
            decimal total = precioSinDescuento - decuento;

            totalSeleccionadoTb.Value = total;
        }

        private void ActualizarTotalPedido() {
            decimal total = 0;
            foreach (var i in productosPedido) {
                total += i.ListPrice;
            }
            totalTb.Value = total;
            ivaTb.Value = total * 0.21M;
            decimal totalMasIva = total + ivaTb.Value;
            totalMasIvaTb.Value = totalMasIva;
        }

        private void productosDgv_CellClick(object sender, DataGridViewCellEventArgs e) {
            string? idValue = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // Obtener el valor de la celda de la columna "ID"
                object cellValue = productosDgv.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue != null) {
                    idValue = cellValue.ToString();
                }
            }
            if (!idValue.IsNullOrEmpty()) {
                foreach (OrderItem c in productosPedido) {
                    if (c.ItemId.ToString().Equals(idValue)) {
                        productoPedido = c;
                        break;
                    }
                }
                CargarDatosProductoSeleccionado(productoPedido);
            }
        }

        private void ClearDatosPedido() {
            totalSeleccionadoTb.Value = 0;
        }
    }
}
