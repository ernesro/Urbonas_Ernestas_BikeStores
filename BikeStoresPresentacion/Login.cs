using BikeStoresEntidades;
using NegocioBikeStores;
using System.Text.RegularExpressions;

///<author> Ernestas Urbonas </author>
namespace BikeStoresPresentacion {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
            textBox1.PlaceholderText = "example@gmail.com";     //Aqui ponemos un ejmplo de correo

        }

        private void Button1_Click(object sender, EventArgs e)  //Boton Log in para iniciar sesion
        {
            if (ValidadorEmail(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))      //Validamos los campos email y contraseña
            {
                TryLogin(textBox1.Text, textBox2.Text);     //Si esatn bien intentamos iniciar sesion
            } else    //Si no , mostramos error
              {
                MessageBox.Show("Error" + ". Verifique sus credenciales.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool ValidadorEmail(string email)       //Validar email
        {
            if (string.IsNullOrWhiteSpace(email))       //si es null o esta vacio devolvemos falso
                return false;

            // si tiene valor, usamos una expresión regular para validar el formato del correo electrónico
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);   // devolvemos true si es correcto, false si no lo es
        }

        private void TryLogin(string user, string password)     // Intentar inicio de sesion
        {
            bool usuarioEncontrado = false;
            Ventas ventas = new Ventas();
            Staff staff = new Staff();
            List<Staff> list = ventas.ListarEmpleados();        //Obtenemos una lista con todos los empleados

            foreach (Staff s in list) {

                if (s.Email.ToLower().Equals(user.ToLower()))   //comprobamos uno a uno si el correo coincide con alguno de los empleados
                {
                    // Verificar la contraseña utilizando la función SHA256 si el correo coincide con alguno
                    string hashedPassword = ventas.HashPassword(password);
                    if (s.PasswordStaff == hashedPassword) {
                        Principal form = new Principal(s, this);  //creamos el formulario Principal, le pasamos el usuario que inició sesión y este form
                        form.Show();                        //Mostramos el formulario
                        this.Hide();                        //Escondemos este formulario
                        usuarioEncontrado = true;
                        ClearTextBox();
                        break;
                    }
                }
            }
            if (!usuarioEncontrado)             //Si no encontramos el usuario mostramos un error
            {
                MessageBox.Show("Usuario no encontrado. Verifique sus credenciales.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label3_Click(object sender, EventArgs e)   //Boton para limpiar el textbox
        {
            ClearTextBox();
        }

        private void label2_Click(object sender, EventArgs e)   //Boton para cerrar la aplicación
        {
            Application.Exit();
        }

        private void ClearTextBox()     //Limpiar Text Box
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
