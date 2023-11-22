using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class StockDAO : IDisposable {
        bool disposed;
        BikeStoresContext context;

        public StockDAO() {
            context = new BikeStoresContext();
            disposed = false;
        }

        public IList<Stock> Listar() {
            // Return the list of data from the database
            var data = context.Stocks.ToList();
            return data;

        }

        public Stock Listar(String storeId, String productId) {
            using (var _context = new BikeStoresContext()) {
                var query = from st in _context.Stocks
                            where st.StoreId.ToString() == storeId && st.ProductId.ToString() == productId
                            select st;

                var stock = query.FirstOrDefault();
                return stock;
            }
        }

        public void Insertar(Stock dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Stock modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Stock dato) {
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
                context.Dispose();
                // Free any other managed objects here.
                //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
            }

            disposed = true;
        }
    }
}
