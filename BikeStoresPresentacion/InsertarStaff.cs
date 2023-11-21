using BikeStoresEntidades;
using Microsoft.IdentityModel.Tokens;
using NegocioBikeStores;
using System.Text.RegularExpressions;

///<author> Ernestas Urbonas </author> 
namespace BikeStoresPresentacion {
    public partial class InsertarStaff : Form {

        private List<Staff> staffs = new List<Staff>();
        private List<Store> stores = new List<Store>();
        private Ventas venta;

        private Image imagen = Properties.Resources.SIN_FOTO;
        string rutaImg;

        private Staff? seleccion;
        private string tipoAccion;


        public InsertarStaff(string tipoAccion, Staff? staffSeleccionado = null) {      //Recibimos el empleado y la accion ("modificar" o "insertar")
            InitializeComponent();
            venta = new Ventas();
            staffs = venta.ListarEmpleados();
            stores = venta.ListarStores();

            CargarTodosComboBox();

            //Ocultamos el id de el empleado y mas adelante si es necesario se mostrara
            idLb.Hide();
            tipoLb.Hide();

            //Datos para saber el tipo del formulario
            seleccion = staffSeleccionado;
            this.tipoAccion = tipoAccion.ToLower();

            //En funcion del tipo de accion cargamos el formulario para modificar o no
            if (tipoAccion.Equals("modificar"))
                CargarModificarStaff();
        }


        public string? ValidarString(bool nulo, int longMax, string cadena) {       // Valida una cadena esta vacia, supera el maximo de longitud
            string? error = null;                                                   // o si puede ser nulo o no. 
            if (cadena.Length <= longMax) {         //Comprueba la longitud
                if (!nulo) {                        //Si puede ser nulo
                    if (cadena.IsNullOrEmpty()) {   //Si es nulo cuando no puede serlo
                        error = "Este campo es obligatorio";
                    }
                }
            } else { error = "La longitud no puede se mayor de " + longMax; }

            return error;  // Si todo esta en orden devuelve null si no devuelve el error
        }


        private bool ValidadorEmail(string email)       //Validar email
        {
            if (string.IsNullOrWhiteSpace(email))       //si es null o esta vacio devolvemos falso
                return false;

            // si tiene valor, usamos una expresión regular para validar el formato del correo electrónico
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);   // devolvemos true si es correcto, false si no lo es
        }


        private string? ValidarTelefono(string numero) {
            List<char> numeroPrimeroPermitido = new List<char> { '6', '7', '8', '9' };      //Primer numero permitido en el numero de telefono
            List<string> codigosPaises = new List<string> { "+34", "+49", "+352", "+57", "+52", "+54", "+1", "+234"                 // Codigos telefonicos de los paises : España,
                                                           ,"0034", "0049", "0352", "0057", "0052", "0054", "0001", "0234" };       // Alemania, Irlanda, Colombia, Méjico, Argentina, Estados Unidos y Nigeria)
            string? error = null;
            List<string> posibleCodigo = new List<string> { numero.Substring(0, 2), numero.Substring(0, 3), numero.Substring(0, 4) };   //posibles codigos del numero de telefonno
            string codigo = "";
            string numeroSinCod;

            if (numero[0] == '+') {                                 //Comprobamos si empieza por + y si es asi guardamos los posibles codigos en funcionm de la longitud de este
                if (codigosPaises.Contains(posibleCodigo[0])) {     //Si es correcto lo guardamos
                    codigo = posibleCodigo[0];
                } else if (codigosPaises.Contains(posibleCodigo[1])) {
                    codigo = posibleCodigo[1];
                } else if (codigosPaises.Contains(posibleCodigo[2])) {
                    codigo = posibleCodigo[2];
                } else {
                    error = "Codigo de pais incorrecto. Ejemplo: +34 o 0034";
                }
            } else if (numero[0] == '0') {      //Comprobamos el codigo si empieza por 0 y si es correcto lo guardamos
                if (codigosPaises.Contains(numero.Substring(0, 4))) {
                    codigo = numero.Substring(0, 4);
                }
            } else { error = "Codigo de pais incorrecto. Ejemplo: +34 o 0034"; }

            if (error == null) {                                    //Si no ha habido ningun error con el codigo seguimos con el numero de telefono
                numeroSinCod = numero.Substring(codigo.Length);     //Obtenemos el numero sin el codigo
                if (numeroSinCod.Length != 9) {                     //Comprobamos s longitud
                    error = "Longitud del numero de telefono incorrecto. Debe der 9 sin el codigo";
                } else if (!numeroPrimeroPermitido.Contains(numeroSinCod[0])) {     //Si la longitud es correcta comprobamos que el primer numero del numero sea correcto
                    error = "Error, el numero de telefono debe empezar por 6 , 7 , 8 o 9";
                }
            }
            return error;
        }


