using BikeStoresEntidades;
using Microsoft.IdentityModel.Tokens;
using NegocioBikeStores;
using System.Data;

namespace BikeStoresPresentacion {
    public partial class AltaPedido : Form {
        private Staff empleado;
        private Customer cliente;
        private Ventas venta = new Ventas();
        private DateTime order;
        private DateTime required;
        private DateTime shipped;

        private List<OrderItem> productosPedido = new List<OrderItem>();
        private List<Store> tiendas = new List<Store>();

        private DataTable dataTable = new DataTable("Productos del pedido");
        private DataView dataView;

        public AltaPedido(Staff empleado, Customer cliente) {
            this.empleado = empleado;
            this.cliente = cliente;
            InitializeComponent();

            tiendas = venta.ListarStores();

            dataTable.Columns.Add("Producto", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(string));
            dataTable.Columns.Add("Precio", typeof(string));
            dataTable.Columns.Add("Descuento", typeof(string));



            CargarEmpleado();
            CargarCliente();
            CargarTiendas();
            CargarEstadoPedido();
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

        }
    }
}



/*public void CargarTabla() {
    foreach (var dato in clientes) {
        DataRow fila = dataTable.NewRow();
        fila["ID"] = dato.CustomerId.ToString();
        fila["Nombre"] = dato.FirstName;
        fila["Apellido"] = dato.LastName;
        fila["Email"] = dato.Email;
        fila["Telefono"] = dato.Phone;

        dataTable.Rows.Add(fila);
        dataView = new DataView(dataTable);
    }
    dataGridView1.DataSource = dataView;

    foreach (DataGridViewColumn column in dataGridView1.Columns) {
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }
}*/