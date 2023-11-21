using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class OrderItemDAO : IDisposable {

        bool disposed;

        public OrderItemDAO() {
            disposed = false;
        }

        public IList<OrderItem> Listar() {
            using (var context = new BikeStoresContext()) {
                // Return the list of data from the database
                var data = context.OrderItems.ToList();
                return data;
            }
        }

        public OrderItem Listar(String orderId, String itemId) {
            using (var _context = new BikeStoresContext()) {
                var query = from st in _context.OrderItems
                            where st.OrderId.ToString() == orderId && st.ItemId.ToString() == itemId
                            select st;

                var orderItem = query.FirstOrDefault<OrderItem>();
                return orderItem;
            }
        }

        public void Insertar(OrderItem dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(OrderItem modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(OrderItem dato) {
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
