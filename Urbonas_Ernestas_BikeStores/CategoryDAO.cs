using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores
{
    public class CategoryDAO : IDisposable
    {
        bool disposed;

        public CategoryDAO()
        {
            disposed = false;
        }

        static public IList<Category> Listar()
        {
            using (var context = new BikeStoresContext())
            {
                // Return the list of data from the database
                var data = context.Categories.ToList();
                return data;
            }
        }

        public Category Listar(String ID)
        {
            using (var _context = new BikeStoresContext())
            {
                var query = from st in _context.Categories
                            where st.CategoryId.ToString() == ID
                            select st;

                var Category = query.FirstOrDefault<Category>();
                return Category;
            }
        }

        public void Insertar(Category dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Category modificado)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Category dato)
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

