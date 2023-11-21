using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class OrderDAO : IDisposable {
        bool disposed;
        BikeStoresContext context;

        public OrderDAO() {
            disposed = false;
            context = new BikeStoresContext();
        }

        public IList<Order> Listar() {
            context = new BikeStoresContext();
            // Return the list of data from the database
            var data = context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .Include(o => o.Staff)
            .Include(o => o.Store)
            .ToList();

            return data;

        }

        public Order Listar(String ID) {
            using (var context = new BikeStoresContext()) {
                var query = from st in context.Orders
                            where st.OrderId.ToString() == ID
                            select st;

                var Order = query.FirstOrDefault<Order>();
                return Order;
            }
        }

        public void Insertar(Order dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Order modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Order dato) {
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
                context.Dispose();
            }

            disposed = true;
        }
    }
}

