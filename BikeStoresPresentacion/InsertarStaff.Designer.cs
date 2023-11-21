namespace BikeStoresPresentacion {
    partial class InsertarStaff {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            tituloFormLb = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            nombreTb = new TextBox();
            apellidoTb = new TextBox();
            emailTb = new TextBox();
            telefonoTb = new TextBox();
            contraseniaTb = new TextBox();
            altaBtn = new Button();
            clearBtn = new Button();
            errorNombre = new ErrorProvider(components);
            managerCb = new ComboBox();
            tiendaCb = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            imgBt = new Button();
            pictureBox1 = new PictureBox();
            errorApellido = new ErrorProvider(components);
            errorEmail = new ErrorProvider(components);
            errorTelefono = new ErrorProvider(components);
            errorTienda = new ErrorProvider(components);
            errorManager = new ErrorProvider(components);
            errorContrasenia = new ErrorProvider(components);
            tipoLb = new Label();
            idLb = new Label();
            ((System.ComponentModel.ISupportInitialize)errorNombre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorApellido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorTelefono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorTienda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorContrasenia).BeginInit();
            SuspendLayout();
            // 
            // tituloFormLb
            // 
            tituloFormLb.AutoSize = true;
            tituloFormLb.Font = new Font("Cambria Math", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            tituloFormLb.Location = new Point(131, -3);
            tituloFormLb.Name = "tituloFormLb";
            tituloFormLb.Size = new Size(210, 106);
            tituloFormLb.TabIndex = 0;
            tituloFormLb.Text = "Alta de empleados";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 152);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 193);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 232);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 4;
            label5.Text = "Teléfono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 311);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 6;
            label7.Text = "Tienda";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 355);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 7;
            label8.Text = "Manager";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 475);
            label9.Name = "label9";
            label9.Size = new Size(122, 15);
            label9.TabIndex = 8;
            label9.Text = "Imagen del empleado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 395);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 9;
            label10.Text = "Contraseña";
            // 
            // nombreTb
            // 
            nombreTb.Location = new Point(184, 149);
            nombreTb.Name = "nombreTb";
            nombreTb.Size = new Size(218, 23);
            nombreTb.TabIndex = 10;
            nombreTb.TextChanged += nombreTb_TextChanged;
            // 
            // apellidoTb
            // 
            apellidoTb.Location = new Point(184, 190);
            apellidoTb.Name = "apellidoTb";
            apellidoTb.Size = new Size(218, 23);
            apellidoTb.TabIndex = 11;
            apellidoTb.TextChanged += apellidoTb_TextChanged;
            // 
            // emailTb
            // 
            emailTb.Location = new Point(184, 229);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(218, 23);
            emailTb.TabIndex = 12;
            emailTb.TextChanged += emailTb_TextChanged;
            // 
            // telefonoTb
            // 
            telefonoTb.Location = new Point(184, 266);
            telefonoTb.Name = "telefonoTb";
            telefonoTb.Size = new Size(218, 23);
            telefonoTb.TabIndex = 13;
            telefonoTb.TextChanged += telefonoTb_TextChanged;
            // 
            // contraseniaTb
            // 
            contraseniaTb.Location = new Point(184, 392);
            contraseniaTb.Name = "contraseniaTb";
            contraseniaTb.Size = new Size(218, 23);
            contraseniaTb.TabIndex = 17;
            contraseniaTb.TextChanged += contraseniaTb_TextChanged;
            // 
            // altaBtn
            // 
            altaBtn.Location = new Point(131, 551);
            altaBtn.Name = "altaBtn";
            altaBtn.Size = new Size(210, 47);
            altaBtn.TabIndex = 19;
            altaBtn.Text = "Dar de Alta";
            altaBtn.UseVisualStyleBackColor = true;
            altaBtn.Click += altaBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(131, 619);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(210, 23);
            clearBtn.TabIndex = 21;
            clearBtn.Text = "Limpiar Campos";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // errorNombre
            // 
            errorNombre.ContainerControl = this;
            // 
            // managerCb
            // 
            managerCb.FormattingEnabled = true;
            managerCb.Location = new Point(184, 352);
            managerCb.Name = "managerCb";
            managerCb.Size = new Size(218, 23);
            managerCb.TabIndex = 22;
            managerCb.SelectedIndexChanged += managerCb_SelectedIndexChanged;
            managerCb.TextChanged += managerCb_SelectedIndexChanged;
            // 
            // tiendaCb
            // 
            tiendaCb.FormattingEnabled = true;
            tiendaCb.Location = new Point(184, 308);
            tiendaCb.Name = "tiendaCb";
            tiendaCb.Size = new Size(218, 23);
            tiendaCb.TabIndex = 23;
            tiendaCb.SelectedIndexChanged += tiendaCb_SelectedIndexChanged;
            tiendaCb.TextChanged += tiendaCb_SelectedIndexChanged;
            // 
            // imgBt
            // 
            imgBt.Location = new Point(327, 463);
            imgBt.Name = "imgBt";
            imgBt.Size = new Size(75, 38);
            imgBt.TabIndex = 24;
            imgBt.Text = "Buscar Imagen";
            imgBt.UseVisualStyleBackColor = true;
            imgBt.Click += imgBt_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.SIN_FOTO;
            pictureBox1.Location = new Point(184, 438);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // errorApellido
            // 
            errorApellido.ContainerControl = this;
            // 
            // errorEmail
            // 
            errorEmail.ContainerControl = this;
            // 
            // errorTelefono
            // 
            errorTelefono.ContainerControl = this;
            // 
            // errorTienda
            // 
            errorTienda.ContainerControl = this;
            // 
            // errorManager
            // 
            errorManager.ContainerControl = this;
            // 
            // errorContrasenia
            // 
            errorContrasenia.ContainerControl = this;
            // 
            // tipoLb
            // 
            tipoLb.AutoSize = true;
            tipoLb.Location = new Point(12, 108);
            tipoLb.Name = "tipoLb";
            tipoLb.Size = new Size(74, 15);
            tipoLb.TabIndex = 26;
            tipoLb.Text = "Empleado ID";
            // 
            // idLb
            // 
            idLb.AutoSize = true;
            idLb.Location = new Point(184, 108);
            idLb.Name = "idLb";
            idLb.Size = new Size(13, 15);
            idLb.TabIndex = 27;
            idLb.Text = "0";
            // 
            // InsertarStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(486, 661);
            Controls.Add(idLb);
            Controls.Add(tipoLb);
            Controls.Add(pictureBox1);
            Controls.Add(imgBt);
            Controls.Add(tiendaCb);
            Controls.Add(managerCb);
            Controls.Add(clearBtn);
            Controls.Add(altaBtn);
            Controls.Add(contraseniaTb);
            Controls.Add(telefonoTb);
            Controls.Add(emailTb);
            Controls.Add(apellidoTb);
            Controls.Add(nombreTb);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tituloFormLb);
            Name = "InsertarStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insertar Empleado";
            ((System.ComponentModel.ISupportInitialize)errorNombre).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorApellido).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorTelefono).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorTienda).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorContrasenia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloFormLb;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox nombreTb;
        private TextBox apellidoTb;
        private TextBox emailTb;
        private TextBox telefonoTb;
        private TextBox contraseniaTb;
        private Button altaBtn;
        private Button clearBtn;
        private ErrorProvider errorNombre;
        private ComboBox tiendaCb;
        private ComboBox managerCb;
        private PictureBox pictureBox1;
        private Button imgBt;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider errorApellido;
        private ErrorProvider errorEmail;
        private ErrorProvider errorTelefono;
        private ErrorProvider errorTienda;
        private ErrorProvider errorManager;
        private ErrorProvider errorContrasenia;
        private Label idLb;
        private Label tipoLb;
    }
}