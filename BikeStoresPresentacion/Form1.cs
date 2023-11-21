using BikeStoresEntidades;
using NegocioBikeStores;

///<author> Ernestas Urbonas </author>
namespace BikeStoresPresentacion {
    public partial class Form1 : Form {                                               /* --------   Formulario de preba   -------------*/
        public Form1() {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e) {
            if (int.TryParse(textBox1.Text, out int orderId)) {

                Ventas ventas = new Ventas();
                List<Order> pedidos = ventas.DatosPedido(orderId);
                dataGridView1.DataSource = pedidos;


            } else {
                MessageBox.Show("Por favor, ingrese un número de pedido válido en el cuadro de texto.");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (int.TryParse(textBox3.Text, out int EmployeeId)) {

                Ventas ventas = new Ventas();
                List<Order> pedidos = ventas.ListarPedidosEmpleado(EmployeeId);
                dataGridView1.DataSource = pedidos;

            } else {
                MessageBox.Show("Por favor, ingrese un número de empleado válido en el cuadro de texto.");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (int.TryParse(textBox2.Text, out int CustomerId)) {

                Ventas ventas = new Ventas();
                List<Order> pedidos = ventas.ListarPedidosCLiente(CustomerId);
                dataGridView1.DataSource = pedidos;

            } else {
                MessageBox.Show("Por favor, ingrese un número de pedido válido en el cuadro de texto.");
            }
        }

    }
}