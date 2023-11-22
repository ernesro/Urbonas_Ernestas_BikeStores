using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class ProductDAO : IDisposable {
        private BikeStoresContext context;
        bool disposed;

        public ProductDAO() {
            context = new BikeStoresContext();
            disposed = false;
        }

        public IList<Product> Listar() {
            // Return the list of data from the database
            var data = context.Products.ToList();
            return data;
        }

        public Product Listar(String ID) {
            using (var _context = new BikeStoresContext()) {
                var query = from st in _context.Products
                            where st.ProductId.ToString() == ID
                            select st;

                var Product = query.FirstOrDefault<Product>();
                return Product;
            }
        }

        public void Insertar(Product dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Product modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Product dato) {
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
