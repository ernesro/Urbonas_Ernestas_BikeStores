using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores
{
    public class BrandDAO : IDisposable
    {
        bool disposed;

        public BrandDAO()
        {
            disposed = false;
        }

        static public IList<Brand> Listar()
        {
            using (var context = new BikeStoresContext())
            {
                // Return the list of data from the database
                var data = context.Brands.ToList();
                return data;
            }
        }

        public Brand Listar(String ID)
        {
            using (var _context = new BikeStoresContext())
            {
                var query = from st in _context.Brands
                            where st.BrandId.ToString() == ID
                            select st;

                var Brand = query.FirstOrDefault<Brand>();
                return Brand;
            }
        }

        public void Insertar(Brand dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Brand modificado)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Brand dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
            }

            disposed = true;
        }
    }
}