        private bool EsCorreoUnico(string correo) {     //Comprueba si el correo es unico

            List<string> correos = new List<string>();
            foreach (var s in staffs) {
                correos.Add(s.Email);                           //obtenemos sus correos de los empleados
            }
            return !correos.Contains(correo);                    //devolvemos verdadero si no existe y falso si existe
        }


        private void nombreTb_TextChanged(object sender, EventArgs e) {     //VAlidacion para el campo Nombre
            string? error = ValidarString(false, 50, nombreTb.Text);
            if (!error.IsNullOrEmpty()) {
                errorNombre.SetError(nombreTb, error);
                nombreTb.BackColor = Color.IndianRed;
            } else {
                errorNombre.Clear();
                nombreTb.BackColor = Color.LightGreen;
            }
        }


        private void apellidoTb_TextChanged(object sender, EventArgs e) {       //Validacion para el campo Apellido
            string? error = ValidarString(false, 50, apellidoTb.Text);
            if (!error.IsNullOrEmpty()) {
                errorApellido.SetError(apellidoTb, error);
                apellidoTb.BackColor = Color.IndianRed;
            } else {
                errorApellido.Clear();
                apellidoTb.BackColor = Color.LightGreen;
            }
        }


        private void emailTb_TextChanged(object sender, EventArgs e) {          // Validacion para el campo email
            string? error = ValidarString(false, 255, emailTb.Text);
            if (!error.IsNullOrEmpty()) {                   // Que no sea nulo
                errorEmail.SetError(emailTb, error);
                emailTb.BackColor = Color.IndianRed;
            } else {
                if (ValidadorEmail(emailTb.Text)) {         //VAlidando que tenga el formato correcto
                    if (EsCorreoUnico(emailTb.Text) || (seleccion != null && emailTb.Text.Equals(seleccion.Email))) {      //Comprobando que sea unico
                        errorEmail.Clear();
                        emailTb.BackColor = Color.LightGreen;
                    } else {
                        errorEmail.SetError(emailTb, "Este correo ya existe. Introduce otro.");
                        emailTb.BackColor = Color.IndianRed;
                    }
                } else {
                    errorEmail.SetError(emailTb, "El email debe tener un formato correcto: exaple@gmail.com");
                    emailTb.BackColor = Color.IndianRed;
                }
            }
        }


        private void telefonoTb_TextChanged(object sender, EventArgs e) {  //Validacion para el campo Telefono
            errorTelefono.Clear();
            string? errorString = ValidarString(true, 25, telefonoTb.Text); //Validamos el string
            string? errorFormatoTelefono;

            if (!errorString.IsNullOrEmpty()) {                 //Error en este caso solo de puede dar al sobrepasar la longitd maxima del string
                errorTelefono.SetError(telefonoTb, errorString);
                telefonoTb.BackColor = Color.IndianRed;
            } else {                                             //Si no hay ningun error comienza la validacion del numero
                if (telefonoTb.Text.IsNullOrEmpty()) {           //Como telefono puede ser null hago una comprobacion para no validar en caso de que sea null
                    errorTelefono.Clear();
                    telefonoTb.BackColor = Color.LightGreen;
                } else if (telefonoTb.Text.Length > 3) {         //Si no es null y ya hay un posibel codigo comprobamos el telefono
                    errorFormatoTelefono = ValidarTelefono(telefonoTb.Text);       //Validamos y obtenemos el posible error
                    if (!errorFormatoTelefono.IsNullOrEmpty()) {
                        errorTelefono.SetError(telefonoTb, errorFormatoTelefono);     //Si hay un error en la vaslidacion lo mostramos
                        telefonoTb.BackColor = Color.IndianRed;
                    } else {                                                    //Si no todo esta correcto
                        errorTelefono.Clear();
                        telefonoTb.BackColor = Color.LightGreen;
                    }
                } else {
                    errorTelefono.SetError(telefonoTb, "Longitud incorrecta. Minimo 11 caracteres.");
                    telefonoTb.BackColor = Color.IndianRed;
                }
            }
        }


