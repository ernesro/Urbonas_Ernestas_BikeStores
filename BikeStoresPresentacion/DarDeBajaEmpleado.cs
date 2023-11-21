using BikeStoresEntidades;
using NegocioBikeStores;

///<author> Ernestas Urbonas </author> 
namespace BikeStoresPresentacion {
    public partial class DarDeBajaEmpleado : Form {
        private Staff empleado;
        public DarDeBajaEmpleado(Staff empleado) {
            InitializeComponent();
            this.empleado = empleado;
            DarDeBaja();
        }

        private void DarDeBaja() {      //Muestro un mensaje para confirmar si desea borrar este empleado
            DialogResult resultado = MessageBox.Show($"¿Estás seguro de querer dar de baja a este empleado?\n{"Id: " + empleado.StaffId + "\nNombre: " + empleado.FirstName + " " + empleado.LastName + "\nEmail: " + empleado.Email}", "Confirmar Eliminación"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) {    //Lo ponemos en 0 para desacivar el empleado
                empleado.Active = 0;

                Ventas ventas = new Ventas();
                ventas.ModificarSatff(empleado);    //Acemos Update al empleado
                Close();
            }
        }
    }
}
