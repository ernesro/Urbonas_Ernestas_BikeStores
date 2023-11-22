using BikeStoresEntidades;
using Microsoft.IdentityModel.Tokens;
using NegocioBikeStores;
using System.Data;

namespace BikeStoresPresentacion {
    public partial class BuscadorCliente : Form {
        private List<Customer> clientes = new List<Customer>();
        private Staff empleado;
        private Customer customerSeleccion = new Customer();
        private Ventas ventas = new Ventas();
        private DataTable dataTable = new DataTable("Clientes");
        private DataView dataView;

        public BuscadorCliente(Staff staff) {
            clientes = ventas.ListarCustomers();
            empleado = staff;
            InitializeComponent();

            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Telefono", typeof(string));

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
        }

        private void busquedaLb_TextChanged(object sender, EventArgs e) {
            string valorBuscado = buscadorTv.Text;

            string filtro = $"ID LIKE '%{valorBuscado}%' " +
                $"OR Nombre LIKE '%{valorBuscado}%' " +
                $"OR Apellido LIKE '%{valorBuscado}%' " +
                $"OR Email LIKE '%{valorBuscado}%' " +
                $"OR Telefono LIKE '%{valorBuscado}%'";
            dataView.RowFilter = filtro;

            dataGridView1.DataSource = dataView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            string? idValue = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // Obtener el valor de la celda de la columna "ID"
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue != null) {
                    idValue = cellValue.ToString();
                }
            }
            if (!idValue.IsNullOrEmpty()) {
                foreach (Customer c in clientes) {
                    if (c.CustomerId.ToString().Equals(idValue)) {
                        customerSeleccion = c;
                        break;
                    }
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e) {
            if (customerSeleccion is not null) {
                AltaPedido form = new AltaPedido(empleado, customerSeleccion);
                form.ShowDialog();
                Hide();
                form.FormClosed += (sender, e) => {
                    Close();
                };
            } else {
                MessageBox.Show("Tienes que seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            string? idValue = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // Obtener el valor de la celda de la columna "ID"
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue != null) {
                    idValue = cellValue.ToString();
                }
            }
            if (!idValue.IsNullOrEmpty()) {
                foreach (Customer c in clientes) {
                    if (c.CustomerId.ToString().Equals(idValue)) {
                        customerSeleccion = c;
                        break;
                    }
                }
                AltaPedido form = new AltaPedido(empleado, customerSeleccion);
                form.ShowDialog();
                Hide();
                form.FormClosed += (sender, e) => {
                    Close();
                };
            }
        }
    }
}