        private void contraseniaTb_TextChanged(object sender, EventArgs e) {        // Validacion para el campo Contraseña
            string? error = ValidarString(false, 255, emailTb.Text);
            if (error.IsNullOrEmpty()) {
                errorContrasenia.Clear();
                contraseniaTb.BackColor = Color.LightGreen;
            } else {
                errorContrasenia.SetError(contraseniaTb, error);
                contraseniaTb.BackColor = Color.IndianRed;
            }
        }


        private void tiendaCb_SelectedIndexChanged(object sender, EventArgs e) {        //Validacion para la selecion de tienda
            if (tiendaCb.Text.IsNullOrEmpty()) {
                errorTienda.SetError(tiendaCb, "Este campo es obligatorio");
                tiendaCb.BackColor = Color.IndianRed;
            } else {
                foreach (var s in stores) {
                    if (tiendaCb.Text.Equals(s.StoreName)) {                            //Si la seleccion existe quitamos errores
                        errorTienda.Clear();
                        tiendaCb.BackColor = Color.LightGreen;
                        break;
                    } else {
                        errorTienda.SetError(tiendaCb, "La tienda elegida no existe");
                        tiendaCb.BackColor = Color.IndianRed;
                    }
                }
            }
        }


        private void managerCb_SelectedIndexChanged(object sender, EventArgs e) {       //Validacion para la selecion de manager
            if (managerCb.Text.IsNullOrEmpty()) {
                errorManager.Clear();
                managerCb.BackColor = Color.LightGreen;
            } else {
                foreach (var s in staffs) {
                    if (managerCb.Text.ToString().Equals(s.FirstName + " " + s.LastName)) {  //Si la seleccion existe quitamos errores
                        errorManager.Clear();
                        managerCb.BackColor = Color.LightGreen;
                        break;
                    } else {
                        errorManager.SetError(managerCb, "El manager elegido no existe");
                        managerCb.BackColor = Color.IndianRed;
                    }
                }
            }
        }


        private void imgBt_Click(object sender, EventArgs e) {              //Obtencion de la imagen del empleado
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;;*.png;";     //Filtro de tipo de archivos
            Byte[] imagenByte;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {           //Si selecionamos una imagen obtenemos la ruta
                rutaImg = openFileDialog.FileName;
            }

            if (!rutaImg.IsNullOrEmpty()) {              //Si la ruta no es nula, ponemos la imagen selecionada
                imagen = Image.FromFile(rutaImg);
            }
            pictureBox1.Image = imagen;             //Cargar la imagen en un picturebox
        }


        private void CargarTodosComboBox() {
            //Combobox de store
            foreach (var s in stores) {
                tiendaCb.Items.Add(s.StoreName);
            }

            //Combobox de manager
            foreach (var s in staffs) {
                managerCb.Items.Add(s.FirstName + " " + s.LastName);
            }
        }


