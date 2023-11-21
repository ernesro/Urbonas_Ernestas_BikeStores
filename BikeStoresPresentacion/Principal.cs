using BikeStoresEntidades;

///<author> Ernestas Urbonas </author>
namespace BikeStoresPresentacion {
    public partial class Principal : Form {
        private Staff staff;
        private Form loginForm;
        public Principal(Staff staff, Form login)  //Aqui obtenemos el empleado que inició sesión
        {
            InitializeComponent();
            loginForm = login;
            this.staff = staff;
            LoadImage();
            label1.Text = staff.FirstName + " " + staff.LastName;   //Caargamo el nombre en el label
        }

        //Cargar la imagen del empleado
        private void LoadImage() {
            if (staff.ImageStaff != null)                                       //Si no es null cargamos su imagen
                using (MemoryStream ms = new MemoryStream(staff.ImageStaff)) {
                    pictureBox.Image = Image.FromStream(ms);
                }
            else                                                                //Si es null ponemos una por defecto
                pictureBox.Image = Properties.Resources.usuario;

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;                      //Ajusto la imagen al picturebox
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)   //Al cerra esta venta cerramos la ventana login
        {
            loginForm.Close();
        }

        private void altaEmpleadosToolStripMenuItem_Click(object sender, EventArgs e) {
            InsertarStaff form = new InsertarStaff("insertar", null);  //creamos el formulario Principal, le pasamos el usuario que inició sesión y este form
            form.ShowDialog();

        }

        private void modificarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e) {
            FormularioBusquedaStaff form = new FormularioBusquedaStaff("modificar");
            form.ShowDialog();
        }

        private void bajaDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e) {
            FormularioBusquedaStaff form = new FormularioBusquedaStaff("borrar");
            form.ShowDialog();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e) {
            BuscadorCliente form = new BuscadorCliente(staff);
            form.ShowDialog();
        }
    }
}
