using BikeStoresEntidades;
using BikeStoresPresentacion.Interfaces;
using Microsoft.IdentityModel.Tokens;
using NegocioBikeStores;
using System.Data;

namespace BikeStoresPresentacion {
    public partial class BusquedaProducto : Form, IFormProducto {
        private Product producto;
        private List<Product> productos = new List<Product>();
        private List<Category> categorias = new List<Category>();
        private List<Brand> marcas = new List<Brand>();
        private Ventas ventas = new Ventas();

        private DataTable dataTable = new DataTable("Productos");
        private DataView dataView;

        public BusquedaProducto() {
            InitializeComponent();
            productos = ventas.ListarProductos();
            categorias = ventas.ListarCategorias();
            marcas = ventas.ListarMarcas();
            CargarCategoriaComboBox();


            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Categoria", typeof(string));
            dataTable.Columns.Add("Marca", typeof(string));
            dataTable.Columns.Add("Precio", typeof(string));

            foreach (var dato in productos) {
                DataRow fila = dataTable.NewRow();
                fila["ID"] = dato.ProductId.ToString();
                fila["Nombre"] = dato.ProductName.ToString();
                foreach (var categoria in categorias) {
                    if (categoria.CategoryId.Equals(dato.CategoryId)) {
                        fila["Categoria"] = categoria.CategoryName.ToString();
                        break;
                    }
                }
                foreach (var marca in marcas) {
                    if (marca.BrandId.Equals(dato.BrandId)) {
                        fila["Marca"] = marca.BrandName.ToString();
                        break;
                    }
                }
                fila["Precio"] = dato.ListPrice.ToString();

                dataTable.Rows.Add(fila);
                dataView = new DataView(dataTable);
            }
            dataGridView1.DataSource = dataView;

            foreach (DataGridViewColumn column in dataGridView1.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void CargarCategoriaComboBox() {
            foreach (var dato in categorias) {
                categoriaCb.Items.Add(dato.CategoryName.ToString());
            }
        }

        private void categoriaCb_SelectedIndexChanged(object sender, EventArgs e) {
            if (!categoriaCb.Text.IsNullOrEmpty()) {
                string filtro = $"Categoria LIKE '%{categoriaCb.Text}%' ";
                dataView.RowFilter = filtro;

                dataGridView1.DataSource = dataView;
            }

        }

        private void productoTb_TextChanged(object sender, EventArgs e) {
            if (!productoTb.Text.IsNullOrEmpty()) {
                string filtro = $"Nombre LIKE '%{productoTb.Text}%' ";
                dataView.RowFilter = filtro;

                dataGridView1.DataSource = dataView;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            string? idValue = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // Obtener el valor de la celda de la columna "ID"
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue != null) {
                    idValue = cellValue.ToString();
                }
            }
            if (!idValue.IsNullOrEmpty()) {
                foreach (Product p in productos) {
                    if (p.ProductId.ToString().Equals(idValue)) {
                        producto = p;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (producto is not null) {
                this.Close();
            } else {
                MessageBox.Show("Tienes que seleccionar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            string? idValue = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // Obtener el valor de la celda de la columna "ID"
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue != null) {
                    idValue = cellValue.ToString();
                }
            }
            if (!idValue.IsNullOrEmpty()) {
                foreach (Product p in productos) {
                    if (p.ProductId.ToString().Equals(idValue)) {
                        producto = p;
                        break;
                    }
                }
                this.Close();
            }
        }

        public Product DevolverProductoSeleccionado() {
            return producto;
        }
    }
}