        private void altaBtn_Click(object sender, EventArgs e) {
            nombreTb_TextChanged(sender, e);                    //Al intentar dar de alta al empleado validamos todos los campos
            apellidoTb_TextChanged(sender, e);
            telefonoTb_TextChanged(sender, e);
            emailTb_TextChanged(sender, e);
            tiendaCb_SelectedIndexChanged(sender, e);
            managerCb_SelectedIndexChanged(sender, e);
            contraseniaTb_TextChanged(sender, e);

            if (errorNombre.GetError(nombreTb).IsNullOrEmpty() && errorApellido.GetError(apellidoTb).IsNullOrEmpty() &&     //Si no hay errores en ninguno de los campos
                errorEmail.GetError(emailTb).IsNullOrEmpty() && errorTelefono.GetError(telefonoTb).IsNullOrEmpty() &&       //procedemos a insertar o modificar el empleado
                errorTienda.GetError(tiendaCb).IsNullOrEmpty() && errorManager.GetError(managerCb).IsNullOrEmpty() &&
                errorContrasenia.GetError(contraseniaTb).IsNullOrEmpty()) {

                Staff empleado = new Staff();           //Creo Empleado y le asigno los datos del formulario

                empleado.FirstName = nombreTb.Text;

                empleado.LastName = apellidoTb.Text;

                empleado.Phone = telefonoTb.Text;

                empleado.Email = emailTb.Text;

                foreach (var s in stores) {     //Busco la tienda seleccionada
                    if (s.StoreName.Equals(tiendaCb.Text)) {
                        empleado.StoreId = s.StoreId;
                        break;
                    }
                }

                if (managerCb.Text != null) {       //Busco el manager seleccionado
                    foreach (var s in staffs) {
                        if ((s.FirstName + " " + s.LastName).Equals(managerCb.Text)) {
                            empleado.ManagerId = s.StaffId;
                            break;
                        }
                    }
                }
                //Formateo la imgen a array de Bytes                    
                using (MemoryStream memoryStream = new MemoryStream()) {
                    imagen.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    empleado.ImageStaff = memoryStream.ToArray();
                }

                empleado.Active = 1;            //Activo el usuario
                if (!tipoAccion.Equals("modificar") || contraseniaTb.Text != seleccion.PasswordStaff)
                    empleado.PasswordStaff = venta.HashPassword(contraseniaTb.Text);    //Encripto la contraseña
                else
                    empleado.PasswordStaff = seleccion.PasswordStaff;

                if (tipoAccion.Equals("insertar")) {        //Insertamos o Modificamos un empleado en funcion de tipoAccion
                    venta.InsertarSatff(empleado);
                    Close();
                } else if (tipoAccion.Equals("modificar")) {
                    empleado.StaffId = seleccion.StaffId;
                    venta.ModificarSatff(empleado);
                    Close();
                }

            } else {    //Si hay algun error no insertamos o modificamos y lanzamos un error
                MessageBox.Show("No puedes dar de alta al empleado. Corrige los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void clearBtn_Click(object sender, EventArgs e) {   //Limpiar todos los campos
            nombreTb.Clear();
            apellidoTb.Clear();
            emailTb.Clear();
            telefonoTb.Clear();
            tiendaCb.Text = string.Empty;
            managerCb.Text = string.Empty;
            contraseniaTb.Clear();
            pictureBox1.Image = imagen;
        }


        private void CargarModificarStaff() {       //Si queremos modificar un empleado el formulario se modificara de la siguiente manera

            altaBtn.Text = "Modificar empleado";    //Mofificamos datos basicos
            tituloFormLb.Text = "Modificacion de Empleados";
            this.Text = "Modificar empleado";
            //Mostramos el id
            idLb.Show();
            tipoLb.Show();

            //Cargamos los datos
            idLb.Text = seleccion.StaffId.ToString();
            nombreTb.Text = seleccion.FirstName;
            apellidoTb.Text = seleccion.LastName;
            telefonoTb.Text = seleccion.Phone;
            emailTb.Text = seleccion.Email;
            contraseniaTb.Text = seleccion.PasswordStaff;

            if (seleccion.Manager is not null) {
                managerCb.Text = seleccion.Manager.FirstName + " " + seleccion.Manager.LastName;
            }

            tiendaCb.Text = seleccion.Store.StoreName;

            if (seleccion.ImageStaff is not null) {
                using (MemoryStream ms = new MemoryStream(seleccion.ImageStaff)) {
                    pictureBox1.Image = Image.FromStream(ms);
                    imagen = pictureBox1.Image;
                }
            }
        }
    }
}