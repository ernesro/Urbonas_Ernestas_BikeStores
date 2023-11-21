using BikeStoresEntidades;
using Microsoft.IdentityModel.Tokens;
using NegocioBikeStores;
using System.Data;

namespace BikeStoresPresentacion {
    public partial class FormularioBusquedaStaff : Form {
        private List<Staff> empleadosActivos = new List<Staff>();
        private List<Staff> empleados = new List<Staff>();
        private DataTable dataTable = new DataTable("Empleados Activos");
        private DataView dataView;
        private string accion;

        public FormularioBusquedaStaff(string accion) {
            Ventas ventas = new Ventas();
            this.accion = accion;

            empleados = ventas.ListarEmpleados();
            foreach (Staff staff in empleados) {
                if (staff.Active == 1) {
                    empleadosActivos.Add(staff);
                }
            }
            InitializeComponent();

            //dataEmpleadosDgv.DataSource = empleadosActivos;

            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Telefono", typeof(string));
            dataTable.Columns.Add("Manager", typeof(string));
            dataTable.Columns.Add("Tienda", typeof(string));

            foreach (var dato in empleadosActivos) {
                DataRow fila = dataTable.NewRow();
                fila["ID"] = dato.StaffId.ToString();
                fila["Nombre"] = dato.FirstName;
                fila["Apellido"] = dato.LastName;
                fila["Email"] = dato.Email;
                fila["Telefono"] = dato.Phone;
                if (dato.Manager is not null)
                    fila["Manager"] = dato.Manager.FirstName + " " + dato.Manager.LastName;
                fila["Tienda"] = dato.Store.StoreName;

                dataTable.Rows.Add(fila);
                dataView = new DataView(dataTable);
            }
        }

        private void busquedaLb_TextChanged(object sender, EventArgs e) {
            string valorBuscado = busquedaLb.Text;

            string filtro = $"Nombre LIKE '%{valorBuscado}%' OR Apellido LIKE '%{valorBuscado}%' OR Email LIKE '%{valorBuscado}%'";
            dataView.RowFilter = filtro;

            dataEmpleadosDgv.DataSource = dataView;
        }

        private void dataEmpleadosDgv_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            string idValue = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // Obtener el valor de la celda de la columna "ID"
                object cellValue = dataEmpleadosDgv.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue != null) {
                    idValue = cellValue.ToString();

                }
            }
            if (!idValue.IsNullOrEmpty()) {
                Staff empleadoSeleccion = new Staff();
                foreach (Staff s in empleadosActivos) {
                    if (s.StaffId.ToString().Equals(idValue)) {
                        empleadoSeleccion = s;

                        break;
                    }
                }
                if (accion.Equals("modificar")) {
                    InsertarStaff form = new InsertarStaff("modificar", empleadoSeleccion);
                    form.Show();
                    Hide();
                    form.FormClosed += (sender, e) => {
                        Close();
                    };
                } else if (accion.Equals("borrar")) {
                    DarDeBajaEmpleado form = new DarDeBajaEmpleado(empleadoSeleccion);

                    Hide();
                    form.FormClosed += (sender, e) => {
                        Close();
                    };
                }
            }
        }
    }
}
