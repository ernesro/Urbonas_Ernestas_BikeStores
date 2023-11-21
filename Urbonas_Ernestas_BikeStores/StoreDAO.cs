using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class StoreDAO : IDisposable {
        bool disposed;
        BikeStoresContext context;

        public StoreDAO() {
            disposed = false;
            context = new BikeStoresContext();
        }

        public IList<Store> Listar() {
            context = new BikeStoresContext();
            // Return the list of data from the database
            var data = context.Stores.ToList();
            return data;
        }

        public Store Listar(String ID) {
            using (var _context = new BikeStoresContext()) {
                var query = from st in _context.Stores
                            where st.StoreId.ToString() == ID
                            select st;

                var Store = query.FirstOrDefault<Store>();
                return Store;
            }
        }

        public void Insertar(Store dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Store modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Store dato) {
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
            }

            disposed = true;
        }
    }
}
