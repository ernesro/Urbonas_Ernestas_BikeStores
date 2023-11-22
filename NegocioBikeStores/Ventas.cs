using BikeStoresEntidades;
using EEFBikeStores;
using System.Security.Cryptography;
using System.Text;

///<author> Ernestas Urbonas </author>

namespace NegocioBikeStores {
    public class Ventas : IDisposable {
        bool disposed;
        public Ventas() {
            disposed = false;
        }


        public List<Order> DatosPedido(int orderId)     //obtener datos de un pedido
        {
            var orderSelect = new List<Order>();
            OrderDAO orderDAO = new OrderDAO();
            var order = orderDAO.Listar();

            foreach (var item in order) {
                if (item.OrderId.Equals(orderId)) {
                    orderSelect.Add(item);
                }
            }

            return orderSelect;
        }

        public List<Order> ListarPedidosEmpleado(int EmployeeID)    //obtenemos lista de pedidos hecho por un empledo
        {
            var orderSelect = new List<Order>();
            OrderDAO orderDAO = new OrderDAO();
            var order = orderDAO.Listar();

            foreach (var item in order) {
                if (item.StaffId.Equals(EmployeeID)) {
                    orderSelect.Add(item);
                }
            }

            return orderSelect;
        }

        public List<Order> ListarPedidosCLiente(int CustomerID)     //Obtenemos lista de pedidos de un cliente
        {
            var orderSelect = new List<Order>();
            OrderDAO orderDAO = new OrderDAO();
            var order = orderDAO.Listar();

            foreach (var item in order) {
                if (item.CustomerId.Equals(CustomerID)) {
                    orderSelect.Add(item);
                }
            }

            return orderSelect;
        }

        public List<Staff> ListarEmpleados()        //Lista de empleados
        {
            using (var context = new StaffDAO()) {
                var orders = context.Listar();
                return orders.ToList();
            }
        }

        public List<Store> ListarStores()        //Lista de empleados
        {
            using (var context = new StoreDAO()) {
                var stores = context.Listar();
                return stores.ToList();
            }
        }

        public List<Brand> ListarMarcas()        //Lista de empleados
        {
            using (var context = new BrandDAO()) {
                var brands = context.Listar();
                return brands.ToList();
            }
        }
        public List<Customer> ListarCustomers() {
            using (var context = new CustomerDAO()) {
                var clientes = context.Listar();
                return clientes.ToList();
            }
        }

        public List<Category> ListarCategorias() {
            using (var context = new CategoryDAO()) {
                var categoria = context.Listar();
                return categoria.ToList();
            }
        }

        public List<Product> ListarProductos() {
            using (var context = new ProductDAO()) {
                var producto = context.Listar();
                return producto.ToList();
            }
        }

        public List<Stock> ListarStock() {
            using (var context = new StockDAO()) {
                var stock = context.Listar();
                return stock.ToList();
            }
        }

        public void InsertarSatff(Staff dato) {
            using (var context = new StaffDAO()) {
                context.Insertar(dato);
            }
        }

        public void ModificarSatff(Staff dato) {
            using (var context = new StaffDAO()) {
                context.Actualizar(dato);
            }
        }

        public string HashPassword(string password)   //Esta función toma una contraseña y la hashea utilizando el algoritmo SHA-256.
        {
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) {
            if (disposed)
                return;

            if (disposing) {
                // Free any other managed objects here.
                //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
            }

            disposed = true;
        }
    }
}
