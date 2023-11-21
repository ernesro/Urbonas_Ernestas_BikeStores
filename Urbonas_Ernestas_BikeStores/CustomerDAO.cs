using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class CustomerDAO : IDisposable {
        bool disposed;

        public CustomerDAO() {
            disposed = false;
        }

        public IList<Customer> Listar() {
            using (var context = new BikeStoresContext()) {
                var data = context.Customers
               .Include(o => o.Orders)
               .ToList();

                return data;
            }
        }

        public Customer Listar(String ID) {
            using (var _context = new BikeStoresContext()) {
                var query = from st in _context.Customers
                            where st.CustomerId.ToString() == ID
                            select st;

                var Customer = query.FirstOrDefault<Customer>();
                return Customer;
            }
        }

        public void Insertar(Customer dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Customer modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Customer dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
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

